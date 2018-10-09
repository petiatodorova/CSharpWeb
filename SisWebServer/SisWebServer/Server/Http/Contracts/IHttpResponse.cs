namespace SisWebServer.Server.Http.Contracts
{
    using Enums;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; }

        IHttpHeaderCollection Headers { get; }
    }
}
