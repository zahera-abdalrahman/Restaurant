using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterServiceModel :BaseEntity
    {
    
        public int MasterServiceId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Service Title")]
        public string MasterServiceTitle { get; set; }
        [Required]
        [Display(Name = "Service Desc")]
        public string MasterServiceDesc { get; set; }
        [Required]
        [Display(Name = "Service Icon")]
        public string MasterServiceImage { get; set; }

    }
}
