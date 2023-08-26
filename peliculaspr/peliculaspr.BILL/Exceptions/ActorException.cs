using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Exceptions
{
    public class ActorException : Exception
    {
        public ActorException(string message) : base(message) 
        {
        }
    }
}
