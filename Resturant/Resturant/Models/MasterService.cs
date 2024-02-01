using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class MasterService : BaseEntity
    {
        public int MasterServiceId { get; set; }
        public string MasterServiceTitle { get; set; }
        public string MasterServiceDesc { get; set; }
        public string MasterServiceImage { get; set; }
    }
}
