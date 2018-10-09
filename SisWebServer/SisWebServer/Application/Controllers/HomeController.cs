namespace SisWebServer.Application.Controllers
{
    using Server.Http.Contracts;
    using Server.Http.Response;
    using Server.Enums;
    using Application.Views.Home;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpResponseStatusCode.Ok, new IndexView());
        }
    }
}
