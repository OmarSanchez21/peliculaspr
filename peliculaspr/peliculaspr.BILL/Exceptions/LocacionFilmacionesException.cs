using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class LocacionFilmacionesException : Exception
    {
        public LocacionFilmacionesException(string message) : base(message) 
        {
        }
    }
}
