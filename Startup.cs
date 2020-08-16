using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Extentions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Storage;
using web3;

namespace web33
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("InCamp-Student", "Alex");
                context.Response.ContentType = "text/html; charset=utf8";
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/incamp", async context =>
                {
                    Response response = new Response();
                    try
                    {
                        foreach (var tag in DataStorage.tags)
                        {
                            await response.ParseHttpResponseAsync(await new HttpClient().GetAsync(DataStorage.urls.GetRandomElement() + tag));
                        }
                        await context.Response.WriteAsync($"{response.GetQuote()}\n{response.GetInfo()}");
                    }
                    catch (HttpRequestException e)
                    {
                       await context.Response.WriteAsync(e.Message);
                    }
                });
                endpoints.MapGet("/who", async context =>
                {
                    await context.Response.WriteAsync(DataStorage.who.GetRandomElement());
                });

                endpoints.MapGet("/does", async context =>
                {
                    await context.Response.WriteAsync(DataStorage.does.GetRandomElement());
                });
                endpoints.MapGet("/what", async context =>
                {
                    await context.Response.WriteAsync(DataStorage.what.GetRandomElement());
                });
                endpoints.MapGet("/how", async context =>
                {
                    await context.Response.WriteAsync(DataStorage.how.GetRandomElement());
                });
                endpoints.MapGet("/quote", async context =>
                {
                    await context.Response.WriteAsync(new Quote().GenerateQuote());
                });
            });
        }
    }
}
