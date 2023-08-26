using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Exceptions
{
    public class NominacionesDataExceptions : Exception
    {
        public NominacionesDataExceptions(string message): base(message) 
        {
        }
    }
}
