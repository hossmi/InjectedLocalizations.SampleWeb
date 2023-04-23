using System.Globalization;

namespace SampleWeb.Localizations
{
    public class CastellanoIndexLocalizations : IIndexLocalizations
    {
        public string Home_page { get; } = "Página inicial";
        public string Welcome { get; } = "Bienvenido";
        public string Learn_about { get; } = "Aprenda sobre";
        public string Building_Web_apps_with_Asp_Net_Core { get; } = "crear aplicaciones web mediante Asp.Net Core";
        public string Current_culture { get; } = "Idioma actual";
        public CultureInfo Culture { get; } = new CultureInfo("es-ES");
    }
}
