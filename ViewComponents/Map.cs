using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameX.ViewComponents
{
    public class Map: ViewComponent
    {
        public Map()
        {

        }
        public IViewComponentResult Invoke()
        {
         
            return View("Map");
        }
    }
}
