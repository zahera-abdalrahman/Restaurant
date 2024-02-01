using Resturant.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterCategoryMenuModel: BaseEntity
    {
        public int MasterCategoryMenuId { get; set; }
        [DataType(DataType.Text)]
        [Required]
        [Display(Name = "Category Menu Name")]
        public string MasterCategoryMenuName { get; set; }
    }
}
