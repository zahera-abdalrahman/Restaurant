using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterSocialMediumModel:BaseEntity
    {
    
        public int MasterSocialMediumId { get; set; }
       
        [Display(Name = "Social Media Icon")]
        public string MasterSocialMediumImageUrl { get; set; }
        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Social Media Url")]
        public string MasterSocialMediumUrl { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Social Media Name")]
        public string MasterSocialMediumName { get; set; }
    }
}
