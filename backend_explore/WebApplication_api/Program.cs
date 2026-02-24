using EF_CORE_Final_PROJECT.Data;
using WebApplication_api.Repository.Interface;
using WebApplication_api.Repository.Repository;
using WebApplication_api.Services.Interface;
using WebApplication_api.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Dependency Injection
builder.Services.AddScoped<ProductCatalogService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();    
builder.Services.AddSingleton<AppDbContext>();

//-------------------adding different lifetimes of services-------------------
builder.Services.AddSingleton<ISingletonGUI, SingletonGUIService>();
builder.Services.AddScoped<IScopedGUI , ScopedGUIService>();
builder.Services.AddTransient<ITransientGUI , TransientGUIService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
