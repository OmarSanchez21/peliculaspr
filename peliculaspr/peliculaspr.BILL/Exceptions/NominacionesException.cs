using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class NominacionesException : Exception
    {
        public NominacionesException(string message) : base(message) 
        {
        }
    }
}
