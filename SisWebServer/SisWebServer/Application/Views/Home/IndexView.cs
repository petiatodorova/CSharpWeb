using SisWebServer.Server.Contracts;

namespace SisWebServer.Application.Views.Home
{
    public class IndexView : IView
    {
        public string View() => "<h1>Welcome!</h1>";
    }
}
