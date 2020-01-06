using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CountryStateCityAPI.Models
{
    public class RootState
    {
        public List<State> states { get; set; }
    }
    public class State
    {
        public string id { get; set; }
        public string name { get; set; }
        public string countryId { get; set; }
    }
}