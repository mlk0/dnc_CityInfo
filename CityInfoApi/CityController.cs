using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoApi
{
    [Route("api/city")]
    public class CityController : Controller
    {
        //[HttpGet("api/cities")]
        [HttpGet("")]
        public JsonResult GetCities()
        {
            return new JsonResult(
                //new List<object>(){
                //new { id =1 , name = "Skopje"},
                //new { id = 2, name = "Oakville"}
                //}

                CitiesDataStore.Current.Cities
            );
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            return
                new JsonResult(
                CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == id)
                );
        }




    }
}
