namespace SisWebServer.Server.Http.Contracts
{
    public interface IHttpContext
    {
        IHttpRequest Request { get; }
    }
}
