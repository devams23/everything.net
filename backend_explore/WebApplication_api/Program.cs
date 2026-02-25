
using Microsoft.OpenApi;
using WebApplication_api.Data;
using WebApplication_api.Middlewares;
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

builder.Services.AddTransient<CustomMiddleware>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();

    app.Use(async (context, next) =>
    {
        Console.WriteLine("Work that can write to the response. (1)");
        await next();
        Console.WriteLine("Work that doesn't write to the response. (1)");
    });
 
    app.Use(async (context, next) =>
    {
        Console.WriteLine("Work that can write to the response. (2)");
        await next();
        Console.WriteLine("Work that doesn't write to the response. (2)");
        //await Task.Delay(4000);
    });

    app.UseMiddleware<CustomMiddleware>();


    app.Run(async (context) =>
    {
        Console.WriteLine("This statement isn't reached. (3)");
        await context.Response.WriteAsync("Terminal middleware reached. Ending the pipeline. (3)");
        //await next();
        // Console.WriteLine("This statement isn't reached. (3)");
    });

 
    // app.Run(async context =>
    // {
    //     await context.Response.WriteAsync("Terminal middleware reached. Ending the pipeline. (4)");
    // });

}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
