using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resturant.Models.Repositores;
using Microsoft.AspNetCore.Hosting;
using Resturant.Models;
using Resturant.ViewModels;
using System.Collections.Generic;
using System.IO;
using System;
using System.Security.Claims;

namespace Resturant.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class CustomerController : Controller
    {

        public IRepository<Customer> Customer { get; }
        public IHostingEnvironment Host { get; }

        public CustomerController(IRepository<Customer> _Customer, IHostingEnvironment _Host)
        {
            Customer = _Customer;
            Host = _Host;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var data = Customer.View();
            List<CustomerModel> Masterlist = new List<CustomerModel>();
            for (int i = 0; i < data.Count; i++)
            {
                CustomerModel menu = new CustomerModel();
                menu.CustomerId = data[i].CustomerId;
                menu.CustomerDesc = data[i].CustomerDesc;
                menu.CustomerName = data[i].CustomerName;
                menu.CustomerPosition = data[i].CustomerPosition;
                menu.CustomerImage = data[i].CustomerImage;
                menu.IsActive = data[i].IsActive;
                Masterlist.Add(menu);

            }
            return View(Masterlist);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            var data = Customer.Find(id);
            CustomerModel menu = new CustomerModel();
            menu.CustomerId = data.CustomerId;
            menu.CustomerDesc = data.CustomerDesc;
            menu.CustomerName = data.CustomerName;
            menu.CustomerPosition = data.CustomerPosition;
            menu.CustomerImage = data.CustomerImage;
            menu.IsActive = data.IsActive;


            return View(menu);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerModel collection)
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
                var newMenu = new Customer
                {
                    CustomerId = collection.CustomerId,
                    CustomerDesc = collection.CustomerDesc,
                    CustomerName = collection.CustomerName,
                    CustomerPosition = collection.CustomerPosition,
                    CustomerImage = ImageName,
                    CreateDate = DateTime.UtcNow,
                    CreateId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive = true,
                    IsDelete = false
                };
                Customer.Add(newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Customer.Find(id);
            CustomerModel menu = new CustomerModel();
            menu.CustomerId = data.CustomerId;
            menu.CustomerDesc = data.CustomerDesc;
            menu.CustomerName = data.CustomerName;
            menu.CustomerPosition = data.CustomerPosition;
            menu.CustomerImage = data.CustomerImage;
            menu.IsActive = data.IsActive;


            return View(menu);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerModel collection)
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
                ImageName = collection.CustomerImage;
            }
            try
            {
                var newMenu = new Customer
                {
                    CustomerId = collection.CustomerId,
                    CustomerDesc = collection.CustomerDesc,
                    CustomerName = collection.CustomerName,
                    CustomerPosition = collection.CustomerPosition,
                    CustomerImage = ImageName,
                    EditDate = DateTime.UtcNow,
                    EditId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    IsActive=true
                };
                Customer.Update(id,newMenu);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int idDelete)
        {
            Customer.Delete(idDelete, new Models.Customer());

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Active(int id, CustomerModel collection)
        {

            Customer.Active(id, new Models.Customer());
            return RedirectToAction(nameof(Index));
        }
    }
}
