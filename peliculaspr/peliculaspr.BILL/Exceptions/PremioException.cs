using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class PremioException : Exception
    {
        public PremioException(string message) : base(message) 
        {
        }
    }
}
