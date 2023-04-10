using InjectedLocalizations;

namespace SampleWeb.Services.Localizations
{
    public interface IIndexLocalizations : ILocalizations
    {
        string Home_page { get; }
        string Welcome { get; }
        string Learn_about { get; }
        string building_Web_apps_with_Asp_Net_Core { get; }
        string Current_culture { get; }
    }
}
