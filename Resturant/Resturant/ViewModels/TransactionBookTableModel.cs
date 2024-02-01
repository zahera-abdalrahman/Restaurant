using Resturant.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class TransactionBookTableModel : BaseEntity
    {
    
        public int TransactionBookTableId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "BookTable FullName")]
        public string TransactionBookTableFullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "BookTable Email")]
        public string TransactionBookTableEmail { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "BookTable MobileNumber")]
        public string TransactionBookTableMobileNumber { get; set; }
        [Required]
        [Display(Name = "BookTable Date")]
        [DataType(DataType.Date)]
        public DateTime? TransactionBookTableDate { get; set; }
        [Required]
        [Display(Name = "BookTable Date")]
        [DataType(DataType.Time)]
        public DateTime TransactionBookTableTime { get; set; }
    }
}
