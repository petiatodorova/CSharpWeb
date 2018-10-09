using System;
using System.Net;

namespace WebUtilityExample
{
    class Decoding
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string decoded = WebUtility.UrlDecode(line);
            Console.WriteLine($"{decoded}");
        }
    }
}
