using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using CountryStateCityAPI.Models;
using Newtonsoft.Json;

namespace CountryStateCityAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {
        [Route("getCountryList")]
        public HttpResponseMessage GetCountryList()
        {
            try
            {
                string restCountry = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}/RestJSON/countries.json");
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, data = restCountry });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { success = false, data = ex.Message });
            }
        }
        [Route("getStateList")]
        public HttpResponseMessage GetStateList()
        {
            try
            {
                string restState = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}/RestJSON/states.json");
                RootState state = JsonConvert.DeserializeAnonymousType(restState, new RootState());
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, data = state, totalState = state.states.Count });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { success = false, data = ex.Message });
            }
        }
        [Route("getStateFromCountry/{stateId}")]
        public HttpResponseMessage GetStateFromCountry(string stateId)
        {
            try
            {
                string restState = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}/RestJSON/states.json");
                RootState state = JsonConvert.DeserializeAnonymousType(restState, new RootState());
                List<State> filteredState = state.states.Where(x => x.countryId == stateId).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, data = filteredState, totalStateFiltered = filteredState.Count, totalState = state.states.Count });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { success = false, data = ex.Message });
            }
        }
        [Route("getCityList")]
        public HttpResponseMessage GetCityList()
        {
            try
            {
                string restCity = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}/RestJSON/cities.json");
                RootCity city = JsonConvert.DeserializeAnonymousType(restCity, new RootCity());
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, data = city, totalCity = city.cities.Count });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { success = false, data = ex.Message });
            }
        }
        [Route("getCityFromState/{cityId}")]
        public HttpResponseMessage GetCityFromState(string cityId)
        {
            try
            {
                string restCity = System.IO.File.ReadAllText($"{AppContext.BaseDirectory}/RestJSON/cities.json");
                RootCity city = JsonConvert.DeserializeAnonymousType(restCity, new RootCity());
                List<City> filteredCity = city.cities.Where(x => x.stateId == cityId).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, new { success = true, data = filteredCity, totalStateFiltered = filteredCity.Count, totalCity = city.cities.Count });
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { success = false, data = ex.Message });
            }
        }
    }
}
