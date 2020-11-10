using SSS.DataAccess;
using SSS.DataAccess.DAL;
using SSS.TestWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SSS.TestWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        private dbAccess db;
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (this.db = new dbAccess())
                    {
                        Customer customer = new Customer
                        {
                            BirthDate = registerViewModel.DOB,
                            Email = registerViewModel.Email,
                            Name = registerViewModel.Name,
                            PassWord = registerViewModel.Password
                        };
                        bool CheckEmailIdAlreadyExist = this.db.CheckEmailIdAlreadyExist(registerViewModel.Email);
                        if (!CheckEmailIdAlreadyExist) this.db.createCustomer(customer);
                        else
                        {
                            ModelState.AddModelError("", "User Email Id Already Exist");
                            return View(registerViewModel);
                        }
                    }
                    return RedirectToRoute("/");
                }

            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            }
            return View(registerViewModel);
        }
    }
}