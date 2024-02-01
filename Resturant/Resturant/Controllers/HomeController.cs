using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using Resturant.Areas.Admin.Controllers;
using Resturant.Models;
using Resturant.Models.Repositores;
using Resturant.ViewModels;
using System.Linq;

namespace Resturant.Controllers
{
    public class HomeController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }
        public IRepository<MasterSlider> MasterSlider { get; }
        public IRepository<SystemSetting> SystemSetting { get; }
        public IRepository<TransactionBookTable> TransactionBookTable { get; }
        public IRepository<MasterOffer> MasterOffer { get; }
        public IRepository<MasterService> MasterService { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<TransactionContactUs> TransactionContactUs { get; }
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }
        public IRepository<MasterPartner> MasterPartner { get; }
        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IRepository<Customer> Customer { get; }
        public IRepository<MasterAbout> MasterAbout { get; }

        public HomeController(
            IRepository<MasterMenu> _MasterMenu,
            IRepository<MasterSlider> _MasterSlider,
            IRepository<SystemSetting> _SystemSetting,
            IRepository<TransactionBookTable> _TransactionBookTable,
            IRepository<MasterOffer> _MasterOffer,
            IRepository<MasterService> _MasterService,
            IRepository<MasterCategoryMenu> _MasterCategoryMenu,
            IRepository<MasterItemMenu> _MasterItemMenu,
            IRepository<TransactionContactUs> _TransactionContactUs,
            IRepository<MasterSocialMedium> _MasterSocialMedium,
            IRepository<MasterWorkingHour> _MasterWorkingHour,
            IRepository<TransactionNewsletter> _TransactionNewsletter,
            IRepository<MasterPartner> _MasterPartner,
            IRepository<MasterContactUsInformation> _MasterContactUsInformation,
            IRepository<Customer> _Customer,
            IRepository<MasterAbout> _MasterAbout
            )
        
        {
            MasterMenu = _MasterMenu;
            MasterSlider = _MasterSlider;
            SystemSetting = _SystemSetting;
            TransactionBookTable = _TransactionBookTable;
            MasterOffer = _MasterOffer;
            MasterService = _MasterService;
            MasterCategoryMenu = _MasterCategoryMenu;
            MasterItemMenu = _MasterItemMenu;
            TransactionContactUs = _TransactionContactUs;
            MasterSocialMedium = _MasterSocialMedium;
            MasterWorkingHour = _MasterWorkingHour;
            TransactionNewsletter = _TransactionNewsletter;
            MasterPartner = _MasterPartner;
            MasterContactUsInformation = _MasterContactUsInformation;
            Customer = _Customer;
            MasterAbout = _MasterAbout;
        }


        public IActionResult Index()
        {
            HomeModel model = new HomeModel
            {
                SystemSetting = (SystemSetting.ViewClient().ToList().Count == 0 ? null : SystemSetting.ViewClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterMenuList = MasterMenu.ViewClient().ToList(),
                MasterSliderList = MasterSlider.ViewClient().ToList(),
                TransactionBookTableList = TransactionBookTable.ViewClient().ToList(),              
                MasterOffer=(MasterOffer.ViewClient().ToList().Count==0?null:MasterOffer.ViewClient().Take(1).OrderByDescending(data=>data.MasterOfferId).ToList().ElementAt(0)),
                MasterSocialMediumList = MasterSocialMedium.ViewClient().ToList(),
                MasterWorkingHourList = MasterWorkingHour.ViewClient().ToList(),
                TransactionNewsletterList = TransactionNewsletter.ViewClient().ToList(),
                MasterPartnerList=MasterPartner.ViewClient().ToList(),
                MasterContactUsInformationList = MasterContactUsInformation.ViewClient().ToList(),
                CustomerList=Customer.ViewClient().ToList(),
                LastFiveMasterItemMenu = MasterItemMenu.ViewClient().OrderByDescending(data => data.MasterCategoryMenuId).Take(5).ToList(),
                MasterAbout = (MasterAbout.ViewClient().ToList().Count == 0 ? null : MasterAbout.ViewClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0)),

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult book(HomeModel collection)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return RedirectToAction(nameof(Index));
            }

            try
            {

                TransactionBookTable Book = new TransactionBookTable();

                Book.TransactionBookTableId = collection.TransactionBookTableModel.TransactionBookTableId;
                Book.TransactionBookTableFullName = collection.TransactionBookTableModel.TransactionBookTableFullName;
                Book.TransactionBookTableEmail = collection.TransactionBookTableModel.TransactionBookTableEmail;
                Book.TransactionBookTableMobileNumber = collection.TransactionBookTableModel.TransactionBookTableMobileNumber;
                Book.TransactionBookTableDate = collection.TransactionBookTableModel.TransactionBookTableDate;
                Book.TransactionBookTableTime = collection.TransactionBookTableModel.TransactionBookTableTime;


                TransactionBookTable.Add(Book);


               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Newsletter(HomeModel collection)
        {
            try
            {
                var data = new TransactionNewsletter
                {
                    TransactionNewsletterId = collection.TransactionNewsletter.TransactionNewsletterId,
                    TransactionNewsletterEmail = collection.TransactionNewsletter.TransactionNewsletterEmail

                };
                TransactionNewsletter.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult About()
        {
            HomeModel model = new HomeModel
            {
                MasterMenuList = MasterMenu.ViewClient().ToList(),
                SystemSetting = (SystemSetting.ViewClient().ToList().Count == 0 ? null : SystemSetting.ViewClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterServiceList = MasterService.ViewClient().ToList(),
                MasterSocialMediumList = MasterSocialMedium.ViewClient().ToList(),
                MasterWorkingHourList = MasterWorkingHour.ViewClient().ToList(),
                MasterContactUsInformationList = MasterContactUsInformation.ViewClient().ToList(),
                MasterAbout = (MasterAbout.ViewClient().ToList().Count == 0 ? null : MasterAbout.ViewClient().Take(1).OrderByDescending(data => data.MasterAboutId).ToList().ElementAt(0))
            };
            return View(model);
        }


        public IActionResult Menu()
        {
            HomeModel model = new HomeModel
            {
                MasterMenuList = MasterMenu.ViewClient().ToList(),
                SystemSetting = (SystemSetting.ViewClient().ToList().Count == 0 ? null : SystemSetting.ViewClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterCategoryMenuList = MasterCategoryMenu.ViewClient().ToList(),
                MasterItemMenuList = MasterItemMenu.ViewClient().ToList(),
                MasterSocialMediumList = MasterSocialMedium.ViewClient().ToList(),
                MasterWorkingHourList = MasterWorkingHour.ViewClient().ToList(),
                MasterPartnerList = MasterPartner.ViewClient().ToList(),
                MasterContactUsInformationList=MasterContactUsInformation.ViewClient().ToList(),
            };
            return View(model);
        }


        public IActionResult ContactUs()
        {
            HomeModel model = new HomeModel
            {
                MasterMenuList = MasterMenu.ViewClient().ToList(),
                SystemSettingList = SystemSetting.ViewClient().ToList(),
                SystemSetting = (SystemSetting.ViewClient().ToList().Count == 0 ? null : SystemSetting.ViewClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                TransactionContactUsList = TransactionContactUs.ViewClient().ToList(),
                MasterSocialMediumList = MasterSocialMedium.ViewClient().ToList(),
                MasterWorkingHourList = MasterWorkingHour.ViewClient().ToList(),
                MasterContactUsInformationList = MasterContactUsInformation.ViewClient().ToList(),
            };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(HomeModel collection)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {

                var newMenu = new TransactionContactUs
                {
                    TransactionContactUsId = collection.TransactionContactUs.TransactionContactUsId,
                    TransactionContactUsFullName = collection.TransactionContactUs.TransactionContactUsFullName,
                    TransactionContactUsEmail = collection.TransactionContactUs.TransactionContactUsEmail,
                    TransactionContactUsSubject = collection.TransactionContactUs.TransactionContactUsSubject,
                    TransactionContactUsMessage = collection.TransactionContactUs.TransactionContactUsMessage
                };
                TransactionContactUs.Add(newMenu);
                return RedirectToAction(nameof(ContactUs));
            }
            catch
            {
                return RedirectToAction(nameof(ContactUs));
            }
        }

        public IActionResult ProductDetails(int id)
        {
            HomeModel model = new HomeModel
            {
                MasterMenuList = MasterMenu.ViewClient().ToList(),
                SystemSetting = (SystemSetting.ViewClient().ToList().Count == 0 ? null : SystemSetting.ViewClient().Take(1).OrderByDescending(data => data.SystemSettingId).ToList().ElementAt(0)),
                MasterSocialMediumList = MasterSocialMedium.ViewClient().ToList(),
                MasterWorkingHourList = MasterWorkingHour.ViewClient().ToList(),
                MasterContactUsInformationList = MasterContactUsInformation.ViewClient().ToList(),
                MasterItemMenu = MasterItemMenu.Find(id)
            };
            return View(model);
        }




    }
}
