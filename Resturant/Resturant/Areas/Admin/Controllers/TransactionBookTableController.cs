using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Resturant.Models;
using Resturant.Models.Repositores;
using Resturant.ViewModels;
using System.Collections.Generic;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class TransactionBookTableController : Controller
    {
        public IRepository<TransactionBookTable> TransactionBookTable { get; }

        public TransactionBookTableController(IRepository<TransactionBookTable> _TransactionBookTable)
        {
            TransactionBookTable = _TransactionBookTable;
        }

        // GET: TransactionBookTableController
        public ActionResult Index()
        {
            var data = TransactionBookTable.View();
            List<TransactionBookTableModel> Masterlist = new List<TransactionBookTableModel>();
            for (int i = 0; i < data.Count; i++)
            {
                TransactionBookTableModel menu = new TransactionBookTableModel();
                menu.TransactionBookTableId = data[i].TransactionBookTableId;
                menu.TransactionBookTableFullName = data[i].TransactionBookTableFullName;
                menu.TransactionBookTableEmail = data[i].TransactionBookTableEmail;
                menu.TransactionBookTableMobileNumber = data[i].TransactionBookTableMobileNumber;
                menu.TransactionBookTableDate = data[i].TransactionBookTableDate;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: TransactionBookTableController/Details/5
        public ActionResult Details(int id)
        {
            var data = TransactionBookTable.Find(id);
            TransactionBookTableModel menu = new TransactionBookTableModel();
            menu.TransactionBookTableId = data.TransactionBookTableId;
            menu.TransactionBookTableFullName = data.TransactionBookTableFullName;
            menu.TransactionBookTableEmail = data.TransactionBookTableEmail;
            menu.TransactionBookTableMobileNumber = data.TransactionBookTableMobileNumber;
            menu.TransactionBookTableDate = data.TransactionBookTableDate;
            return View(menu);
        }

        // GET: TransactionBookTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionBookTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransactionBookTableModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                var newMenu = new TransactionBookTable
                {
                    TransactionBookTableId=collection.TransactionBookTableId,
                    TransactionBookTableFullName=collection.TransactionBookTableFullName,
                    TransactionBookTableEmail=collection.TransactionBookTableEmail,
                    TransactionBookTableMobileNumber=collection.TransactionBookTableMobileNumber,
                    TransactionBookTableDate=collection.TransactionBookTableDate
                };
                TransactionBookTable.Add(newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = TransactionBookTable.Find(id);
            TransactionBookTableModel menu = new TransactionBookTableModel();
            menu.TransactionBookTableId = data.TransactionBookTableId;
            menu.TransactionBookTableFullName = data.TransactionBookTableFullName;
            menu.TransactionBookTableEmail = data.TransactionBookTableEmail;
            menu.TransactionBookTableMobileNumber = data.TransactionBookTableMobileNumber;
            menu.TransactionBookTableDate = data.TransactionBookTableDate;
            return View(menu);
        }

        // POST: TransactionBookTableController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TransactionBookTableModel collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Data Not Completed");
                return View();
            }

            try
            {
                TransactionBookTable newMenu = new TransactionBookTable
                {
                    TransactionBookTableId = collection.TransactionBookTableId,
                    TransactionBookTableFullName = collection.TransactionBookTableFullName,
                    TransactionBookTableEmail = collection.TransactionBookTableEmail,
                    TransactionBookTableMobileNumber = collection.TransactionBookTableMobileNumber,
                    TransactionBookTableDate = collection.TransactionBookTableDate
                };
                TransactionBookTable.Update(id,newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransactionBookTableController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            TransactionBookTable.Delete(idDelete, new Models.TransactionBookTable());

            return RedirectToAction(nameof(Index));
        }



        public ActionResult Active(int id, TransactionBookTableModel collection)
        {

            TransactionBookTable.Active(id, new Models.TransactionBookTable());
            return RedirectToAction(nameof(Index));
        }
    }
}
