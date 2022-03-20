using Business.DependencyResolvers.NetCore;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.DependencyResolvers.NetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Z.EntityFramework.Extensions;

namespace ContactManagementExample
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
            var connectionString = Configuration.GetSection("DefaultConnection").Value;

            services.AddDbContext<ContactManagementContext>(options =>
            {
                options.UseNpgsql(connectionString);
            }, ServiceLifetime.Scoped);

            EntityFrameworkManager.ContextFactory = context =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ContactManagementContext>();
                optionsBuilder.UseNpgsql(connectionString);
                return new ContactManagementContext(optionsBuilder.Options);
            };

            services.AddControllers();

            //NetCoreBusinessModule Dependency Injection 
            NetCoreBusinessModule.Common(services);

            //NetCoreBusinessModule Dependency Injection 
            NetCoreEntitiesModule.Common(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
