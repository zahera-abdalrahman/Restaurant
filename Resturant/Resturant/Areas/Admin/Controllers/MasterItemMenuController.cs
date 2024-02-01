using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositores;
using Resturant.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System;
using System.Security.Claims;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterItemMenuController : Controller
    {
        public IRepository<MasterItemMenu> MasterItemMenu { get; }
        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }
        public IHostingEnvironment Host { get; }

        public MasterItemMenuController(IRepository<MasterItemMenu> _MasterItemMenu, IRepository<MasterCategoryMenu> _MasterCategoryMenu, IHostingEnvironment _Host)
        {
            MasterItemMenu = _MasterItemMenu;
            MasterCategoryMenu = _MasterCategoryMenu;
            Host = _Host;
        }

        // GET: MasterItemMenuController
        public ActionResult Index()
        {
            var data = MasterItemMenu.View();
            List<MasterItemMenuModel> Masterlist = new List<MasterItemMenuModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterItemMenuModel menu = new MasterItemMenuModel();
                menu.MasterItemMenuId = data[i].MasterItemMenuId;
                menu.MasterCategoryMenuId = data[i].MasterCategoryMenuId;
                menu.MasterItemMenuTitle = data[i].MasterItemMenuTitle;
                menu.MasterItemMenuBreef = data[i].MasterItemMenuBreef;
                menu.MasterItemMenuDesc = data[i].MasterItemMenuDesc;
                menu.MasterItemMenuPrice = data[i].MasterItemMenuPrice;
                menu.MasterItemMenuImageUrl = data[i].MasterItemMenuImageUrl;
                menu.MasterItemMenuDate = data[i].MasterItemMenuDate;
                menu.IsActive = data[i].IsActive;
                menu.MasterCategoryMenu = MasterCategoryMenu.Find(data[i].MasterCategoryMenuId);
                Masterlist.Add(menu);
            }
            return View(Masterlist);
        }

        // GET: MasterItemMenuController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterItemMenu.Find(id);
            MasterItemMenuModel menu = new MasterItemMenuModel();
            menu.MasterItemMenuId = data.MasterItemMenuId;
            menu.MasterItemMenuTitle = data.MasterItemMenuTitle;
            menu.MasterItemMenuBreef = data.MasterItemMenuBreef;
            menu.MasterItemMenuDesc = data.MasterItemMenuDesc;
            menu.MasterItemMenuPrice = data.MasterItemMenuPrice;
            menu.MasterItemMenuImageUrl = data.MasterItemMenuImageUrl;
            menu.MasterItemMenuDate = data.MasterItemMenuDate;
            menu.MasterCategoryMenuId = data.MasterCategoryMenuId;
            menu.MasterCategoryMenu = MasterCategoryMenu.Find(data.MasterCategoryMenuId);
            return View(menu);
        }

        // GET: MasterItemMenuController/Create
        public ActionResult Create()
        {
            var data = new MasterItemMenuModel
            {
                ListCategory = MasterCategoryMenu.View()
            };
            return View(data);
        }

        // POST: MasterItemMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterItemMenuModel collection)
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
                MasterItemMenu menu = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = ImageName,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenu = MasterCategoryMenu.Find(collection.MasterCategoryMenuId),
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterItemMenu.Add(menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Edit/5
        public ActionResult Edit(int id)
        {

            var data = MasterItemMenu.Find(id);
            MasterItemMenuModel menu = new MasterItemMenuModel();
            menu.MasterItemMenuId = data.MasterItemMenuId;
            menu.MasterItemMenuTitle = data.MasterItemMenuTitle;
            menu.MasterItemMenuBreef = data.MasterItemMenuBreef;
            menu.MasterItemMenuDesc = data.MasterItemMenuDesc;
            menu.MasterItemMenuPrice = data.MasterItemMenuPrice;
            menu.MasterItemMenuImageUrl = data.MasterItemMenuImageUrl;
            menu.MasterItemMenuDate = data.MasterItemMenuDate;
            menu.MasterCategoryMenuId = data.MasterCategoryMenuId;
            menu.ListCategory = MasterCategoryMenu.View();
            return View(menu);
        }

        // POST: MasterItemMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterItemMenuModel collection)
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
                ImageName = collection.MasterItemMenuImageUrl;
            }
            try
            {
                MasterItemMenu menu = new MasterItemMenu
                {
                    MasterItemMenuId = collection.MasterItemMenuId,
                    MasterItemMenuTitle = collection.MasterItemMenuTitle,
                    MasterItemMenuBreef = collection.MasterItemMenuBreef,
                    MasterItemMenuDesc = collection.MasterItemMenuDesc,
                    MasterItemMenuPrice = collection.MasterItemMenuPrice,
                    MasterItemMenuImageUrl = ImageName,
                    MasterItemMenuDate = collection.MasterItemMenuDate,
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenu = MasterCategoryMenu.Find(collection.MasterCategoryMenuId),
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterItemMenu.Update(id, menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterItemMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterItemMenu.Delete(idDelete, new Models.MasterItemMenu());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterItemMenuModel collection)
        {

            MasterItemMenu.Active(id, new Models.MasterItemMenu());
            return RedirectToAction(nameof(Index));
        }
    }
}
