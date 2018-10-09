using System;

namespace SisWebServer.Server.Exceprions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) 
            : base(message)
        {

        }
    }
}
