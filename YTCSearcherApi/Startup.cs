using YTCSearcherApi.Db;
using YTCSearcherApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace YTCSearcherApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddCors();

            services.AddDbContext<DbDataContext>(options =>
            {
                string connectionString = _configuration.GetConnectionString("ProdConnection");

                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IDbOperationsService, DbOperationsService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var dbcontext = serviceScope.ServiceProvider.GetRequiredService<DbDataContext>();
                dbcontext.Database.EnsureCreated();
            }

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.WithMethods("POST");
                builder.WithHeaders("Content-type");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "api",
                    pattern: "api/{controller}/{action}");
            });
        }
    }
}
