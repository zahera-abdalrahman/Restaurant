using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositores;
using Resturant.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Claims;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterPartnerController : Controller
    {
        public IRepository<MasterPartner> MasterPartner { get; }
        public IHostingEnvironment Host { get; }

        public MasterPartnerController(IRepository<MasterPartner> _MasterPartner, IHostingEnvironment _Host)
        {
            MasterPartner = _MasterPartner;
            Host = _Host;
        }

        // GET: MasterPartnerController
        public ActionResult Index()
        {
            var data = MasterPartner.View();
            List<MasterPartnerModel> Masterlist = new List<MasterPartnerModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterPartnerModel menu = new MasterPartnerModel();
                menu.MasterPartnerId = data[i].MasterPartnerId;
                menu.MasterPartnerName = data[i].MasterPartnerName;
                menu.MasterPartnerWebsiteUrl = data[i].MasterPartnerWebsiteUrl;
                menu.MasterPartnerLogoImageUrl = data[i].MasterPartnerLogoImageUrl;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: MasterPartnerController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterPartner.Find(id);
            MasterPartnerModel menu = new MasterPartnerModel();
            menu.MasterPartnerId = data.MasterPartnerId;
            menu.MasterPartnerName = data.MasterPartnerName;
            menu.MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl;
            menu.MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl;
            return View(menu);
        }

        // GET: MasterPartnerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterPartnerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterPartnerModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            string ImageName = "";
            if (collection.File != null)
            {
                string PathImage = Path.Combine(Host.WebRootPath, "images");
                FileInfo fi = new FileInfo(collection.File.FileName);
                ImageName = "Image" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(PathImage, ImageName);
                collection.File.CopyTo(new FileStream(fullPath, FileMode.Create));

            }
            try
            {
                MasterPartner menu = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    MasterPartnerLogoImageUrl = ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterPartner.Add(menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterPartner.Find(id);
            MasterPartnerModel menu = new MasterPartnerModel();
            menu.MasterPartnerId = data.MasterPartnerId;
            menu.MasterPartnerName = data.MasterPartnerName;
            menu.MasterPartnerWebsiteUrl = data.MasterPartnerWebsiteUrl;
            menu.MasterPartnerLogoImageUrl = data.MasterPartnerLogoImageUrl;
            return View(menu);
        }

        // POST: MasterPartnerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterPartnerModel collection)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            string ImageName = "";
            if (collection.File != null)
            {
                string PathImage = Path.Combine(Host.WebRootPath, "images");
                FileInfo fi = new FileInfo(collection.File.FileName);
                ImageName = "Image" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(PathImage, ImageName);
                collection.File.CopyTo(new FileStream(fullPath, FileMode.Create));

            }
            else
            {
                 ImageName= collection.MasterPartnerLogoImageUrl;
            }
            try
            {
                MasterPartner menu = new MasterPartner
                {
                    MasterPartnerId = collection.MasterPartnerId,
                    MasterPartnerName = collection.MasterPartnerName,
                    MasterPartnerWebsiteUrl = collection.MasterPartnerWebsiteUrl,
                    MasterPartnerLogoImageUrl = ImageName,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterPartner.Update(id,menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterPartnerController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterPartner.Delete(idDelete, new Models.MasterPartner());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterPartnerModel collection)
        {

            MasterPartner.Active(id, new Models.MasterPartner());
            return RedirectToAction(nameof(Index));
        }
    }
}
