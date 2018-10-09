namespace SisWebServer.Server.Handlers
{
    using Http.Contracts;
    using System;

    public class PostHandler : RequestHandler
    {
        public PostHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
            : base(handlingFunc)
        {

        }
    }
}
