using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.BILL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();
        ServiceResult GetById(int id);
    }
}
