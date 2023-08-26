using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Exceptions
{
    public class ReseñaDataExceptions : Exception
    {
        public ReseñaDataExceptions(string message): base(message) 
        {
        }
    }
}
