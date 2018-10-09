namespace SisWebServer.Server.Http
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Common;
    using Enums;
    using System.Linq;
    using Exceprions;
    using System.Net;

    public class HttpRequest : IHttpRequest
    {
        private readonly string requestText;

        public HttpRequest(string requestText)
        {
            CoreValidator.ThrowIfNullOrEmpty(requestText, nameof(requestText));

            this.requestText = requestText;

            this.FormData = new Dictionary<string, string>();
            this.Headers = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();

            this.ParseRequest(requestText);
        }

        public IDictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Path { get; private set; }

        public HttpRequestMethod Method { get; private set; }

        public string Url { get; private set; }

        public IDictionary<string, string> UrlParameters { get; private set; }

        // Adding URL parameters
        public void AddUrlParameter(string key, string value)
        {
            CoreValidator.ThrowIfNullOrEmpty(key, nameof(key));
            CoreValidator.ThrowIfNullOrEmpty(value, nameof(value));

            //if we have 2 keys, which are equal, the second will be overriden
            this.UrlParameters[key] = value;
        }


        // Parses the request from the Constructor
        private void ParseRequest(string requestText)
        {
            var requestLines = requestText
                .Split(new[] { Environment.NewLine },
                StringSplitOptions.RemoveEmptyEntries);

            if (!requestLines.Any())
            {
                throw new BadRequestException("The request is not valid!");
            }

            var firtsRequestLine = requestLines
                .First()
                .Split(new[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);

            if (firtsRequestLine.Length != 3 || firtsRequestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("This request is not valid!");
            }

            this.Method = this.ParseMethod(firtsRequestLine.First());
            this.Url = firtsRequestLine[1];
            this.Path = this.ParsePath(this.Url);

            this.ParseHeaders(requestLines);
            this.ParseParameters();
            this.ParseFormData(requestLines.Last());
        }

        // The last line if we have method POST
        private void ParseFormData(string formData)
        {
            if (this.Method == HttpRequestMethod.Post)
            {
                this.ParseQuery(formData, this.FormData);
            }
        }


        // parsing URL parameters
        private void ParseParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }

            var query = this.Url
                .Split(new[] { '?' },
                StringSplitOptions.RemoveEmptyEntries)
                .Last();


            ParseQuery(query, this.UrlParameters);
        }


        // Parsing the query generally
        private void ParseQuery(string query, IDictionary<string, string> dict)
        {
            if (!query.Contains('='))
            {
                throw new BadRequestException("The query is not valid!");
            }

            var queryParts = query
                .Split(new[] { '&' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (var kvp in queryParts)
            {
                var kvpPairs = kvp.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                if (kvpPairs.Length != 2)
                {
                    throw new BadRequestException("The query is not valid!");
                }

                var keyKVP = WebUtility.UrlDecode(kvpPairs[0]);
                var valueKVP = WebUtility.UrlDecode(kvpPairs[1]);
                dict.Add(keyKVP, valueKVP);
            }
        }


        // used in ParseRequest
        private void ParseHeaders(string[] requestLines)
        {
            int emptyLineNumber = Array.IndexOf(requestLines, string.Empty);
            for (int i = 1; i < emptyLineNumber; i++)
            {
                string[] parts = requestLines[i].Split(new[] { ": " },
                    StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (parts.Length != 2)
                {
                    throw new BadRequestException("This head is not valid!");
                }

                string keyHeader = parts[0];
                string valueHeader = parts[1].Trim();

                HttpHeader header = new HttpHeader(keyHeader, valueHeader);
                this.Headers.Add(header);
            }

            //if (!this.Headers.ContainsKey("Host"))
            //{
            //    throw new BadRequestException("This head doesn't have host!");
            //}
        }


        // used in ParseRequest
        private string ParsePath(string url)
        {
            return url.Split(new[] { '?', '#' },
                StringSplitOptions.RemoveEmptyEntries).FirstOrDefault();
        }


        // used in ParseRequest
        private HttpRequestMethod ParseMethod(string method)
        {
            try
            {
                return Enum.Parse<HttpRequestMethod>(method, true);
            }
            catch (Exception)
            {
                throw new BadRequestException("This is not a valid method!");
            }
        }
    }
}
