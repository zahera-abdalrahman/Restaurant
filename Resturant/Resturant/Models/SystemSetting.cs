﻿using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace Resturant.Models
{
    public  class SystemSetting : BaseEntity
    {
        public int SystemSettingId { get; set; }
        public string SystemSettingLogoImageUrl { get; set; }
        public string SystemSettingLogoImageUrl2 { get; set; }
        public string SystemSettingCopyright { get; set; }
        public string SystemSettingWelcomeNoteTitle { get; set; }
        public string SystemSettingWelcomeNoteBreef { get; set; }
        public string SystemSettingWelcomeNoteDesc { get; set; }
        public string SystemSettingWelcomeNoteUrl { get; set; }
        public string SystemSettingWelcomeNoteImageUrl { get; set; }
        public string SystemSettingWelcomeNoteImageUrl2 { get; set; }
        public string SystemSettingWelcomeNoteImageUrl3 { get; set; }
        public string SystemSettingWelcomeNoteImageUrl4 { get; set; }
        public string SystemSettingMapLocation { get; set; }
    }
}
