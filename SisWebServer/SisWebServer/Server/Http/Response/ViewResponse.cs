namespace SisWebServer.Server.Http.Response
{
    using Enums;
    using Server.Contracts;
    using SisWebServer.Server.Exceprions;

    public class ViewResponse : HttpResponse
    {
        private readonly IView view;

        public ViewResponse(HttpResponseStatusCode statusCode, IView view)
        {
            this.ValidateStatusCode(statusCode);

            this.view = view;
            this.StatusCode = statusCode;

            //this.Headers.Add(HttpHeader.ContentType, "text/html");
        }

        private void ValidateStatusCode(HttpResponseStatusCode statusCode)
        {
            var statusCodeNumber = (int)statusCode;

            if (299 < statusCodeNumber && statusCodeNumber < 400)
            {
                throw new BadRequestException("View responses need a status code below 300 and above 400 (inclusive).");
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.view.View()}";
        }
    }
}
