using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoApi.Controllers
{
    [Route("api/city")]
    public class PointOfInteresController : Controller
    {
        public PointOfInteresController()
        {
        }

        [HttpGet("{cityId}/pointofinteres")]
        public IActionResult GetPointsOfInteresForCity(int cityId){
            if(cityId <=0){
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if(city == null){
                return NotFound();
            }

            return Ok(city.PointsOfInteres);
        }


        [HttpGet("{cityId}/pointofinteres/{id}")]
        public IActionResult GetPointOfInteres(int cityId, int id){

            if (cityId <= 0)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInteres = city.PointsOfInteres.SingleOrDefault(poi => poi.Id == id);
            if(pointOfInteres == null){
                return NotFound();
            }

            return Ok(pointOfInteres);
        }


    }
}
