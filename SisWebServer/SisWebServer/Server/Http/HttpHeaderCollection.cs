namespace SisWebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using SisWebServer.Server.Common;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly IDictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            // validator s object
            CoreValidator.ThrowIfNull(header, nameof(header));

            // override if we have the same header as key
            headers[header.Key] = header;
        }

        public bool ContainsKey(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));
            return this.headers.ContainsKey(key);
        }

        public HttpHeader Get(string key)
        {
            CoreValidator.ThrowIfNull(key, nameof(key));
            if (!headers.ContainsKey(key))
            {
                throw new InvalidOperationException($"The given key {nameof(key)} is not present in the header!");
            }
            return this.headers[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers);
        }
    }
}
