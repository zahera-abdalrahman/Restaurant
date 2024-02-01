using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Resturant.Models;
using Resturant.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Resturant.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AccountController : Controller
    {

        public UserManager<IdentityUser> UserManager { get; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(UserManager<IdentityUser> _UserManager, SignInManager<IdentityUser> _SignInManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
        }

        public ActionResult ListUsers()
        {
            var users = UserManager.Users.ToList();
            List<Register> listuser = new List<Register>();
            for (int i = 0; i < users.Count; i++)
            {
                Register list = new Register();
                list.Id = users[i].Id;
                list.Email = users[i].Email;
                list.UserName = users[i].UserName;
                list.Password = users[i].PasswordHash;
                listuser.Add(list);
            }
            return View(listuser);
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            var model = new Register
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
            };

            return View(model);
        }

        
        public ActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(Register collection)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Register Email wrong..!");
                return View();
            }
            try
            {
                
                var user = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email,
                    
                };

                var Result = await UserManager.CreateAsync(user,collection.Password);
                if (Result.Succeeded)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(ListUsers));
                }
                else
                {
                    ModelState.AddModelError("", "Register Email wrong..!");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Login(int id)
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "Email or Password not correct..!");
                    return View();
                }
                var Resualt = await SignInManager.PasswordSignInAsync(collection.Email, collection.Password, collection.RememberMe, false);
                if (Resualt.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Email or Password not correct..!");
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }


        public async Task<ActionResult> DeleteAccount(string id)
        {

            var user = await UserManager.FindByIdAsync(id);
            var result = await UserManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("ListUsers", "Account");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View("ListUsers");

        }



        //Get Edit

        public async Task<IActionResult> EditUser(string id)
        {
            var user = await UserManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            var model = new Register
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
            };

            return View(model);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(Register model)
        {
            var user = await UserManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                return RedirectToAction("ListUsers", "Account");
            }
            else
            {
                user.Id = model.Id;
                user.Email = model.Email;
                user.UserName = model.UserName;


                var result = await UserManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers", "Account");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return RedirectToAction("ListUsers", "Account");

            }
        }


        public async Task<ActionResult> Logout(int id)
        {
            await SignInManager.SignOutAsync();


            return RedirectToAction("Login", "Account");
        }




    }
}
