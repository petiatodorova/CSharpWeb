using SisWebServer.Server.Common;
using System;

namespace SisWebServer.Server.Http
{
    public class HttpHeader
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public HttpHeader(string key, string value)
        {
            // validation for key == null
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));

            // validation for value == null
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(value));

            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Key}: {this.Value}";
        }
    }
}
