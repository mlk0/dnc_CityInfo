using System;
using System.Collections.Generic;
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
                new List<object>(){
                new { id =1 , name = "Skopje"},
                new { id = 2, name = "Oakville"}
            }
            );
        }

        [HttpGet("{id}")]
        public JsonResult GetCity(int id)
        {
            return new JsonResult(
                new
                {
                    id = id,
                    name = "The City"
                }
            );
        }




    }
}
