using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameX.DAL;
using GameX.Infrastructure;
using GameX.Models;
using GameX.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GameX.Controllers
{
    public class UserPageController : Controller
    {
        private readonly StoreContext context;
        private IUser UserManager { get; set; }

        public UserPageController(StoreContext context)
        {
            //this.UserManager = new UserManager(context);
            this.context = context;
        }

        public IActionResult UserPage(string UserId)
        {
            Users User = context.Users.FirstOrDefault(x => x.Key == "d4073c9c-117d-462f-a0d9-9e83de6615b0");

            SignUpViewModel model = new SignUpViewModel()
            {
                Email = User.Email,
                Name = User.Name,
                Password = User.Password,
                Surname = User.Surname,
                Username = User.Username,
                UserId = User.UserId
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UserPage(SignUpViewModel SignUp)
        {
            UserManager.Edit(SignUp);
            return RedirectToAction("../MainPage/Index");
            
            
        }
    }
}