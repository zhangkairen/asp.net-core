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
        //���ڷ���appsetings���ļ�
        private IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        //������������
        public void ConfigureServices(IServiceCollection services)
        {
            //ע��controller������controller���в���
            services.AddControllers();
        }

        // ����HTTP������ܵ�����һЩ���ã�����ʵ�֣�
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())//�ж��Ƿ����ڿ�����ģʽ
            {
                //�쳣�м�����������ǿ�����ģʽ������£��������ͻᱻע�ᵽ����ܵ�����
                app.UseDeveloperExceptionPage();//�쳣�м��
            }

            //���ǿ�����ÿ���м�����У�����http����֮ǰ����֮��
            //��Ҳ����ѡ���м�����ݣ����ݵ���һ���м������Ҳ���Բ�����
            //������
            /* app.Run(async context =>
             {
                 await context.Response.WriteAsync("Hello!!!");
             });*/

            //��������
            /* app.Use(async (context, next) =>
             {
                 await context.Response.WriteAsync("Hello!!!");
                 await next();
             });
             */
            //ǿתhttps
            app.UseHttpsRedirection();
            //·���м��
            app.UseRouting();
            //��֤��Ȩ
            app.UseAuthorization();
            //�ս���м��
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
