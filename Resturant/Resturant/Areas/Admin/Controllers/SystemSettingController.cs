using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Resturant.Models.Repositores;
using Resturant.Models;
using Resturant.ViewModels;
using System.Collections.Generic;
using System.IO;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Hosting.Internal;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SystemSettingController : Controller
    {
        public IRepository<SystemSetting> SystemSetting { get; }
        public IHostingEnvironment Host { get; }

        public SystemSettingController(IRepository<SystemSetting> _SystemSetting, IHostingEnvironment _Host)
        {
            SystemSetting = _SystemSetting;
            Host = _Host;
        }

        // GET: SystemSettingController
        public ActionResult Index()
        {
            var data = SystemSetting.View();
            List<SystemSettingModel> Masterlist = new List<SystemSettingModel>();
            for (int i = 0; i < data.Count; i++)
            {
                SystemSettingModel menu = new SystemSettingModel();
                menu.SystemSettingId = data[i].SystemSettingId;
                menu.SystemSettingLogoImageUrl = data[i].SystemSettingLogoImageUrl;
                menu.SystemSettingLogoImageUrl2 = data[i].SystemSettingLogoImageUrl2;
                menu.SystemSettingCopyright = data[i].SystemSettingCopyright;
                menu.SystemSettingWelcomeNoteTitle = data[i].SystemSettingWelcomeNoteTitle;
                menu.SystemSettingWelcomeNoteBreef = data[i].SystemSettingWelcomeNoteBreef;
                menu.SystemSettingWelcomeNoteDesc = data[i].SystemSettingWelcomeNoteDesc;
                menu.SystemSettingWelcomeNoteUrl = data[i].SystemSettingWelcomeNoteUrl;
                menu.SystemSettingWelcomeNoteImageUrl = data[i].SystemSettingWelcomeNoteImageUrl;
                menu.SystemSettingWelcomeNoteImageUrl2 = data[i].SystemSettingWelcomeNoteImageUrl2;
                menu.SystemSettingWelcomeNoteImageUrl3 = data[i].SystemSettingWelcomeNoteImageUrl3;
                menu.SystemSettingWelcomeNoteImageUrl4 = data[i].SystemSettingWelcomeNoteImageUrl4;
                menu.SystemSettingMapLocation = data[i].SystemSettingMapLocation;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: SystemSettingController/Details/5
        public ActionResult Details(int id)
        {
            var data = SystemSetting.Find(id);
            SystemSettingModel menu = new SystemSettingModel();
            menu.SystemSettingId = data.SystemSettingId;
            menu.SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl;
            menu.SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2;
            menu.SystemSettingCopyright = data.SystemSettingCopyright;
            menu.SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle;
            menu.SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef;
            menu.SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc;
            menu.SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl;
            menu.SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl;
            menu.SystemSettingWelcomeNoteImageUrl2 = data.SystemSettingWelcomeNoteImageUrl2;
            menu.SystemSettingWelcomeNoteImageUrl3 = data.SystemSettingWelcomeNoteImageUrl3;
            menu.SystemSettingWelcomeNoteImageUrl4 = data.SystemSettingWelcomeNoteImageUrl4;
            menu.SystemSettingMapLocation = data.SystemSettingMapLocation;
            return View(menu);
        }

        // GET: SystemSettingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystemSettingController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SystemSettingModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            try
            {
                string logo1 = "", logo2 = "", imageName1 = "", imageName2 = "", imageName3 = "", imageName4 = "";
                string imagePath = Path.Combine(Host.WebRootPath, "images/SystemSitting");
                FileInfo fi;
                if (collection.LogoOne != null)
                {
                    fi = new FileInfo(collection.LogoOne.FileName);
                    logo1 = "logo1" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                    string fullPath = Path.Combine(imagePath, logo1);
                    collection.LogoOne.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (collection.LogoTwo != null)
                {
                    fi = new FileInfo(collection.LogoTwo.FileName);
                    logo2 = "logo2" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                    string fullPath = Path.Combine(imagePath, logo2);
                    collection.LogoTwo.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (collection.FileOne != null)
                {
                    fi = new FileInfo(collection.FileOne.FileName);
                    imageName1 = "image1" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                    string fullPath = Path.Combine(imagePath, imageName1);
                    collection.FileOne.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (collection.FileTwo != null)
                {
                    fi = new FileInfo(collection.FileTwo.FileName);
                    imageName2 = "image2" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                    string fullPath = Path.Combine(imagePath, imageName2);
                    collection.FileTwo.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (collection.FileThree != null)
                {
                    fi = new FileInfo(collection.FileThree.FileName);
                    imageName3 = "image3" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                    string fullPath = Path.Combine(imagePath, imageName3);
                    collection.FileThree.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                if (collection.FileFour != null)
                {
                    fi = new FileInfo(collection.FileFour.FileName);
                    imageName4 = "image4" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                    string fullPath = Path.Combine(imagePath, imageName4);
                    collection.FileFour.CopyTo(new FileStream(fullPath, FileMode.Create));
                }
                SystemSetting data = new SystemSetting()
                {
                    SystemSettingId=collection.SystemSettingId,
                    SystemSettingLogoImageUrl =logo1,
                    SystemSettingLogoImageUrl2 =logo2,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = imageName1,
                    SystemSettingWelcomeNoteImageUrl2 = imageName2,
                    SystemSettingWelcomeNoteImageUrl3 = imageName3,
                    SystemSettingWelcomeNoteImageUrl4 = imageName4,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                SystemSetting.Add(data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = SystemSetting.Find(id);
            SystemSettingModel menu = new SystemSettingModel();
            menu.SystemSettingId = data.SystemSettingId;
            menu.SystemSettingLogoImageUrl = data.SystemSettingLogoImageUrl;
            menu.SystemSettingLogoImageUrl2 = data.SystemSettingLogoImageUrl2;
            menu.SystemSettingCopyright = data.SystemSettingCopyright;
            menu.SystemSettingWelcomeNoteTitle = data.SystemSettingWelcomeNoteTitle;
            menu.SystemSettingWelcomeNoteBreef = data.SystemSettingWelcomeNoteBreef;
            menu.SystemSettingWelcomeNoteDesc = data.SystemSettingWelcomeNoteDesc;
            menu.SystemSettingWelcomeNoteUrl = data.SystemSettingWelcomeNoteUrl;
            menu.SystemSettingWelcomeNoteImageUrl = data.SystemSettingWelcomeNoteImageUrl;
            menu.SystemSettingWelcomeNoteImageUrl2 = data.SystemSettingWelcomeNoteImageUrl2;
            menu.SystemSettingWelcomeNoteImageUrl3 = data.SystemSettingWelcomeNoteImageUrl3;
            menu.SystemSettingWelcomeNoteImageUrl4 = data.SystemSettingWelcomeNoteImageUrl4;
            menu.SystemSettingMapLocation = data.SystemSettingMapLocation;
            menu.IsActive= data.IsActive;
            return View(menu);
        }

        // POST: SystemSettingController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SystemSettingModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            string logo1 = "", logo2 = "", imageName1 = "", imageName2 = "", imageName3 = "", imageName4 = "";
            string imagePath = Path.Combine(Host.WebRootPath, "images/SystemSitting");
            FileInfo fi;
            if (collection.LogoOne != null)
            {
                fi = new FileInfo(collection.LogoOne.FileName);
                logo1 = "logo1" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(imagePath, logo1);
                collection.LogoOne.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                logo1 = collection.SystemSettingLogoImageUrl;
            }
            if (collection.LogoTwo != null)
            {
                fi = new FileInfo(collection.LogoTwo.FileName);
                logo2 = "logo2" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(imagePath, logo2);
                collection.LogoTwo.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                logo2 = collection.SystemSettingLogoImageUrl2;
            }
            if (collection.FileOne != null)
            {
                fi = new FileInfo(collection.FileOne.FileName);
                imageName1 = "image1" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(imagePath, imageName1);
                collection.FileOne.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                imageName1 = collection.SystemSettingWelcomeNoteImageUrl;
            }
            if (collection.FileTwo != null)
            {
                fi = new FileInfo(collection.FileTwo.FileName);
                imageName2 = "image2" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(imagePath, imageName2);
                collection.FileTwo.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                imageName2 = collection.SystemSettingWelcomeNoteImageUrl2;
            }
            if (collection.FileThree != null)
            {
                fi = new FileInfo(collection.FileThree.FileName);
                imageName3 = "image3" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(imagePath, imageName3);
                collection.FileThree.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                imageName3 = collection.SystemSettingWelcomeNoteImageUrl3;
            }
            if (collection.FileFour != null)
            {
                fi = new FileInfo(collection.FileFour.FileName);
                imageName4 = "image4" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(imagePath, imageName4);
                collection.FileFour.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            else
            {
                imageName4 = collection.SystemSettingWelcomeNoteImageUrl4;
            }
            try
            {
              
                SystemSetting data = new SystemSetting()
                {
                    SystemSettingId = collection.SystemSettingId,
                    SystemSettingLogoImageUrl = logo1,
                    SystemSettingLogoImageUrl2 = logo2,
                    SystemSettingCopyright = collection.SystemSettingCopyright,
                    SystemSettingWelcomeNoteTitle = collection.SystemSettingWelcomeNoteTitle,
                    SystemSettingWelcomeNoteBreef = collection.SystemSettingWelcomeNoteBreef,
                    SystemSettingWelcomeNoteDesc = collection.SystemSettingWelcomeNoteDesc,
                    SystemSettingWelcomeNoteUrl = collection.SystemSettingWelcomeNoteUrl,
                    SystemSettingWelcomeNoteImageUrl = imageName1,
                    SystemSettingWelcomeNoteImageUrl2 = imageName2,
                    SystemSettingWelcomeNoteImageUrl3 = imageName3,
                    SystemSettingWelcomeNoteImageUrl4 = imageName4,
                    SystemSettingMapLocation = collection.SystemSettingMapLocation,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                };
                SystemSetting.Update(id, data);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SystemSettingController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            SystemSetting.Delete(idDelete, new Models.SystemSetting());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, SystemSettingModel collection)
        {

            SystemSetting.Active(id, new Models.SystemSetting());
            return RedirectToAction(nameof(Index));
        }
    }
}

