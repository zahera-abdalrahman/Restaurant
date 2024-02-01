using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Resturant.Models.Repositores;
using Resturant.Models;
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
    public class MasterSliderController : Controller
    {
        public IRepository<MasterSlider> MasterSlider { get; }
        public IHostingEnvironment Host { get; }

        public MasterSliderController(IRepository<MasterSlider> _MasterSlider, IHostingEnvironment _Host)
        {
            MasterSlider = _MasterSlider;
            Host = _Host;
        }


        // GET: MasterSliderController
        public ActionResult Index()
        {
            var data = MasterSlider.View();
            List<MasterSliderModel> Masterlist = new List<MasterSliderModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterSliderModel menu = new MasterSliderModel();
                menu.MasterSliderId = data[i].MasterSliderId;
                menu.MasterSliderTitle = data[i].MasterSliderTitle;
                menu.MasterSliderBreef = data[i].MasterSliderBreef;
                menu.MasterSliderDesc = data[i].MasterSliderDesc;
                menu.MasterSliderUrl = data[i].MasterSliderUrl;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: MasterSliderController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterSlider.Find(id);
            MasterSliderModel menu = new MasterSliderModel();
            menu.MasterSliderId = data.MasterSliderId;
            menu.MasterSliderTitle = data.MasterSliderTitle;
            menu.MasterSliderBreef = data.MasterSliderBreef;
            menu.MasterSliderDesc = data.MasterSliderDesc;
            menu.MasterSliderUrl = data.MasterSliderUrl;
            return View(menu);
        }

        // GET: MasterSliderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSliderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSliderModel collection)
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
                var newMenu = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderUrl = ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterSlider.Add(newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSlider.Find(id);
            MasterSliderModel menu = new MasterSliderModel();
            menu.MasterSliderId = data.MasterSliderId;
            menu.MasterSliderTitle = data.MasterSliderTitle;
            menu.MasterSliderBreef = data.MasterSliderBreef;
            menu.MasterSliderDesc = data.MasterSliderDesc;
            menu.MasterSliderUrl = data.MasterSliderUrl;
            return View(menu);
        }

        // POST: MasterSliderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSliderModel collection)
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
                ImageName = collection.MasterSliderUrl;
            }
            try
            {
                var newMenu = new MasterSlider
                {
                    MasterSliderId = collection.MasterSliderId,
                    MasterSliderTitle = collection.MasterSliderTitle,
                    MasterSliderBreef = collection.MasterSliderBreef,
                    MasterSliderDesc = collection.MasterSliderDesc,
                    MasterSliderUrl = ImageName,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterSlider.Update(id,newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSliderController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterSlider.Delete(idDelete, new Models.MasterSlider());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterSliderModel collection)
        {

            MasterSlider.Active(id, new Models.MasterSlider());
            return RedirectToAction(nameof(Index));
        }
    }
}
