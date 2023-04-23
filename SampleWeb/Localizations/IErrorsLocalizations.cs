using InjectedLocalizations;

namespace SampleWeb.Localizations
{
    public interface IErrorsLocalizations : ILocalizations
    {
        string Error { get; }
        string An_error_occurred_while_processing_your_request { get; }
        string Request_Id { get; }
        string Development_mode { get; }
    }
}
