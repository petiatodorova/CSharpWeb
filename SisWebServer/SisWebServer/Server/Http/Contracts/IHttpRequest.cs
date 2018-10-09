

namespace SisWebServer.Server.Http.Contracts
{
    using System;
    using System.Collections.Generic;
    using Enums;
    public interface IHttpRequest
    {
        // only get because the request is not changing
        IDictionary<string, string> FormData { get; }

        HttpHeaderCollection Headers { get; }

        string Path { get; }

        HttpRequestMethod Method { get; }

        string Url { get; }

        IDictionary<string, string> UrlParameters { get; }

        void AddUrlParameter(string key, string value);
    }
}
