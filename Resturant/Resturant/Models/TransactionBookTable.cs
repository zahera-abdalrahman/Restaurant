using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class TransactionBookTable : BaseEntity
    {
        public int TransactionBookTableId { get; set; }
        public string TransactionBookTableFullName { get; set; }
        public string TransactionBookTableEmail { get; set; }
        public string TransactionBookTableMobileNumber { get; set; }
        public DateTime? TransactionBookTableDate { get; set; }

        public DateTime TransactionBookTableTime { get; set; }
    }
}
