using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using project3data.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project3data.Controllers
{
    public class CriminalController : Controller
    {
        private readonly DatabaseContext database;

        public CriminalController(DatabaseContext context)
        {
            database = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            string json = JsonConvert.SerializeObject(this.database.Districts);
            ViewData["districts"] = json;
            
            return View();
        }
    }
}
