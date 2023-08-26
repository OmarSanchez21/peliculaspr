using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class EquipoProduccionException : Exception
    {
        public EquipoProduccionException(string message) : base(message) 
        {
        }
    }
}
