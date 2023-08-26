using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Exceptions
{
    public class PeliculaDataExceptions : Exception
    {
        public PeliculaDataExceptions(string message) : base(message) 
        {
        }
    }
}
