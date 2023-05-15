using CatalogService.Application;
using CatalogService.Infrastructure.MessageBroker;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Web.Endpoints.Category;
using CatalogService.Web.Endpoints.Item;

namespace CatalogService.Web;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddMessageBroker(builder.Configuration);
        builder.Services.AddApplication();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
            
        app.RegisterCategoryEndpoints();
        app.RegisterItemEndpoints();

        app.Run();
    }
}