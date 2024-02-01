using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class MasterPartner : BaseEntity
    {
        public int MasterPartnerId { get; set; }
        public string MasterPartnerName { get; set; }
        public string MasterPartnerLogoImageUrl { get; set; }
        public string MasterPartnerWebsiteUrl { get; set; }
    }
}
