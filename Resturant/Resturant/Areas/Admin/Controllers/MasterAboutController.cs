using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models.Repositores;
using Resturant.Models;
using Microsoft.AspNetCore.Hosting;
using Resturant.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System;
using System.Security.Claims;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterAboutController : Controller
    {


        public IRepository<MasterAbout> MasterAbout { get; }
        public IHostingEnvironment Host { get; }
        public MasterAboutController(IRepository<MasterAbout> _MasterAbout, IHostingEnvironment _Host)
        {
            MasterAbout = _MasterAbout;
            Host = _Host;
        }

        // GET: MasterAboutController
        public ActionResult Index()
        {
            var data = MasterAbout.View();
            List<MasterAboutModel> Master = new List<MasterAboutModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterAboutModel menu = new MasterAboutModel();
                menu.MasterAboutId = data[i].MasterAboutId;
                menu.MasterAboutDesc = data[i].MasterAboutDesc;
                menu.MasterAboutTitle = data[i].MasterAboutTitle;
                menu.MasterAboutBrief = data[i].MasterAboutBrief;
                menu.MasterAboutUrl = data[i].MasterAboutUrl;
                menu.MasterAboutImageUrl = data[i].MasterAboutImageUrl;
                menu.IsActive = data[i].IsActive;
                Master.Add(menu);
            }
            return View(Master);
        }

        // GET: MasterAboutController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterAbout.Find(id);
            MasterAboutModel menu = new MasterAboutModel();
            menu.MasterAboutId = data.MasterAboutId;
            menu.MasterAboutDesc = data.MasterAboutDesc;
            menu.MasterAboutTitle = data.MasterAboutTitle;
            menu.MasterAboutBrief = data.MasterAboutBrief;
            menu.MasterAboutUrl = data.MasterAboutUrl;
            menu.MasterAboutImageUrl = data.MasterAboutImageUrl;
            menu.IsActive = data.IsActive;
            return View(menu);
        }

        // GET: MasterAboutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterAboutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterAboutModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            string ImageNameabout = "";
            if (collection.File != null)
            {
                string PathImage = Path.Combine(Host.WebRootPath, "images");
                FileInfo fi = new FileInfo(collection.File.FileName);
                ImageNameabout = "Imageabout" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(PathImage, ImageNameabout);
                collection.File.CopyTo(new FileStream(fullPath, FileMode.Create));

            }

            try
            {
                MasterAbout newMenu = new MasterAbout
                {
                    MasterAboutId= collection.MasterAboutId,
                    MasterAboutDesc = collection.MasterAboutDesc,
                    MasterAboutTitle = collection.MasterAboutTitle,
                    MasterAboutBrief = collection.MasterAboutBrief,
                    MasterAboutUrl = collection.MasterAboutUrl,
                    MasterAboutImageUrl = ImageNameabout,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterAbout.Add(newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterAboutController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterAbout.Find(id);
            MasterAboutModel menu = new MasterAboutModel();
            menu.MasterAboutId = data.MasterAboutId;
            menu.MasterAboutDesc = data.MasterAboutDesc;
            menu.MasterAboutTitle = data.MasterAboutTitle;
            menu.MasterAboutBrief = data.MasterAboutBrief;
            menu.MasterAboutUrl = data.MasterAboutUrl;
            menu.MasterAboutImageUrl = data.MasterAboutImageUrl;
            menu.IsActive = data.IsActive;
            return View(menu);
        }

        // POST: MasterAboutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterAboutModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            string ImageNameabout = "";
            if (collection.File != null)
            {
                string PathImage = Path.Combine(Host.WebRootPath, "images");
                FileInfo fi = new FileInfo(collection.File.FileName);
                ImageNameabout = "Imageabout" + DateTime.UtcNow.ToString().Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "") + fi.Extension;
                string fullPath = Path.Combine(PathImage, ImageNameabout);
                collection.File.CopyTo(new FileStream(fullPath, FileMode.Create));

            }
            else
            {
                ImageNameabout = collection.MasterAboutImageUrl;
            }
            try
            {
                MasterAbout newMenu = new MasterAbout
                {
                    MasterAboutId = collection.MasterAboutId,
                    MasterAboutDesc = collection.MasterAboutDesc,
                    MasterAboutTitle = collection.MasterAboutTitle,
                    MasterAboutBrief = collection.MasterAboutBrief,
                    MasterAboutUrl = collection.MasterAboutUrl,
                    MasterAboutImageUrl = ImageNameabout,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterAbout.Update(id,newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterAboutController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterAbout.Delete(idDelete, new Models.MasterAbout());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterAboutModel collection)
        {

            MasterAbout.Active(id, new Models.MasterAbout());
            return RedirectToAction(nameof(Index));
        }
    }
}
