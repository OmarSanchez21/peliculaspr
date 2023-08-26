using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class FilmacionesException : Exception
    {
        public FilmacionesException(string message) : base(message) 
        {
        }
    }
}
