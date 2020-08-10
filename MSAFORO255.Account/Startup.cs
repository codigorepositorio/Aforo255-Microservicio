using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSAFORO255.Account.Repository;
using MSAFORO255.Account.Repository.Data;
using MSAFORO255.Account.Service;

namespace MSAFORO255.Account
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

           // services.AddJwtCustomized();

            services.AddDbContext<ContextDatabase>(
               opt =>
               {
                   opt.UseSqlServer(Configuration["sqlserver:cn"]);
               });

            services.AddScoped<IAccountService, AccountService>();            
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IContextDatabase, ContextDatabase>();

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
            //app.UseAuthentication();
            app.UseAuthorization();

        

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
