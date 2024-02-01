using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterPartnerModel :BaseEntity
    {
    
        public int MasterPartnerId { get; set; }
        
        [DataType(DataType.Text)]
        [Display(Name = "Partner Name")]
        public string MasterPartnerName { get; set; }
        [Display(Name = "Partner Logo")]
        public string MasterPartnerLogoImageUrl { get; set; }

        public IFormFile File { get; set; }
        
        [DataType(DataType.Url)]
        [Display(Name = "Partner Website Url")]
        public string MasterPartnerWebsiteUrl { get; set; }
    }
}
