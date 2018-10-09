namespace SisWebServer.Server.Http.Response
{
    using Enums;
    using SisWebServer.Server.Common;
    using System;

    public class InternalServerErrorResponse : ViewResponse
    {
        public InternalServerErrorResponse(Exception ex)
            : base(HttpResponseStatusCode.InternalServerError, new InternalServerErrorView(ex))
        {
        }
    }
}
