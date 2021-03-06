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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using web33;
using web3;
using Newtonsoft.Json;

namespace web33
{
    public class Startup
    {
        private readonly IConfiguration _iconfiguration;
        private NetworkConfig networkConfig;

        public Startup(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
            networkConfig = new NetworkConfig();
            networkConfig.SetUrls(_iconfiguration.GetValue<string>("HOSTNAME"),_iconfiguration.GetValue<int>("SERVICES"));
        }

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
                context.Response.Headers.Add("hostname", context.Request.Host.Value);
                context.Response.ContentType = "text/html; charset=UTF-8";
                await next.Invoke();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello Worl111d!");
                });
                endpoints.MapGet("/incamp18-quote", async context =>
                {
                    var requestService = SetRequestService(context);
                    try
                    {
                        await requestService.PerformRequest(networkConfig.GetUrls());
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

        public RequestService SetRequestService(HttpContext context) {
            return (_iconfiguration.GetValue<string>("mode") == "async") 
                ? new RequestService(new ParallelRequest(), new ShuffleSelector(), context) 
                : new RequestService(new SyncRequest(), new ShuffleSelector(), context);
        }
    }
}
