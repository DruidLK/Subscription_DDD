using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Subscriptions.Domain.Abstractions.ISubscriptions;
using Subscriptions.Domain.Subscriptions.DomainServices;
using Subscriptions.Infrastructure;

namespace Subscriptions
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddTransient<ISubscriptionAmountCalculator, SubscriptionAmountCalculator>();
            services.AddDbContext<SubscriptionContext>(config =>
            {
                var connectionString =
                    this.Configuration
                          .GetConnectionString("SubscriptionConnection");

                config.UseSqlServer(connectionString);
            });

            services.AddSwaggerGen(config =>
            {
                var openApiInfo = new OpenApiInfo
                {
                    Title = "Subscriptions",
                    Version = "V1.0"
                };

                config.SwaggerDoc(
                    name: "v1",
                    info: openApiInfo);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();
                app.UseSwaggerUI(config =>
                    config.SwaggerEndpoint(
                        url: "/swagger/v1/swagger.json",
                        name: "Subscriptions v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
                endpoints.MapControllers());
        }
    }
}
