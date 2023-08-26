using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class PeliculaException : Exception
    {
        public PeliculaException(string message) : base(message) 
        {
        }
    }
}
