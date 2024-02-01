using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterContactUsInformationModel:BaseEntity
    {


        public int MasterContactUsInformationId { get; set; }
        
        [Required(ErrorMessage = "Name Required..!")]
        [Display(Name = "Description")]
        public string MasterContactUsInformationIdesc { get; set; }
        
        
        [Display(Name = "Icon")]
        public string MasterContactUsInformationImageUrl { get; set; }
       
        [Display(Name = "Redirect")]
        public string MasterContactUsInformationRedirect { get; set; }
    }
}
