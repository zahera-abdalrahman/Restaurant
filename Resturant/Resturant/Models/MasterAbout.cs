using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Resturant.Models
{
    public class MasterAbout:BaseEntity
    {
        public int MasterAboutId { get; set; }
     
        public string MasterAboutTitle { get; set; }    
        public string MasterAboutBrief { get; set; }   
        public string MasterAboutDesc { get; set; }
        public string MasterAboutUrl { get; set; }
        public string MasterAboutImageUrl { get; set; }
    }
}
