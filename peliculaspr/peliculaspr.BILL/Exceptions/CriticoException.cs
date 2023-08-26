using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class CriticoException : Exception
    {
        public CriticoException(string message) : base(message)
        {
        }
    }
}
