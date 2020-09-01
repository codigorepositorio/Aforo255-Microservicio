using Consul;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.Consul.Consul;
using MS.AFORO255.Cross.Consul.Mvc;
using MS.AFORO255.Cross.Jaeger.Jaeger;
using MS.AFORO255.Cross.Proxy.Proxy;
using MS.AFORO255.Cross.RabbitMQ.Src;
using MSAFORO255.Deposit.RabbitMQ.CommandHandlers;
using MSAFORO255.Deposit.RabbitMQ.Commands;
using MSAFORO255.Deposit.Repository;
using MSAFORO255.Deposit.Repository.Data;
using MSAFORO255.Deposit.Service;

namespace MSAFORO255.Deposit
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
            services.AddDbContext<ContextDatabase>(
         opt =>
         {
             opt.UseNpgsql(Configuration["cnpostgres"]);

             //opt.UseNpgsql(Configuration["postgres:cn"]);
         });

            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IContextDatabase, ContextDatabase>();
            


            //Start RabbitMQ
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<IRequestHandler<DepositCreateCommand, bool>, DepositCommandHandler>();
            services.AddTransient<IRequestHandler<NotificationCreateCommand, bool>, NotificationCommandHandler>();
            //Fin RabbitMQ

            //Proxy-Polly
            services.AddProxyHttp();

            /*Start - Consul*/
            services.AddSingleton<IServiceId, ServiceId>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddConsul();
            /*End - Consul*/


            services.AddJaeger();
            services.AddOpenTracing();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IHostApplicationLifetime hostApplicationLifetime, IConsulClient consulClient)
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
        }
    }
}
