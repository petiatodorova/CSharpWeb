using System;
using System.Net;
using System.Text.RegularExpressions;

namespace ValidateURL
{
    class URLValidate
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string decoded = WebUtility.UrlDecode(line);

            string pattern = @"^(http|https):\/\/.*$";
            Regex regex = new Regex(pattern);
            bool isValid = false;

            if (!regex.IsMatch(decoded))
            {
                Console.WriteLine($"Invalid URL");
                return;
            }
            else
            {
                Uri uriAddress = new Uri(decoded);
                string protocol = uriAddress.Scheme;
                string host = uriAddress.Host;
                int port = uriAddress.Port;

                if ((protocol == "http" && port == 80) || (protocol == "https" && port == 443))
                {
                    isValid = true;
                }

                string path = uriAddress.LocalPath;
                string query = uriAddress.Query.TrimStart('?');
                string fragment = uriAddress.Fragment.TrimStart('#');

                if (string.IsNullOrEmpty(protocol) ||
                    string.IsNullOrEmpty(host) ||
                    string.IsNullOrEmpty(path) ||
                    !isValid)
                {
                    Console.WriteLine($"Invalid URL");
                    return;
                }
                else
                {
                    Console.WriteLine($"Protocol: {protocol}");
                    Console.WriteLine($"Host: {host}");
                    Console.WriteLine($"Port: {port}");
                    Console.WriteLine($"Path: {path}");
                    if (query != "")
                    {
                        Console.WriteLine($"Query: {query}");
                    }

                    if (fragment != "")
                    {
                        Console.WriteLine($"Fragment: {fragment}");
                    }
                }
            }
        }
    }
}
