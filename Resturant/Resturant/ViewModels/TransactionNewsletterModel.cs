using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class TransactionNewsletterModel: BaseEntity
    {
        public int TransactionNewsletterId { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "News letter Email")]
        public string TransactionNewsletterEmail { get; set; }
    }
}
