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
            var streetCrimes = this.database.StreetCrimes
            .Where(x => x.id > 0)

            .GroupBy(s => new {district = s.district})
            .Select(x => new { total = x.Count(), district = x.Key.district})
            .ToList();

            var bicycleCrimes = this.database.BicycleCrimes
            .Where(x => x.id > 0)
            .GroupBy(s => new {district = s.district})
            .Select(x => new { total = x.Count(), district = x.Key.district})
            .ToList();
            
            List<string> districts = new List<string>();
            List<int> streetData = new List<int>();
            List<int> bicycleCrimesData = new List<int>();
            foreach(var crime in streetCrimes)
            {
                districts.Add(crime.district.name);
                streetData.Add(crime.total);
            }

            foreach(var crime in bicycleCrimes)
            {
                bicycleCrimesData.Add(crime.total);
            }

            ViewData["districts"] = JsonConvert.SerializeObject(districts);
            ViewData["streetCrimes"] = JsonConvert.SerializeObject(streetData);
            ViewData["bicycleCrimes"] = JsonConvert.SerializeObject(bicycleCrimesData);
            
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

        public JsonResult GetBicycleCrimesData(DateTime year)
        {
            return Json("bicycle crime " + year.Year);
        }
    }
}
