using Helpdesk.Application.Common;
using Helpdesk.Application.Interface;
using Helpdesk.Model.Common;
using Helpdesk.Persistence;
using Helpdesk.WebApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Helpdesk.WebApi
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
            services.AddModels();
            services.AddApplication();

            services.AddControllersWithViews(options =>
                options.Filters.Add(new ApiExceptionFilter()));

            services.AddConfiguredDbContext(Configuration);

            services.AddScoped<IHelpdeskDbContext>(s => s.GetService<HelpdeskDbContext>());

            services.AddSwaggerGen(x =>
                {
                    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Helpdesk API", Version = "v1" });
                });

            // Add AutoMapper
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, HelpdeskDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var swaggerOptions = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

            app.UseSwagger(option => { option.RouteTemplate = swaggerOptions.JsonRoute; });

            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint(swaggerOptions.UiEndpoint, swaggerOptions.Description);
            });

            app.UseHttpsRedirection();

             app.UseRouting();

             app.UseAuthorization();

             app.UseEndpoints(endpoints =>
             {
                 endpoints.MapControllers();
             });

            ctx.Database.Migrate();

           
        }
    }
}