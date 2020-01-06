using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryStateCityAPI.Models
{
    public class Country
    {
        public string id { get; set; }
        public string shortName { get; set; }
        public string name { get; set; }
        public string phoneCode { get; set; }
    }
}