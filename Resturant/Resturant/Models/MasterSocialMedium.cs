using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class MasterSocialMedium : BaseEntity
    {
        public int MasterSocialMediumId { get; set; }
        public string MasterSocialMediumImageUrl { get; set; }
        public string MasterSocialMediumUrl { get; set; }

        public string MasterSocialMediumName { get; set; }

    }
}
