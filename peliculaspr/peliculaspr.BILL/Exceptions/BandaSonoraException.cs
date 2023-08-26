using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class BandaSonoraException : Exception
    {
        public BandaSonoraException(string message) : base(message) 
        {
        }
    }
}
