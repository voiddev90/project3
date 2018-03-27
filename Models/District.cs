using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace project3data.Models
{
    public class District
    {
        public int id { get; set; }

        public string name { get; set; }

        public string areas { get; set; }

        public decimal? latitude { get; set; }

        public decimal? longitude { get; set; }
    }
}
