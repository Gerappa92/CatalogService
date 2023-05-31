using CatalogService.Application;
using CatalogService.Infrastructure.MessageBroker;
using CatalogService.Infrastructure.Persistence;
using CatalogService.Web.Endpoints.Category;
using CatalogService.Web.Endpoints.Item;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace CatalogService.Web;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.MetadataAddress = "http://localhost:8080/realms/myrealm/.well-known/openid-configuration";
                options.Authority = "http://localhost:8080/auth/realms/myrealm";
                options.Audience = "account";

                options.RequireHttpsMetadata = false;
            });

        builder.Services.AddAuthorization();

        builder.Services.AddPersistence(builder.Configuration);
        builder.Services.AddMessageBroker(builder.Configuration);
        builder.Services.AddApplication();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

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