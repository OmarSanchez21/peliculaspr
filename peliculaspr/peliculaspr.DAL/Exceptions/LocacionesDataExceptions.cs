using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Exceptions
{
    public class LocacionesDataExceptions : Exception
    {
        public LocacionesDataExceptions(string message): base(message) 
        {
        }
    }
}
