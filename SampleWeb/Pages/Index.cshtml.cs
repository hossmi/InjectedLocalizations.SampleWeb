using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace SampleWeb.Pages
{
    public class IndexModel : PageModel
    {
        public IndexModel(IOptions<RequestLocalizationOptions> localizationOptions)
        {
            this.SupportedCultures = localizationOptions
                .Value
                .SupportedUICultures
                .ToList();
        }

        public IReadOnlyList<CultureInfo> SupportedCultures { get; }

        public CultureInfo RequestCulture => this.HttpContext
            .Features
            .Get<IRequestCultureFeature>()
            .RequestCulture
            .Culture;

        public void OnGet()
        {

        }
    }
}
