using Microsoft.AspNetCore.Hosting;
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

    public class MasterContactUsInformationController : Controller
    {

        public IRepository<MasterContactUsInformation> MasterContactUsInformation { get; }
        public IHostingEnvironment Host { get; }

        public MasterContactUsInformationController(IRepository<MasterContactUsInformation> _MasterContactUsInformation, IHostingEnvironment _Host)
        {
            MasterContactUsInformation = _MasterContactUsInformation;
            Host = _Host;
        }
        // GET: MasterContactUsInformationController
        public ActionResult Index()
        {
            var data = MasterContactUsInformation.View();
            List<MasterContactUsInformationModel> Masterlist = new List<MasterContactUsInformationModel>();
            for (int i = 0; i < data.Count; i++)
            {
                MasterContactUsInformationModel menu = new MasterContactUsInformationModel();
                menu.MasterContactUsInformationId = data[i].MasterContactUsInformationId;
                menu.MasterContactUsInformationIdesc = data[i].MasterContactUsInformationIdesc;
                menu.MasterContactUsInformationImageUrl = data[i].MasterContactUsInformationImageUrl;
                menu.MasterContactUsInformationRedirect = data[i].MasterContactUsInformationRedirect;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }
        // GET: MasterContactUsInformationController/Details/5
        public ActionResult Details(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            MasterContactUsInformationModel menu = new MasterContactUsInformationModel();
            menu.MasterContactUsInformationId = data.MasterContactUsInformationId;
            menu.MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc;
            menu.MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl;
            menu.MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect;

            return View(menu);
        }

        // GET: MasterContactUsInformationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MasterContactUsInformationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MasterContactUsInformationModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                MasterContactUsInformation newMenu = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                MasterContactUsInformation.Add(newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = MasterContactUsInformation.Find(id);
            MasterContactUsInformationModel menu = new MasterContactUsInformationModel();
            menu.MasterContactUsInformationId = data.MasterContactUsInformationId;
            menu.MasterContactUsInformationIdesc = data.MasterContactUsInformationIdesc;
            menu.MasterContactUsInformationRedirect = data.MasterContactUsInformationRedirect;
            menu.MasterContactUsInformationImageUrl = data.MasterContactUsInformationImageUrl;
            return View(menu);
        }

        // POST: MasterContactUsInformationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MasterContactUsInformationModel collection)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {

                MasterContactUsInformation newMenu = new MasterContactUsInformation
                {
                    MasterContactUsInformationId = collection.MasterContactUsInformationId,
                    MasterContactUsInformationIdesc = collection.MasterContactUsInformationIdesc,
                    MasterContactUsInformationRedirect = collection.MasterContactUsInformationRedirect,
                    MasterContactUsInformationImageUrl = collection.MasterContactUsInformationImageUrl,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true
                };
                MasterContactUsInformation.Update(id, newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MasterContactUsInformationController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            MasterContactUsInformation.Delete(idDelete, new Models.MasterContactUsInformation());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, MasterContactUsInformationModel collection)
        {

            MasterContactUsInformation.Active(id, new Models.MasterContactUsInformation());
            return RedirectToAction(nameof(Index));
        }
    }
}
