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

        public IActionResult Index(int year)
        {


            ViewData["districts"] = JsonConvert.SerializeObject((this.database.Districts.Select(x => x.name)));
            
            return View();
        }

        public JsonResult GetStreetCrimeData(int year)
        {
            if(year == 2011 || year == 2012)
            {
                var streetCrimes = (this.database.StreetCrimes
                .Where(x => x.id > 0 && x.registerDate.Year == year)
                .GroupBy(s => new {district = s.district})
                .Select(x => x.Count())
                .ToList());
                return Json(streetCrimes);
            } else {
                var streetCrimes = this.database.StreetCrimes
                .Where(x => x.id > 0)
                .GroupBy(s => new {district = s.district})
                .Select(x => x.Count())
                .ToList();
                return Json(streetCrimes);
            }
        }

        public JsonResult GetBicycleCrimesData(int year)
        {
            if(year == 2011 || year == 2012)
            {
                var bicycleCrimes = this.database.BicycleCrimes
                .Where(x => x.id > 0 && x.registerDate.Year == year)
                .GroupBy(s => new {district = s.district})
                .Select(x => x.Count())
                .ToList();
                return Json(bicycleCrimes);
            }
            else
            {
                var bicycleCrimes = this.database.BicycleCrimes
                .Where(x => x.id > 0)
                .GroupBy(s => new {district = s.district})
                .Select(x => x.Count())
                .ToList();
                return Json(bicycleCrimes);
            }
            
        }
    }
}
