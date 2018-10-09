namespace SisWebServer.Server.Http.Response
{
    using Enums;
    using Http.Contracts;
    using System.Text;

    public abstract class HttpResponse : IHttpResponse
    {
        private string statusCodeMessage => this.StatusCode.ToString();

        protected HttpResponse()
        {
            this.Headers = new HttpHeaderCollection();
        }

        public IHttpHeaderCollection Headers { get; }

        public HttpResponseStatusCode StatusCode { get; protected set; }

        public override string ToString()
        {
            var response = new StringBuilder();

            var statusCodeNumber = (int)this.StatusCode;
            response.AppendLine($"HTTP/1.1 {statusCodeNumber} {this.statusCodeMessage}");

            response.AppendLine(this.Headers.ToString());

            return response.ToString();
        }
    }
}
