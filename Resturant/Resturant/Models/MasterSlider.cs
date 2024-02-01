using System;
using System.Collections.Generic;

#nullable disable

namespace Resturant.Models
{
    public  class MasterSlider : BaseEntity
    {
        public int MasterSliderId { get; set; }
        public string MasterSliderTitle { get; set; }
        public string MasterSliderBreef { get; set; }
        public string MasterSliderDesc { get; set; }
        public string MasterSliderUrl { get; set; }
    }
}
