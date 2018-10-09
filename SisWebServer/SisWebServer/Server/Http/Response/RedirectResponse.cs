namespace SisWebServer.Server.Http.Response
{
    using Common;
    using Enums;

    public class RedirectResponse : HttpResponse
    {
        public RedirectResponse(string redirectUrl)
        {
            CoreValidator.ThrowIfNullOrEmpty(redirectUrl, nameof(redirectUrl));

            this.StatusCode = HttpResponseStatusCode.Found;

            this.Headers.Add(new HttpHeader("Location", redirectUrl));
        }
    }
}
