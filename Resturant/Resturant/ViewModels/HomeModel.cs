using Resturant.Models;
using System.Collections.Generic;

namespace Resturant.ViewModels
{
    public class HomeModel
    {

        public List<MasterSocialMedium> MasterSocialMediumList { get; set; }

        public List<MasterWorkingHour> MasterWorkingHourList { get; set; }

        public List<TransactionNewsletter> TransactionNewsletterList { get; set; }


        public List<SystemSetting> SystemSettingList { get; set; }

        public SystemSetting SystemSetting { get; set; }
        public List<MasterContactUsInformation> MasterContactUsInformationList { get; set; }

        public List<MasterMenu> MasterMenuList { get; set; }

        public List<MasterSlider> MasterSliderList { get; set; }    
        public List<TransactionBookTable> TransactionBookTableList { get; set; }
        public List<MasterPartner> MasterPartnerList { get; set; }

        public MasterOffer MasterOffer { get; set; }
        public List<Customer> CustomerList { get; set; }
        public List<MasterService> MasterServiceList { get; set; }
        public List<MasterCategoryMenu> MasterCategoryMenuList { get; set; }

        public List<MasterItemMenu> MasterItemMenuList { get; set; }
        public List<MasterItemMenu> LastFiveMasterItemMenu { get; set; }
        public List<TransactionContactUs> TransactionContactUsList { get; set; }

        public TransactionBookTableModel TransactionBookTableModel { get; set; }
        public TransactionNewsletterModel TransactionNewsletter { get; set; }
        public TransactionContactUs TransactionContactUs { get; set; }

        public MasterAbout MasterAbout { get; set; }
        public MasterItemMenu MasterItemMenu { get; set; }




    }
}
