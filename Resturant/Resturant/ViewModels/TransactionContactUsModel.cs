using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class TransactionContactUsModel:BaseEntity
    {
    
        public int TransactionContactUsId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ContactUs FullName")]
        public string TransactionContactUsFullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "ContactUs Email")]
        public string TransactionContactUsEmail { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ContactUs Subject")]
        public string TransactionContactUsSubject { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "ContactUs Message")]
        public string TransactionContactUsMessage { get; set; }
    }
}
