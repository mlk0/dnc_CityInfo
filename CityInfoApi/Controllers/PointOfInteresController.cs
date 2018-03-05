using System;
using System.Linq;
using AutoMapper;
using CityInfoApi.Model;
using CityInfoApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CityInfoApi.Controllers
{
    [Route("api/city")]
    public class PointOfInterestController : Controller
    {
        private IMapper _mapper;
        private ILogger<PointOfInterestController> _logger;
        private IEmailService _emailService;

        public PointOfInterestController(IMapper mapper, ILogger<PointOfInterestController> logger, IEmailService emailService)
        {
			this._mapper = mapper;
            this._logger = logger;
            this._emailService = emailService;
            _logger.LogInformation("PointOfInterestController");
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


        [HttpPut("{cityId}/pointofinterest2/{id}")]
        public IActionResult UpdatePointOfInterest2(int cityId, int id, [FromBody] UpdatePointOfInterestDto pointOfInterest)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault((c => c.Id == cityId));
            if (city == null)
            {
                return NotFound();
            }

            var poi = city.PointsOfInterest.SingleOrDefault(pi => pi.Id == id);
            if (poi == null)
            {
                return NotFound();
            }

 
            //poi is updated in the following statement while the id is preserved in it
            //since it is "by reference" there is no need to first remove the exiting poi from the list and adding a new one
            _mapper.Map<UpdatePointOfInterestDto, PointOfInterestDto>(pointOfInterest, poi);
         

            return NoContent();

        }


        [HttpPatch("{cityId}/pointofinterest/{id}")]
        public IActionResult PartialUpdatePointOfInterest(int cityId, int id,
                                                 [FromBody] JsonPatchDocument<UpdatePointOfInterestDto> patchDocument
                                                ){
            if(cityId <= 0){
                return BadRequest("Invalid City Id");
            }

            if(id<=0){
                return BadRequest("Invalid Place of Interest Id");

            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault((c => c.Id == cityId));
            if(city == null){
                return NotFound($"Unable to find city for the specified id : {cityId}");
            }

            var pointOfInterest = CitiesDataStore.Current.Cities.SelectMany(c => c.PointsOfInterest).SingleOrDefault(p => p.Id == id);
            if(pointOfInterest == null)
            {
                return NotFound($"Uanable to find Place of Interes for the specified id : {id}");
            }


            //pointOfInterest is the instance pulled from the DB that needs to be patched
            //however, the patching is not suitable to be applied to this type since it has id property
            //and there is a chance to override that one in the patcing process/
            //therefore instad patching exuecuted against the PointOfInterestDto type, the actual patch
            //will be executed agains UpdatePointsOfInterestDto document
            //For that purpose, we need to map/convert from PointOfIntersDto to UpdatePointOfIntersDto 
            //this can be done manually or through the use of AutoMapper as long the proper mapping definition is present 


            //option 1
            var updatePointOfInteresDtoX = new UpdatePointOfInterestDto()
            {
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };


            //option 2
            var updatePointOfInteresDto =  _mapper.Map<PointOfInterestDto, UpdatePointOfInterestDto>(pointOfInterest);

            //the act of applying the patch commands to the instance of type UpdatePointOfInteresDto
            patchDocument.ApplyTo(updatePointOfInteresDto, ModelState);

            //check if now the ModelState has errors
            //due to 1. invalid JsonPatchDocument or 2. inabillity to apply the document
            //ex of the case 2 is to attempt to act on an inexistent property
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //since the ModelState is concerned only about the input model
            //in case when the applucation of the document produces an instance
            //that is invalid, the model state of that instance is not tracked
            //in order to check the state of the patched instance, an explicit
            //call to the TryValidateModel method is needed agains the patched instance
            TryValidateModel(updatePointOfInteresDto);

            //now check the ModelState.IsValid again
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //update the "DB" if and only if there are no errors
            _mapper.Map<UpdatePointOfInterestDto, PointOfInterestDto>(updatePointOfInteresDto, pointOfInterest);

            return NoContent();

        }


        [HttpDelete("{cityId}/pointofinterest/{id}")]
        public IActionResult DeletePointOfInterest(int cityId, int id){

            if(cityId <= 0 || id <= 0){
                return BadRequest();    
            }

            var city = CitiesDataStore.Current.Cities.SingleOrDefault(c => c.Id == cityId);
            if(city == null){
                return NotFound($"Unable to find city with cityId : {cityId}");
            }

            var poi = city.PointsOfInterest.SingleOrDefault(p => p.Id == id);
            if(poi == null){
                return NotFound($"Unable to find Poing of Interes with id : {id}");
            }

            city.PointsOfInterest.Remove(poi);
            this._logger.LogInformation($"Deleted point of interest with id : {id} within the City with cityId : {cityId}");
            this._emailService.SendEmail();
            return NoContent();


        }

    }
}
