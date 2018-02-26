using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoApi
{
    public class CityController : Controller
    {
        public JsonResult GetCities()
        {
            return new JsonResult(
                new List<object>(){
                new { id =1 , name = "Skopje"},
                new { id = 2, name = "Oakville"}
            }
            );
        }


        public JsonResult Places()
        {
            return new JsonResult(
                new List<object>(){
                new { id = 100 , name = "Skopje Millenium Cross"},
                new { id = 200, name = "Oakville Downtown"}
            }
            );
        }




    }
}
