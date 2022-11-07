using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MQTTnet.AspNetCore;
using MQTTnet;
using System;
using System.Linq;

namespace Hermes {
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddHostedMqttServer(mqttServer => mqttServer
                                                       .WithDefaultEndpoint()
                                                       .WithDefaultCommunicationTimeout(new TimeSpan(0,2,0)))
                                                       .AddMqttConnectionHandler()
                                                       .AddConnections();

            services.AddSingleton<MqttService>();
            services.AddHostedMqttServerWithServices(options => {
                var s = options.ServiceProvider.GetRequiredService<MqttService>();
                
            })
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hermes", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hermes v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapConnectionHandler<MqttConnectionHandler>(
                    "/mqtt", httpConnectionDispatcherOptions => httpConnectionDispatcherOptions.WebSockets.SubProtocolSelector =
                            protocolList => protocolList.FirstOrDefault() ?? String.Empty);
                endpoints.MapControllers();
            });

            app.UseMqttServer(server => { });
        }
    }
}
