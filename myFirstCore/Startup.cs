using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myFirstCore
{
    public class Startup
    {
        //用于访问appsetings的文件
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        //配置容器服务
        public void ConfigureServices(IServiceCollection services)
        {
            //注册controller，否则controller运行不了
            services.AddControllers();
        }

        // 配置HTTP请求处理管道当中一些配置（必须实现）
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//判断是否属于开发者模式
            {
                //异常中间件，当我们是开发者模式的情况下，这个组件就会被注册到请求管道当中
                app.UseDeveloperExceptionPage();//异常中间件
            }

            //我们可以在每个中间件当中，处理http请求，之前或者之后
            //你也可以选择中间件传递，传递到下一个中间件，你也可以不传递
            //不传递
            /* app.Run(async context =>
             {
                 await context.Response.WriteAsync("Hello!!!");
             });*/

            //继续传递
            /* app.Use(async (context, next) =>
             {
                 await context.Response.WriteAsync("Hello!!!");
                 await next();
             });
             */
            //强转https
            app.UseHttpsRedirection();
            //路由中间件
            app.UseRouting();
            //认证授权
            app.UseAuthorization();
            //终结点中间件
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync(configuration["MyName"]);
                });
                endpoints.MapControllers();
            });
        }
    }
}
