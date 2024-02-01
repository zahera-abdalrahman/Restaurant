using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class TransactionNewsletter:BaseEntity
    {
        public int TransactionNewsletterId { get; set; }
        public string TransactionNewsletterEmail { get; set; }
    }
}
