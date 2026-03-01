using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using WebApplication_api.Data;
using WebApplication_api.Middlewares;
using WebApplication_api.Repository.Interface;
using WebApplication_api.Repository.Repository;
using WebApplication_api.Services.Interface;
using WebApplication_api.Services.MapperProfile;
using WebApplication_api.Services.Service;
using WebApplication_api.Services.Service.Auth;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {

        ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
        ValidAudience = builder.Configuration["JwtConfig:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtConfig:Key"] ?? throw new InvalidOperationException("JWT Key is not configured."))),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
    //Console.WriteLine("JWT Authentication configured with Issuer: " + builder.Configuration["JwtConfig:Issuer"] + ", Audience: " + builder.Configuration["JwtConfig:Audience"]);
    //Console.WriteLine("Issuer signing key: " + builder.Configuration["JwtConfig:Key"]);
}
);

builder.Services.AddAuthorization(options =>
{
    // Policy for Admin role only
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));

    // Policy for Vendor role only
    options.AddPolicy("VendorOnly", policy =>
        policy.RequireRole("Vendor"));

    // Policy for Admin and Vendor roles
    options.AddPolicy("AdminOrVendor", policy =>
        policy.RequireRole("Admin", "Vendor"));

    // Policy for authenticated users (all roles)
    options.AddPolicy("AuthenticatedUsers", policy =>
        policy.RequireAuthenticatedUser());
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
// Source - https://stackoverflow.com/a/79835686
// Posted by Nermin, modified by community. See post 'Timeline' for change history
// Retrieved 2026-03-01, License - CC BY-SA 4.0

builder.Services.AddSwaggerGen(options =>
{

    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("bearer", document)] = []
    });
});



// Dependency Injection 
builder.Services.AddScoped<ProductCatalogService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<AppDbContext>();

//-------------------adding different lifetimes of services-------------------
builder.Services.AddSingleton<ISingletonGUI, SingletonGUIService>();
builder.Services.AddScoped<IScopedGUI, ScopedGUIService>();
builder.Services.AddTransient<ITransientGUI, TransientGUIService>();

builder.Services.AddTransient<CustomMiddleware>();
builder.Services.AddScoped<JWTService>();

//builder.Services.AddScoped<IConfiguration>(_ => builder.Configuration);
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();

}



app.UseHttpsRedirection();

// Add Custom Middleware for request/response logging
app.UseMiddleware<CustomMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


app.Run();

