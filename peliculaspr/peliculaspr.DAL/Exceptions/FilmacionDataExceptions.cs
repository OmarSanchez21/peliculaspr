using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Exceptions
{
    public class FilmacionDataExceptions : Exception
    {
        public FilmacionDataExceptions(string message) : base(message) 
        {
        }
    }
}
