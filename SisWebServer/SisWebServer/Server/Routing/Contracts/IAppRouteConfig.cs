using SisWebServer.Server.Enums;
using SisWebServer.Server.Handlers;
using SisWebServer.Server.Http.Contracts;
using System;
using System.Collections.Generic;

namespace SisWebServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Put(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Delete(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, HttpRequestMethod method, RequestHandler handler);
    }
}
