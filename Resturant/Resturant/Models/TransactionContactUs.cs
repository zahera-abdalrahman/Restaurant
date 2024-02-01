using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class TransactionContactUs : BaseEntity
    {
        public int TransactionContactUsId { get; set; }
        public string TransactionContactUsFullName { get; set; }
        public string TransactionContactUsEmail { get; set; }
        public string TransactionContactUsSubject { get; set; }
        public string TransactionContactUsMessage { get; set; }
    }
}
