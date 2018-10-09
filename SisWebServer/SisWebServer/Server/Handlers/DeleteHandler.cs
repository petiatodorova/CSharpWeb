namespace SisWebServer.Server.Handlers
{
    using Http.Contracts;
    using System;

    public class DeleteHandler : RequestHandler
    {
        public DeleteHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
            : base(handlingFunc)
        {

        }
    }
}
