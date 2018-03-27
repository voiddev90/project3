using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace project3data.Models
{
    public class StreetCrime
    {
        public int id { get; set; }

        public string caseNumber { get; set; }

        public District district { get; set; }

        public DateTime registerDate { get; set; }

        public TimeSpan crimeTime { get; set; }
    }
}
