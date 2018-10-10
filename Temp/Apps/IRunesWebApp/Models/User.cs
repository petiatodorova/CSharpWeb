using System;

namespace IRunesWebApp.Models
{
    //• Id – a string (GuID).
    //• Username – a string.
    //• Password – a string (encoded in the database).
    //• Email – a string.
    
    public class User : BaseEntity<Guid>
    {
        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string Email { get; set; }
    }
}
