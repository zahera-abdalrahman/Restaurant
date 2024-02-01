using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterSliderModel:BaseEntity
    {
    
        public int MasterSliderId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Slider Title")]
        public string MasterSliderTitle { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Slider Breef")]
        public string MasterSliderBreef { get; set; }
        [Required]
        [Display(Name = "Slider Desc")]
        public string MasterSliderDesc { get; set; }
       
        
        [Display(Name = "Slider Url")]
        public string MasterSliderUrl { get; set; }

        public IFormFile File { get; set; }

    }
}
