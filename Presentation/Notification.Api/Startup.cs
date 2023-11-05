using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Notification.Api.Extensions;
using Notification.Api.Filters;
using Notification.Application;

namespace Notification.Api
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
            services.ResolveSwaggerOptions(Configuration);
            services.AddSwaggerExtension();
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(ApiKeyAuthAttribute));
                options.Filters.Add(typeof(ModelStateValidationFilter));
            }).AddFluentValidation(option => option.RegisterValidatorsFromAssemblyContaining<Startup>());
            services.Configure<ApiBehaviorOptions>(options => { options.SuppressModelStateInvalidFilter = true; });
            services.AddApplication();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerExtension();
            app.UseCustomMiddlewares();
        }
    }
}
