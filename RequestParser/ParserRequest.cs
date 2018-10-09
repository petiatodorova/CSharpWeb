using System;
using System.Collections.Generic;
using System.Linq;

namespace RequestParser
{
    class ParserRequest
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            // key --> method | value --> path
            Dictionary<string, HashSet<string>> validURL = new Dictionary<string, HashSet<string>>();

            while (line != "END")
            {
                string[] pathMethod = line
                    .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string path = $"/{pathMethod[0]}";
                string method = pathMethod[1];

                if (!validURL.ContainsKey(method))
                {
                    validURL[method] = new HashSet<string>();
                }

                validURL[method].Add(path);

                line = Console.ReadLine();
            }

            string request = Console.ReadLine();
            string[] reqParts = request
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string reqMethod = reqParts[0].ToLower();
            string reqPath = reqParts[1];
            string reqProtocol = reqParts[2];

            string statusText = "OK";
            int statusNumber = 200;

            if (!validURL.ContainsKey(reqMethod) 
                || !validURL[reqMethod].Contains(reqPath))
            {
                statusText = "Not Found";
                statusNumber = 404;
            }

            Console.WriteLine($"{reqProtocol} {statusNumber} {statusText}");
            Console.WriteLine($"Content-Length: {statusText.Length}");
            Console.WriteLine($"Content-Type: text/plain");
            Console.WriteLine($"{Environment.NewLine}{statusText}");
        }
    }
}
