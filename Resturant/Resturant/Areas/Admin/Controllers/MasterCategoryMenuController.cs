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

    public class MasterCategoryMenuController : Controller
    {

        public IRepository<MasterCategoryMenu> MasterCategoryMenu { get; }

        public MasterCategoryMenuController(IRepository<MasterCategoryMenu> _MasterCategoryMenu)
        {
            MasterCategoryMenu = _MasterCategoryMenu;
        }
        // GET: MasterCategoryMenuController
        public ActionResult Index()
        {
            var data = MasterCategoryMenu.View();
            List<MasterCategoryMenuModel> Masterlist = new List<MasterCategoryMenuModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterCategoryMenuModel menu = new MasterCategoryMenuModel();
                menu.MasterCategoryMenuId = data[i].MasterCategoryMenuId;
                menu.MasterCategoryMenuName = data[i].MasterCategoryMenuName;
                menu.IsActive = data[i].IsActive;               
                Masterlist.Add(menu);
            }
            return View(Masterlist);
        }
        // GET: MasterCategoryMenuController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterCategoryMenu.Find(id);
            MasterCategoryMenuModel menu = new MasterCategoryMenuModel();
            menu.MasterCategoryMenuId = data.MasterCategoryMenuId;
            menu.MasterCategoryMenuName = data.MasterCategoryMenuName;
            return View(menu);
        }
        // GET: MasterCategoryMenuController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterCategoryMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterCategoryMenuModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                var newMenu = new MasterCategoryMenu
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenuName = collection.MasterCategoryMenuName,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterCategoryMenu.Add(newMenu);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }
        // GET: MasterCategoryMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterCategoryMenu.Find(id);
            MasterCategoryMenuModel menu = new MasterCategoryMenuModel();
            menu.MasterCategoryMenuId = data.MasterCategoryMenuId;
            menu.MasterCategoryMenuName = data.MasterCategoryMenuName;
            menu.IsActive = data.IsActive;
            menu.IsDelete = data.IsDelete;
            menu.EditDate = data.EditDate;
            menu.EditDate = data.EditDate;
            return View(menu);
        }

        // POST: MasterCategoryMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterCategoryMenuModel collection)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            try
            {
                MasterCategoryMenu newMenu = new MasterCategoryMenu
                {
                    MasterCategoryMenuId = collection.MasterCategoryMenuId,
                    MasterCategoryMenuName = collection.MasterCategoryMenuName,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };

                MasterCategoryMenu.Update(id, newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterCategoryMenuController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterCategoryMenu.Delete(idDelete, new Models.MasterCategoryMenu());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterCategoryMenuModel collection)
        {

            MasterCategoryMenu.Active(id, new Models.MasterCategoryMenu());
            return RedirectToAction(nameof(Index));
        }



    }
}
