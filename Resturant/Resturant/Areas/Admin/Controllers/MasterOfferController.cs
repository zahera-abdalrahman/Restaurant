using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Resturant.Models;
using Resturant.Models.Repositores;
using Resturant.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterOfferController : Controller
    {
        public IRepository<MasterOffer> MasterOffer { get; }
        public IHostingEnvironment Host { get; }
        public MasterOfferController(IRepository<MasterOffer> _MasterOffer, IHostingEnvironment _Host)
        {
            MasterOffer = _MasterOffer;
            Host = _Host;
        }

        // GET: MasterOfferController
        public ActionResult Index()
        {
            var data = MasterOffer.View();
            List<MasterOfferModel> Master = new List<MasterOfferModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterOfferModel menu = new MasterOfferModel();
                menu.MasterOfferId = data[i].MasterOfferId;
                menu.MasterOfferBreef= data[i].MasterOfferBreef;
                menu.MasterOfferDesc = data[i].MasterOfferDesc;
                menu.MasterOfferTitle = data[i].MasterOfferTitle;
                menu.MasterOfferImageUrl = data[i].MasterOfferImageUrl;
                menu.IsActive = data[i].IsActive;
                Master.Add(menu);
            }
            return View(Master);
        }

        // GET: MasterOfferController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterOffer.Find(id);
            MasterOfferModel menu = new MasterOfferModel();
            menu.MasterOfferId = data.MasterOfferId;
            menu.MasterOfferBreef = data.MasterOfferBreef;
            menu.MasterOfferDesc = data.MasterOfferDesc;
            menu.MasterOfferTitle = data.MasterOfferTitle;
            menu.MasterOfferImageUrl = data.MasterOfferImageUrl;
            return View(menu);
        }

        // GET: MasterOfferController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterOfferController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterOfferModel collection)
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
                MasterOffer newMenu = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferImageUrl=ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterOffer.Add(newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterOffer.Find(id);
            MasterOfferModel menu = new MasterOfferModel();
            menu.MasterOfferId = data.MasterOfferId;
            menu.MasterOfferBreef = data.MasterOfferBreef;
            menu.MasterOfferDesc = data.MasterOfferDesc;
            menu.MasterOfferTitle = data.MasterOfferTitle;
            menu.MasterOfferImageUrl = data.MasterOfferImageUrl;
            return View(menu);
        }

        // POST: MasterOfferController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterOfferModel collection)
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
                ImageName = collection.MasterOfferImageUrl;    
            }
            try
            {
                MasterOffer newMenu = new MasterOffer
                {
                    MasterOfferId = collection.MasterOfferId,
                    MasterOfferTitle = collection.MasterOfferTitle,
                    MasterOfferDesc = collection.MasterOfferDesc,
                    MasterOfferBreef = collection.MasterOfferBreef,
                    MasterOfferImageUrl = ImageName,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterOffer.Update(id,newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterOfferController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterOffer.Delete(idDelete, new Models.MasterOffer());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterOfferModel collection)
        {

            MasterOffer.Active(id, new Models.MasterOffer());
            return RedirectToAction(nameof(Index));
        }
    }
}
