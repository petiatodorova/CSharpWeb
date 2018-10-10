using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesWebApp.Models
{
    public abstract class BaseEntity<TKeyIdentifier>
    {
        public TKeyIdentifier Id { get; set; }
    }
}
