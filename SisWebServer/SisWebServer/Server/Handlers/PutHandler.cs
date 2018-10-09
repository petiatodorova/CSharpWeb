namespace SisWebServer.Server.Handlers
{
    using Http.Contracts;
    using System;

    public class PutHandler : RequestHandler
    {
        public PutHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
            : base(handlingFunc)
        {

        }
    }
}
