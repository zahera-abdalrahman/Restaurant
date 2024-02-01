using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class MasterWorkingHour : BaseEntity
    {
        public int MasterWorkingHourId { get; set; }
        public string MasterWorkingHourIdName { get; set; }
        public string MasterWorkingHourIdTimeFormTo { get; set; }
    }
}
