using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using person_api.Database;

namespace person_api
{
    public class Startup
    {
        private IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PeopleContext>(x => x.UseSqlServer(_configuration.GetConnectionString("SqlServer")));
            services.AddControllers();
            services.AddHealthChecks()
                    .AddDbContextCheck<PeopleContext>("Health", tags: new[] { "health" });
            services.AddHealthChecks()
                .AddCheck("Ready", () =>
                    HealthCheckResult.Healthy("Ready"), tags: new[] { "ready" }
                );

            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/status/health", new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains("health")
                });

                endpoints.MapHealthChecks("/status/ready", new HealthCheckOptions()
                {
                    Predicate = (check) => check.Tags.Contains("ready"),
                    ResponseWriter = async (context, healthReport) =>
                    {
                        await context.Response.WriteAsync("Ready");
                    }
                });

                endpoints.MapControllers();
            });
        }
    }
}
