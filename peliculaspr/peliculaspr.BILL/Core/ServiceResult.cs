﻿using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Core
{
    public class ServiceResult
    {
        public ServiceResult() 
        {
            this.Success = true;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
