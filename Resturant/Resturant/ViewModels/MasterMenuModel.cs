using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterMenuModel : BaseEntity
    {
    
        public int MasterMenuId { get; set; }
        [Required]
        [Display(Name = "Menu Name")]
        public string MasterMenuName { get; set; }
        [Required]       
        [Display(Name = "Menu Url")]
        public string MasterMenuUrl { get; set; }
    }
}
