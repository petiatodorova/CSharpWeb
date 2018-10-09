using SisWebServer.Server.Common;
using System;
using System.Collections.Generic;

namespace SisWebServer.Server.Http
{
    public class HttpHeader
    {
        public const string ContentType = "Content-Type";
        public const string Host = "Host";
        public const string Location = "Location";
        public const string Cookie = "Cookie";
        public const string SetCookie = "Set-Cookie";

        public HttpHeader(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public string Key { get; private set; }

        public string Value { get; private set; }

        public override string ToString() => $"{this.Key}: {this.Value}";

        public static implicit operator HttpHeader(List<HttpHeader> v)
        {
            throw new NotImplementedException();
        }
    }
}
