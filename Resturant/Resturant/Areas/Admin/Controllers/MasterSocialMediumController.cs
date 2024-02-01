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

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterSocialMediumController : Controller
    {
        public IRepository<MasterSocialMedium> MasterSocialMedium { get; }
        public IHostingEnvironment Host { get; }

        public MasterSocialMediumController(IRepository<MasterSocialMedium> _MasterSocialMedium, IHostingEnvironment _Host)
        {
            MasterSocialMedium = _MasterSocialMedium;
            Host = _Host;
        }

        // GET: MasterSocialMediumController
        public ActionResult Index()
        {
            var data = MasterSocialMedium.View();
            List<MasterSocialMediumModel> Masterlist = new List<MasterSocialMediumModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterSocialMediumModel menu = new MasterSocialMediumModel();
                menu.MasterSocialMediumId = data[i].MasterSocialMediumId;
                menu.MasterSocialMediumUrl = data[i].MasterSocialMediumUrl;
                menu.MasterSocialMediumImageUrl = data[i].MasterSocialMediumImageUrl;
                menu.MasterSocialMediumName = data[i].MasterSocialMediumName;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: MasterSocialMediumController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterSocialMedium.Find(id);
            MasterSocialMediumModel menu = new MasterSocialMediumModel();
            menu.MasterSocialMediumId = data.MasterSocialMediumId;
            menu.MasterSocialMediumUrl = data.MasterSocialMediumUrl;
            menu.MasterSocialMediumImageUrl = data.MasterSocialMediumImageUrl;
            menu.MasterSocialMediumName = data.MasterSocialMediumName;
            return View(menu);
        }

        // GET: MasterSocialMediumController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterSocialMediumController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterSocialMediumModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                var menu = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediumUrl = collection.MasterSocialMediumUrl,
                    MasterSocialMediumImageUrl = collection.MasterSocialMediumImageUrl,
                    MasterSocialMediumName = collection.MasterSocialMediumName,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterSocialMedium.Add(menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterSocialMedium.Find(id);
            MasterSocialMediumModel menu = new MasterSocialMediumModel();
            menu.MasterSocialMediumId = data.MasterSocialMediumId;
            menu.MasterSocialMediumUrl = data.MasterSocialMediumUrl;
            menu.MasterSocialMediumImageUrl = data.MasterSocialMediumImageUrl;
            menu.MasterSocialMediumName = data.MasterSocialMediumName;
            return View(menu);
        }

        // POST: MasterSocialMediumController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterSocialMediumModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                var newmenu = new MasterSocialMedium
                {
                    MasterSocialMediumId = collection.MasterSocialMediumId,
                    MasterSocialMediumUrl = collection.MasterSocialMediumUrl,
                    MasterSocialMediumImageUrl = collection.MasterSocialMediumImageUrl,
                    MasterSocialMediumName = collection.MasterSocialMediumName,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true

                };
                MasterSocialMedium.Update(id, newmenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterSocialMediumController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterSocialMedium.Delete(idDelete, new Models.MasterSocialMedium());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterSocialMediumModel collection)
        {

            MasterSocialMedium.Active(id, new Models.MasterSocialMedium());
            return RedirectToAction(nameof(Index));
        }
    }
}
