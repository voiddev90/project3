using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using project3data.Data;
using project3data.Models;

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
            return View();
        }

        public JsonResult GetStreetCrimeData(int year)
        {
            if(year == 2011 || year == 2012)
            {
                var streetCrimes = (this.database.StreetCrimes
                .Where(x => x.id > 0 && x.registerDate.Year == year)
                .GroupBy(s => new {district = s.district, month = s.registerDate.Month})
                .Select(x => new {amount = x.Count(), district = x.Key.district.name})
                .ToList());
                return Json(this.sortData(streetCrimes));
            } else {
                var streetCrimes = this.database.StreetCrimes
                .Where(x => x.id > 0)
                .GroupBy(s => new {district = s.district, month = s.registerDate.Month})
                .Select(x => new {amount = x.Count(), district = x.Key.district.name})
                .ToList();
                return Json(this.sortData(streetCrimes));
            }
        }

        public JsonResult GetBicycleCrimesData(int year)
        {
            if(year == 2011 || year == 2012)
            {
                var bicycleCrimes = this.database.BicycleCrimes
                .Where(x => x.id > 0 && x.registerDate.Year == year)
                .GroupBy(s => new {district = s.district, month = s.registerDate.Month})
                .Select(x => new {amount = x.Count(), district = x.Key.district.name})
                .ToList();
                return Json(this.sortData(bicycleCrimes));
            }
            else
            {
                var bicycleCrimes = this.database.BicycleCrimes
                .Where(x => x.id > 0)
                .GroupBy(s => new {district = s.district, month = s.registerDate.Month})
                .Select(x => new {amount = x.Count(), district = x.Key.district.name})
                .ToList();
                return Json(this.sortData(bicycleCrimes));
            }
            
        }

        private Dictionary<string, List<int>> sortData(IEnumerable<dynamic> crimes)
        {
            Dictionary<string, List<int>> crimeData = new Dictionary<string, List<int>>();
                foreach(var crime in crimes)
                {
                    if(!crimeData.ContainsKey(crime.district))
                    {
                        crimeData[crime.district] = new List<int>();
                    }
                    crimeData[crime.district].Add(crime.amount);
                }
                return crimeData;
        }
    }
}
