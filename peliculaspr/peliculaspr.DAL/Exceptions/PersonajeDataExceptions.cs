using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Exceptions
{
    public class PersonajeDataExceptions : Exception
    {
        public PersonajeDataExceptions(string message) : base(message) 
        {
        }
    }
}
