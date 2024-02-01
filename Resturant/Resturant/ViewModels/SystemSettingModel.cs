using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class SystemSettingModel : BaseEntity
    {
   
        public int SystemSettingId { get; set; }
        
        [Display(Name = "Logo One")]
        public string SystemSettingLogoImageUrl { get; set; }
        
        [Display(Name = "Logo Two")]
        public string SystemSettingLogoImageUrl2 { get; set; }

        public IFormFile LogoOne { get; set; }

        public IFormFile LogoTwo { get; set; }

        [Required(ErrorMessage = "Copyright Is Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Copyright")]
        public string SystemSettingCopyright { get; set; }
        [Required(ErrorMessage = "Note Title Is Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Note Title")]
        public string SystemSettingWelcomeNoteTitle { get; set; }
        [Required(ErrorMessage = "Note Breif Is Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Note Breef")]
        public string SystemSettingWelcomeNoteBreef { get; set; }
        [Required(ErrorMessage = "Note Description Is Required")]
        [Display(Name = "Note Desc")]
        public string SystemSettingWelcomeNoteDesc { get; set; }
        [Required(ErrorMessage = "Note Url Is Required")]
        [Display(Name = "Note URL")]
        public string SystemSettingWelcomeNoteUrl { get; set; }
        [Display(Name = "Image 1")]
        public string SystemSettingWelcomeNoteImageUrl { get; set; }
        [DisplayName("Image 2")]
        public string SystemSettingWelcomeNoteImageUrl2 { get; set; }
        [DisplayName("Image 3")]
        public string SystemSettingWelcomeNoteImageUrl3 { get; set; }
        [DisplayName("Image 4")]
        public string SystemSettingWelcomeNoteImageUrl4 { get; set; }
        public IFormFile FileOne { get; set; }
        public IFormFile FileTwo { get; set; }
        public IFormFile FileThree { get; set; }
        public IFormFile FileFour { get; set; }
      
        
        [Display(Name = "Map Location")]
        public string SystemSettingMapLocation { get; set; }
    }
}
