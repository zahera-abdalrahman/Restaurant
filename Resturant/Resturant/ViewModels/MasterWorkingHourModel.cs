using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterWorkingHourModel:BaseEntity
    {
    
        public int MasterWorkingHourId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Working Hour Day")]
        public string MasterWorkingHourIdName { get; set; }
        [Required]
        [Display(Name = "Working Hour Time")]
        public string MasterWorkingHourIdTimeFormTo { get; set; }
    }
}
