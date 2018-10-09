namespace SisWebServer.Server.Http.Response
{
    using Enums;

    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = HttpResponseStatusCode.NotFound;
        }
    }
}
