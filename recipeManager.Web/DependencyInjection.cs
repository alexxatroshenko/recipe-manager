using Microsoft.OpenApi.Models;
using recipe_manager.Infrastructure;

namespace recipe_manager;

public static class DependencyInjection
{
    public static void AddWebServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddExceptionHandler<CustomExceptionHandler>();
        
        var corsOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AngularPolicy", policy =>
            {
                if (corsOrigins != null)
                    policy.WithOrigins(corsOrigins) // URL Angular в dev-режиме
                        .AllowAnyHeader()
                        .AllowAnyMethod();
            });
        });
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c => 
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            c.DocInclusionPredicate((docName, apiDesc) => true);
        });
    }
}