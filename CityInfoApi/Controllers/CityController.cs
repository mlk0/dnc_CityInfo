using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoApi.Controllers
{
    [Route("api/city")]
    public class CityController : Controller
    {
        //[HttpGet("api/cities")]
        [HttpGet("")]
        public IActionResult GetCities()
        {
            //var result = new JsonResult(
            //    //new List<object>(){
            //    //new { id =1 , name = "Skopje"},
            //    //new { id = 2, name = "Oakville"}
            //    //}

            //    CitiesDataStore.Current.Cities
            //);


            var result = CitiesDataStore.Current.Cities;

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == id);
                

            if(city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }




    }
}
