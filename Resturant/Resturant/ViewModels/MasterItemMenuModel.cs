using Microsoft.AspNetCore.Http;
using Resturant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Resturant.ViewModels
{
    public class MasterItemMenuModel : BaseEntity
    {
    
        public int MasterItemMenuId { get; set; }

        public int MasterCategoryMenuId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Item Menu Title")]
        public string MasterItemMenuTitle { get; set; }
        
        [Display(Name = "Item Menu Breef")]
        public string MasterItemMenuBreef { get; set; }
        
        [Display(Name = "Item Menu Desc")]
        public string MasterItemMenuDesc { get; set; }
        [Required]
        [Display(Name = "Item Menu Price")]
        public decimal? MasterItemMenuPrice { get; set; }
        
        [Display(Name = "Item Menu Image")]
        public string MasterItemMenuImageUrl { get; set; }

        public IFormFile File { get; set; }
        [Required]
        [Display(Name = "Item Menu Date")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? MasterItemMenuDate { get; set; }

        public List<MasterCategoryMenu> ListCategory { get; set; }
        [Display(Name = "Category Menu")]
        public MasterCategoryMenu MasterCategoryMenu { get; set; }
    }
}
