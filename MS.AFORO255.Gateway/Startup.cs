using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MS.AFORO255.Cross.Jaeger.Jaeger;
using MS.AFORO255.Cross.Jwt.Src;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace MS.AFORO255.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
      
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddOcelot();
            services.AddJwtCustomized();

            services.AddJaeger();
            services.AddOpenTracing();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOcelot().Wait();
        }
    }
}
