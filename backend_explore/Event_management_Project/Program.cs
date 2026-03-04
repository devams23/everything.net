using System.Security.Claims;
using System.Text;
using System.Threading.RateLimiting;
using Event_management_Project.Data;
using Event_management_Project.Middlewares;
using Event_management_Project.Repository.Implementations;
using Event_management_Project.Repository.Interfaces;
using Event_management_Project.Security;
using Event_management_Project.Security.Options;
using Event_management_Project.Security.Services;
using Event_management_Project.Services.Implementations;
using Event_management_Project.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.SectionName));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString"));
});

JwtOptions jwtOptions = builder.Configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>()
    ?? throw new InvalidOperationException("JwtConfig is missing.");

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key)),
            ClockSkew = TimeSpan.Zero,
            NameClaimType = ClaimTypes.NameIdentifier,
            RoleClaimType = ClaimTypes.Role
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", p => p.RequireRole("Admin"));
    options.AddPolicy("OrganizerOrAdmin", p => p.RequireRole("Organizer", "Admin"));
    options.AddPolicy("AttendeeOnly", p => p.RequireRole("Attendee"));
});


builder.Services.AddRateLimiter(options =>
{
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    {
        
        string? userId = httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        string ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        string key = string.IsNullOrWhiteSpace(userId) ? $"ip:{ip}" : $"user:{userId}";

        return RateLimitPartition.GetFixedWindowLimiter(key, _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 10,
            Window = TimeSpan.FromMinutes(1),
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
            QueueLimit = 0,
            AutoReplenishment = true
        });
    });

    options.AddPolicy("AuthEndpoints", httpContext =>
    {
        string ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
        return RateLimitPartition.GetFixedWindowLimiter($"auth:{ip}", _ => new FixedWindowRateLimiterOptions
        {
            PermitLimit = 10,
            Window = TimeSpan.FromMinutes(1),
            QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
            QueueLimit = 0,
            AutoReplenishment = true
        });
    });

    options.OnRejected = async (context, token) =>
    {
        context.HttpContext.Response.ContentType = "application/json";
        await context.HttpContext.Response.WriteAsync("{\"message\":\"Rate limit exceeded. Try again later.\"}", token);
    };
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IRefreshTokenService, RefreshTokenService>();
builder.Services.AddSingleton<ITokenService, TokenService>();

builder.Services.AddTransient<GlobalExceptionMiddleware>();
builder.Services.AddTransient<RequestLoggingMiddleware>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header ."
    }); 
    
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});

var app = builder.Build();

await DbSeeder.SeedAdminAndOrganizersAsync(app.Services);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseRateLimiter();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
