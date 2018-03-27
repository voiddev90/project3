using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project3data.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project3data.Controllers
{
    public class TestController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            // DistrictStoreContext district = HttpContext.RequestServices.GetService(typeof(project3data.Models.DistrictStoreContext)) as DistrictStoreContext;
            return View();
        }
    }
}
