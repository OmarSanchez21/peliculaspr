using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Exceptions
{
    public class PremioDataExceptions : Exception
    {
        public PremioDataExceptions(string message) : base(message) 
        {
        }
    }
}
