using System;
using System.Collections.Generic;
using System.Text;

namespace peliculaspr.DAL.Core
{
    public class AllEntity
    {
        public AllEntity()
        {
            IsDeleted = false;
        }
       public bool IsDeleted {  get; set; }
    }
}
