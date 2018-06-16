using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameX.DAL;
using GameX.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameX.Controllers
{
    public class MainPage : Controller
    {
        private readonly StoreContext _context;
        public MainPage(StoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //List<Events> events=_context.Events.ToList();
            return View();
        }
    }
}