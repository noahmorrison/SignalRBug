using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace SignalRBug
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddSignalR().AddJsonProtocol();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<SignalRController>("/SignalR");
            });

            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:7778/SignalR")
                .AddJsonProtocol()
                .Build();

            Task.Run(async () =>
            {
                var p1 = new PingClass { Type = PingType.Ping, Message = "Hello" };

                await connection.StartAsync();
                await connection.InvokeAsync("Ping", p1.Type, p1.Message);
                var p2 = await connection.InvokeAsync<PingClass>("PingWithClass", p1);

                Console.WriteLine($"{p1} == {p2}: {p1 == p2}");
            });
        }
    }
}