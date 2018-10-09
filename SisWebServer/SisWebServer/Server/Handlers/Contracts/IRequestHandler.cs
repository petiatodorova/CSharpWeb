using SisWebServer.Server.Http.Contracts;

namespace SisWebServer.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext context);
    }
}
