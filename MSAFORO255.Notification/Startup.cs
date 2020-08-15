using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.AFORO255.Cross.RabbitMQ.Src;
using MS.AFORO255.Cross.RabbitMQ.Src.Bus;
using MSAFORO255.Notification.RabbitMQ.EventHandler;
using MSAFORO255.Notification.RabbitMQ.Events;
using MSAFORO255.Notification.Repository;
using MSAFORO255.Notification.Repository.Data;

namespace MSAFORO255.Notification
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
            services.AddDbContext<ContextDatabase>(
                opt =>
                {
                    opt.UseMySQL(Configuration["mariadb:cn"]);
                });

            ///*Start - RabbitMQ */
            services.AddMediatR(typeof(Startup));
            services.AddRabbitMQ();
            services.AddTransient<NotificationEventHandler>();
            services.AddTransient<IEventHandler<NotificationCreatedEvent>, NotificationEventHandler>();

            ///*End - RabbitMQ*/

            services.AddScoped<IContextDatabase, ContextDatabase>();
            services.AddScoped<IMailRepository, MailRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<NotificationCreatedEvent, NotificationEventHandler>();
        }
    }
}
