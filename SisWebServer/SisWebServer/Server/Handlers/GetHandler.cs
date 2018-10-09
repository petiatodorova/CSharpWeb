namespace SisWebServer.Server.Handlers
{
    using Http.Contracts;
    using System;

    public class GetHandler : RequestHandler
    {
        public GetHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
            : base(handlingFunc)
        {

        }
    }
}
