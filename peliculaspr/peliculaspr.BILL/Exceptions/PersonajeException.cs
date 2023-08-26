using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class PersonajeException : Exception
    {
        public PersonajeException(string message) : base(message) 
        {
        }
    }
}
