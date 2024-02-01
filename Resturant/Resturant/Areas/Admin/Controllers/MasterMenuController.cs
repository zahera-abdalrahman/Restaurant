using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositores;
using Resturant.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterMenuController : Controller
    {
        public IRepository<MasterMenu> MasterMenu { get; }

        public MasterMenuController(IRepository<MasterMenu> _MasterMenu)
        {
            MasterMenu = _MasterMenu;
        }
        // GET: MasterMenuController
        public ActionResult Index()
        {
            var data = MasterMenu.View();
            List<MasterMenuModel> Masterlist = new List<MasterMenuModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterMenuModel menu = new MasterMenuModel();
                menu.MasterMenuId = data[i].MasterMenuId;
                menu.MasterMenuName = data[i].MasterMenuName;
                menu.MasterMenuUrl = data[i].MasterMenuUrl;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);
            }
            return View(Masterlist);
        }

        // GET: MasterMenuController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterMenu.Find(id);

            MasterMenuModel menu = new MasterMenuModel();
            menu.MasterMenuId = data.MasterMenuId;
            menu.MasterMenuName = data.MasterMenuName;
            menu.MasterMenuUrl = data.MasterMenuUrl;
            return View(menu);
        }

        // GET: MasterMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterMenuModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            try
            {
                var newMenu = new MasterMenu
                {
                   MasterMenuId=collection.MasterMenuId,
                   MasterMenuName=collection.MasterMenuName,
                   MasterMenuUrl=collection.MasterMenuUrl,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterMenu.Add(newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterMenu.Find(id);
            MasterMenuModel menu = new MasterMenuModel();
            menu.MasterMenuId=data.MasterMenuId;
            menu.MasterMenuName=data.MasterMenuName;
            menu.MasterMenuUrl=data.MasterMenuUrl;
            return View(menu);
        }

        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterMenuModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            try
            {
                MasterMenu newMenu = new MasterMenu
                {
                    MasterMenuId = collection.MasterMenuId,
                    MasterMenuName = collection.MasterMenuName,
                    MasterMenuUrl = collection.MasterMenuUrl,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterMenu.Update(id,newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterMenu.Delete(idDelete, new Models.MasterMenu());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterMenuModel collection)
        {

            MasterMenu.Active(id, new Models.MasterMenu());
            return RedirectToAction(nameof(Index));
        }
    }
}
