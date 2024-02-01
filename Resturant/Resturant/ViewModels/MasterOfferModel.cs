using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterOfferModel :BaseEntity
    {
    
        public int MasterOfferId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Offer Title")]
        public string MasterOfferTitle { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Offer Breef")]
        public string MasterOfferBreef { get; set; }
        [Required]
        [Display(Name = "Offer Des")]
        public string MasterOfferDesc { get; set; }
        
        [Display(Name = "Offer Image")]
        public string MasterOfferImageUrl { get; set; }

        public IFormFile File { get; set; }
    }
}
