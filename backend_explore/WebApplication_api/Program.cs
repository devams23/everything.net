
using AutoMapper;
using WebApplication_api.Data;
using WebApplication_api.Repository.Interface;
using WebApplication_api.Repository.Repository;
using WebApplication_api.Services.Interface;
using WebApplication_api.Services.MapperProfile;
using WebApplication_api.Services.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MappingProfile>();
});


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Dependency Injection 
builder.Services.AddScoped<ProductCatalogService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<AppDbContext>();

//-------------------adding different lifetimes of services-------------------
builder.Services.AddSingleton<ISingletonGUI, SingletonGUIService>();
builder.Services.AddScoped<IScopedGUI, ScopedGUIService>();
builder.Services.AddTransient<ITransientGUI, TransientGUIService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
