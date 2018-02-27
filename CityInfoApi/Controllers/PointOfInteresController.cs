using System;
using System.Linq;
using CityInfoApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoApi.Controllers
{
    [Route("api/city")]
    public class PointOfInterestController : Controller
    {
        public PointOfInterestController()
        {
        }

        [HttpGet("{cityId}/pointofinterest")]
        public IActionResult GetPointsOfInterestForCity(int cityId){
            if(cityId <=0){
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if(city == null){
                return NotFound();
            }

            return Ok(city.PointsOfInterest);
        }


        [HttpGet("{cityId}/pointofinterest/{id}", Name = "cityPointOfInterest")]
        public IActionResult GetPointOfInterest(int cityId, int id){

            if (cityId <= 0)
            {
                return BadRequest();
            }

           

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointsOfInterest.SingleOrDefault(poi => poi.Id == id);
            if(pointOfInterest == null){
                return NotFound();
            }

            return Ok(pointOfInterest);
        }


        [HttpPost("{cityId}/pointofinterest")]
        public IActionResult CreatePointOfInterest(int cityId, [FromBody] CreatePointOfInterestDto pointOfInterest)
        {
            if(pointOfInterest == null){
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if(city == null){
                return NotFound();
            }

            int newPointIfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(i => i.Id);

            var newPointOfInterest = new PointOfInterestDto()
            {
                Id = ++newPointIfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };


            city.PointsOfInterest.Add(newPointOfInterest);



            //return the 201 with the location header to the route that is associted with the name cityPointOfInterest
            return CreatedAtRoute("cityPointOfInterest", new { cityId = cityId, id = newPointOfInterest.Id }, newPointOfInterest);

        }



        [HttpPost("{cityId}/pointofinterest1")]
        public IActionResult CreatePointOfInterest1(int cityId, [FromBody] CreatePointOfInterestDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            int newPointIfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(i => i.Id);

            var newPointOfInterest = new PointOfInterestDto()
            {
                Id = ++newPointIfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };


            city.PointsOfInterest.Add(newPointOfInterest);



            //return the 201 with the location header set to any string, it can be jibberish as well
            return Created("blabla", newPointOfInterest);
        }


        [HttpPost("{cityId}/pointofinterest2")]
        public IActionResult CreatePointOfInterest2(int cityId, [FromBody] CreatePointOfInterestDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }




            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            int newPointIfInterestId = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).Max(i => i.Id);

            var newPointOfInterest = new PointOfInterestDto()
            {
                Id = ++newPointIfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };


            city.PointsOfInterest.Add(newPointOfInterest);



            //return the 201 with the location header to the route associated with the controller action
            //NOTE: this is not the best choice since the acton name may change in a refactoring and the reference here will be still pointing to the old controller action
            //      for that reason, the best usage would be CreatedAtRoute that will reference the Name associated with the route which will not change with the refactoring
            return CreatedAtAction("GetPointOfInterest", new { cityId = cityId, id = newPointOfInterest.Id }, newPointOfInterest);
        }

        [HttpPut("{cityId}/pointofinterest/{id}")]
        public IActionResult UpdatePointOfInterest(int cityId, int id, [FromBody] UpdatePointOfInterestDto pointOfInterest)
        {
            if(pointOfInterest == null){
                return BadRequest();
            }

            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault((c => c.Id == cityId));
            if(city == null){
                return NotFound();
            }

            var poi = CitiesDataStore.Current.Cities.SelectMany(pi => pi.PointsOfInterest).SingleOrDefault(p => p.Id == id);
            if(poi == null){
                return NotFound();
            }

            poi.Name = pointOfInterest.Name;
            poi.Description = pointOfInterest.Description;

            return NoContent();
            
        }

    }
}
