using System;
using System.Linq;
using CityInfoApi.Model;
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


        [HttpGet("{cityId}/pointofinteres/{id}", Name = "cityPointOfInteres")]
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


        [HttpPost("{cityId}/pointofinteres")]
        public IActionResult CreatePointOfInteres(int cityId, [FromBody] CreatePointOfInteresDto pointOfInteres)
        {
            if(pointOfInteres == null){
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if(city == null){
                return NotFound();
            }

            int newPointIfInteresId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInteres).Max(i => i.Id);

            var newPointOfInteres = new PointOfInteresDto()
            {
                Id = ++newPointIfInteresId,
                Name = pointOfInteres.Name,
                Description = pointOfInteres.Description
            };


            city.PointsOfInteres.Add(newPointOfInteres);



            //return the 201 with the location header to the route that is associted with the name cityPointOfInteres
            return CreatedAtRoute("cityPointOfInteres", new { cityId = cityId, id = newPointOfInteres.Id }, newPointOfInteres);

        }

    }
}
