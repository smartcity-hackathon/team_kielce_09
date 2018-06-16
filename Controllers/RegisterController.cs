using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameX.DAL;
using GameX.Infrastructure;
using GameX.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GameX.Controllers
{
    public class RegisterController : Controller
    {
        private readonly StoreContext context;
        //private IUser UserManager { get; set; }

        public RegisterController(StoreContext context)
        {
            //this.UserManager = new UserManager(context);
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult SignUp(SignUpViewModel SignUp)
        //{

        //    if (this.UserManager.SignUp(SignUp))
        //    {
        //        return RedirectToAction("SuccesRegister");
        //    }
        //    else
        //    {
        //        return RedirectToAction("UnsuccesRegister");
        //    }
            
        //}

        public IActionResult SuccesRegister()
        {
            return View();
        }

        public IActionResult UnsuccesRegister()
        {
            return View();
        }
    }
}