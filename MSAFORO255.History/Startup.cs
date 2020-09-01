using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.Consul.Consul;
using MS.AFORO255.Cross.Consul.Mvc;
using MS.AFORO255.Cross.Jaeger.Jaeger;
using MS.AFORO255.Cross.RabbitMQ.Src;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MS.AFORO255.Cross.Redis.Redis;
using MSAFORO255.History.RabbitMQ.EventHandler;
using MSAFORO255.History.RabbitMQ.Events;
using MSAFORO255.History.Repository;
using MSAFORO255.History.Service;

namespace MSAFORO255.History
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IRepositoryHistory, RepositoryHistory>();
            services.AddScoped<IHistoryService, HistoryService>();

            ///*Start - RabbitMQ */
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();

            services.AddTransient<DepositEventHandler>();            
            services.AddTransient<IEventHandler<DepositCreatedEvent>, DepositEventHandler>();

            services.AddTransient<WithtdrawalEventHandler>();
            services.AddTransient<IEventHandler<WithtdrawalCreatedEvent>, WithtdrawalEventHandler>();
            ///*End - RabbitMQ*/
            ///
            /*Start - Consul*/
            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
            /*End - Consul*/

            services.AddRedis();


            services.AddJaeger();
            services.AddOpenTracing();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IHostApplicationLifetime hostApplicationLifetime, IConsulClient consulClient)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Genera el ID  de consult
            var serviceId = app.UseConsul();
            hostApplicationLifetime.ApplicationStopped.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceId);
            });

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<DepositCreatedEvent, DepositEventHandler>();
            eventBus.Subscribe<WithtdrawalCreatedEvent, WithtdrawalEventHandler>();

        }
    }
}
