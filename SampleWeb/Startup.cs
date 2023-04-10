using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SampleWeb
{
    public class Startup
    {
        private readonly CultureInfo defaultCulture;
        private readonly string[] availableCultures;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
            this.defaultCulture = new CultureInfo("en-US"); //TODO get it from configuration file, please
            this.availableCultures = new[] // TODO get it from configuration file, please
            {
                "en-US",
                "es-ES",
            };
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(this.defaultCulture);
                options.AddSupportedCultures(this.availableCultures);
                options.AddSupportedUICultures(this.availableCultures);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseRequestLocalization(app
                .ApplicationServices
                .GetRequiredService<IOptions<RequestLocalizationOptions>>()
                .Value);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
