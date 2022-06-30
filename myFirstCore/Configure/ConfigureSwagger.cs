using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace myFirstCore.Configure
{
    public static class ConfigureSwagger
    {
        public static void AddSwaggerUp(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //注册Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger接口文档",
                    Version = "v1",
                    Description = $"Core.WebApi HTTP API V1",
                    Contact = new OpenApiContact { Name = "张三", Email = "59531876@sina.com" }
                });
                c.OrderActionsBy(o => o.RelativePath);
            });
        }
    }
}
