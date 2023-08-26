using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class MiembroProduccionException : Exception
    {
        public MiembroProduccionException(string message) : base(message) 
        {
        }
    }
}
