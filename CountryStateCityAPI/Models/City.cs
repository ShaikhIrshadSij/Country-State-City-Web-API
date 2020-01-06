using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryStateCityAPI.Models
{
    public class RootCity
    {
        public List<City> cities { get; set; }
    }
    public class City
    {
        public string id { get; set; }
        public string name { get; set; }
        public string stateId { get; set; }
    }
}