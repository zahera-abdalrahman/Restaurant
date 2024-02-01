using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Resturant.Models.Repositores;
using Resturant.Models;
using Resturant.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class MasterWorkingHourController : Controller
    {
        public IRepository<MasterWorkingHour> MasterWorkingHour { get; }

        public MasterWorkingHourController(IRepository<MasterWorkingHour> _MasterWorkingHour)
        {
            MasterWorkingHour = _MasterWorkingHour;
        }

        // GET: MasterWorkingHourController
        public ActionResult Index()
        {
            var data = MasterWorkingHour.View();
            List<MasterWorkingHourModel> Masterlist = new List<MasterWorkingHourModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterWorkingHourModel menu = new MasterWorkingHourModel();
                menu.MasterWorkingHourId = data[i].MasterWorkingHourId;
                menu.MasterWorkingHourIdName = data[i].MasterWorkingHourIdName;
                menu.MasterWorkingHourIdTimeFormTo = data[i].MasterWorkingHourIdTimeFormTo;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: MasterWorkingHourController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterWorkingHour.Find(id);
            MasterWorkingHourModel menu = new MasterWorkingHourModel();
            menu.MasterWorkingHourId = data.MasterWorkingHourId;
            menu.MasterWorkingHourIdName = data.MasterWorkingHourIdName;
            menu.MasterWorkingHourIdTimeFormTo = data.MasterWorkingHourIdTimeFormTo;
            return View(menu);
        }

        // GET: MasterWorkingHourController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterWorkingHourController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterWorkingHourModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            try
            {
                MasterWorkingHour menu = new MasterWorkingHour
                {
                    MasterWorkingHourId = collection.MasterWorkingHourId,
                    MasterWorkingHourIdName = collection.MasterWorkingHourIdName,
                    MasterWorkingHourIdTimeFormTo = collection.MasterWorkingHourIdTimeFormTo,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterWorkingHour.Add(menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterWorkingHour.Find(id);
            MasterWorkingHourModel menu = new MasterWorkingHourModel();
            menu.MasterWorkingHourId = data.MasterWorkingHourId;
            menu.MasterWorkingHourIdName = data.MasterWorkingHourIdName;
            menu.MasterWorkingHourIdTimeFormTo = data.MasterWorkingHourIdTimeFormTo;
            return View(menu);
        }

        // POST: MasterWorkingHourController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterWorkingHourModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }
            try
            {
                MasterWorkingHour menu = new MasterWorkingHour
                {
                    MasterWorkingHourId = collection.MasterWorkingHourId,
                    MasterWorkingHourIdName = collection.MasterWorkingHourIdName,
                    MasterWorkingHourIdTimeFormTo = collection.MasterWorkingHourIdTimeFormTo,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterWorkingHour.Update(id,menu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterWorkingHourController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterWorkingHour.Delete(idDelete, new Models.MasterWorkingHour());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterWorkingHourModel collection)
        {

            MasterWorkingHour.Active(id, new Models.MasterWorkingHour());
            return RedirectToAction(nameof(Index));
        }
    }
}
