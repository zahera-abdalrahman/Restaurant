using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models;
using Resturant.Models.Repositores;
using Resturant.ViewModels;
using System.Collections.Generic;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TransactionContactUsController : Controller
    {
        public IRepository<TransactionContactUs> TransactionContactUs { get; }

        public TransactionContactUsController(IRepository<TransactionContactUs> _TransactionContactUs)
        {
            TransactionContactUs = _TransactionContactUs;
        }

        // GET: TransactionContactUsController
        public ActionResult Index()
        {
            var data = TransactionContactUs.View();
            List<TransactionContactUsModel> Masterlist = new List<TransactionContactUsModel>();
            for (int i = 0; i < data.Count; i++)
            {
                TransactionContactUsModel menu = new TransactionContactUsModel();
                menu.TransactionContactUsId = data[i].TransactionContactUsId;
                menu.TransactionContactUsFullName = data[i].TransactionContactUsFullName;
                menu.TransactionContactUsSubject = data[i].TransactionContactUsSubject;
                menu.TransactionContactUsEmail = data[i].TransactionContactUsEmail;
                menu.TransactionContactUsMessage = data[i].TransactionContactUsMessage;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);
            }
            return View(Masterlist);
        }

        // GET: TransactionContactUsController/Details/5
        public ActionResult Details(int id)
        {
            var data = TransactionContactUs.Find(id);

            TransactionContactUsModel menu = new TransactionContactUsModel();
            menu.TransactionContactUsId = data.TransactionContactUsId;
            menu.TransactionContactUsFullName = data.TransactionContactUsFullName;
            menu.TransactionContactUsSubject = data.TransactionContactUsSubject;
            menu.TransactionContactUsEmail = data.TransactionContactUsEmail;
            menu.TransactionContactUsMessage = data.TransactionContactUsMessage;

            return View(menu);
        }

        // GET: TransactionContactUsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionContactUsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionContactUsModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                var newMenu = new TransactionContactUs
                {
                    TransactionContactUsId = collection.TransactionContactUsId,
                    TransactionContactUsFullName = collection.TransactionContactUsFullName,
                    TransactionContactUsSubject = collection.TransactionContactUsSubject,
                    TransactionContactUsEmail = collection.TransactionContactUsEmail,
                    TransactionContactUsMessage = collection.TransactionContactUsMessage
                };
                TransactionContactUs.Add(newMenu);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = TransactionContactUs.Find(id);

            TransactionContactUsModel menu = new TransactionContactUsModel();
            menu.TransactionContactUsId = data.TransactionContactUsId;
            menu.TransactionContactUsFullName = data.TransactionContactUsFullName;
            menu.TransactionContactUsSubject = data.TransactionContactUsSubject;
            menu.TransactionContactUsEmail = data.TransactionContactUsEmail;
            menu.TransactionContactUsMessage = data.TransactionContactUsMessage;

            return View(menu);
        }

        // POST: TransactionContactUsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionContactUsModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                TransactionContactUs newMenu = new TransactionContactUs
                {
                    TransactionContactUsId = collection.TransactionContactUsId,
                    TransactionContactUsFullName = collection.TransactionContactUsFullName,
                    TransactionContactUsSubject = collection.TransactionContactUsSubject,
                    TransactionContactUsEmail = collection.TransactionContactUsEmail,
                    TransactionContactUsMessage = collection.TransactionContactUsMessage
                };
                TransactionContactUs.Update(id,newMenu);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionContactUsController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            TransactionContactUs.Delete(idDelete, new Models.TransactionContactUs());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, TransactionContactUsModel collection)
        {

            TransactionContactUs.Active(id, new Models.TransactionContactUs());
            return RedirectToAction(nameof(Index));
        }
    }
}
