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
    public class TransactionNewsletterController : Controller
    {
        public IRepository<TransactionNewsletter> TransactionNewsletter { get; }

        public TransactionNewsletterController(IRepository<TransactionNewsletter> _TransactionNewsletter)
        {
            TransactionNewsletter = _TransactionNewsletter;
        }
        // GET: TransactionNewsletterController
        public ActionResult Index()
        {
            var data = TransactionNewsletter.View();
            List<TransactionNewsletterModel> Masterlist = new List<TransactionNewsletterModel>();
            for (int i = 0; i < data.Count; i++)
            {
                TransactionNewsletterModel menu = new TransactionNewsletterModel();
               menu.TransactionNewsletterId= data[i].TransactionNewsletterId;
                menu.TransactionNewsletterEmail= data[i].TransactionNewsletterEmail;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);
            }
            return View(Masterlist);
        }

        // GET: TransactionNewsletterController/Details/5
        public ActionResult Details(int id)
        {
            var data = TransactionNewsletter.Find(id);
            TransactionNewsletterModel menu = new TransactionNewsletterModel();
            menu.TransactionNewsletterId = data.TransactionNewsletterId;
            menu.TransactionNewsletterEmail = data.TransactionNewsletterEmail;
            return View(menu);
        }

        // GET: TransactionNewsletterController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionNewsletterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionNewsletterModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                var newMenu = new TransactionNewsletter
                {
                    TransactionNewsletterId=collection.TransactionNewsletterId,
                    TransactionNewsletterEmail=collection.TransactionNewsletterEmail
                };
                TransactionNewsletter.Add(newMenu);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionNewsletterController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = TransactionNewsletter.Find(id);
            TransactionNewsletterModel menu = new TransactionNewsletterModel();
            menu.TransactionNewsletterId = data.TransactionNewsletterId;
            menu.TransactionNewsletterEmail = data.TransactionNewsletterEmail;
            return View(menu);
        }

        // POST: TransactionNewsletterController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,TransactionNewsletterModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                TransactionNewsletter newMenu = new TransactionNewsletter
                {
                    TransactionNewsletterId = collection.TransactionNewsletterId,
                    TransactionNewsletterEmail = collection.TransactionNewsletterEmail
                };
                TransactionNewsletter.Update(id,newMenu);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionNewsletterController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            TransactionNewsletter.Delete(idDelete, new Models.TransactionNewsletter());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, TransactionNewsletterModel collection)
        {

            TransactionNewsletter.Active(id, new Models.TransactionNewsletter());
            return RedirectToAction(nameof(Index));
        }
    }
}
