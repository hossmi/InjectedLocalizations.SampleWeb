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
                "it-IT",
                "de-DE",
            };
        }

        public IConfiguration Configuration { get; }
        public string DeepLApiKey => throw new ArgumentNullException("Put your api key here");
        public string DeepLUrl => throw new ArgumentNullException("Put your url here");

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(this.defaultCulture);
                options.AddSupportedCultures(this.availableCultures);
                options.AddSupportedUICultures(this.availableCultures);
            });

            services.AddInjectedLocalizations(configure =>
            {
                configure.GetCulturesFromRequestLocalizationsOptions();
                configure.SetHttpContextCurrentCultureProvider();
                configure.UseConcreteProvider();
                configure.UseDeepLProvider(90, options =>
                {
                    options.Url = this.DeepLUrl;
                    options.ApiKey = this.DeepLApiKey;

                    options.TargetCultureMap = new Dictionary<CultureInfo, string>
                    {
                        { new CultureInfo("en-US"), "EN-US" },
                        { new CultureInfo("it-IT"), "IT" },
                        { new CultureInfo("de-DE"), "DE" },
                        { new CultureInfo("es-ES"), "ES" },
                    };
                });
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
