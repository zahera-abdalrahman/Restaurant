using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models.Repositores;
using Resturant.Models;
using Microsoft.AspNetCore.Hosting;
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
    public class MasterServiceController : Controller
    {
        public IRepository<MasterService> MasterService { get; }
        public IHostingEnvironment Host { get; }

        public MasterServiceController(IRepository<MasterService> _MasterService, IHostingEnvironment _Host)
        {
            MasterService = _MasterService;
            Host = _Host;
        }
        // GET: MasterServiceController
        public ActionResult Index()
        {
            var data = MasterService.View();
            List<MasterServiceModel> Masterlist = new List<MasterServiceModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterServiceModel menu = new MasterServiceModel();
                menu.MasterServiceId = data[i].MasterServiceId;
                menu.MasterServiceTitle = data[i].MasterServiceTitle;
                menu.MasterServiceDesc = data[i].MasterServiceDesc;
                menu.MasterServiceImage = data[i].MasterServiceImage;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: MasterServiceController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterService.Find(id);
            MasterServiceModel menu = new MasterServiceModel();
            menu.MasterServiceId = data.MasterServiceId;
            menu.MasterServiceTitle = data.MasterServiceTitle;
            menu.MasterServiceDesc = data.MasterServiceDesc;
            menu.MasterServiceImage = data.MasterServiceImage;
            return View(menu);
        }

        // GET: MasterServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterServiceModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }           
            try
            {
                MasterService menu = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServiceTitle = collection.MasterServiceTitle,
                    MasterServiceDesc = collection.MasterServiceDesc,
                    MasterServiceImage = collection.MasterServiceImage,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterService.Add(menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterService.Find(id);
            MasterServiceModel menu = new MasterServiceModel();
            menu.MasterServiceId = data.MasterServiceId;
            menu.MasterServiceTitle = data.MasterServiceTitle;
            menu.MasterServiceDesc = data.MasterServiceDesc;
            menu.MasterServiceImage = data.MasterServiceImage;
            return View(menu);
        }

        // POST: MasterServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterServiceModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }         
            try
            {
                MasterService menu = new MasterService
                {
                    MasterServiceId = collection.MasterServiceId,
                    MasterServiceTitle = collection.MasterServiceTitle,
                    MasterServiceDesc = collection.MasterServiceDesc,
                    MasterServiceImage = collection.MasterServiceImage,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterService.Update(id,menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterServiceController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterService.Delete(idDelete, new Models.MasterService());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterServiceModel collection)
        {

            MasterService.Active(id, new Models.MasterService());
            return RedirectToAction(nameof(Index));
        }
    }
}
