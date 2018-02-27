using System;
using System.Collections.Generic;

namespace CityInfoApi.Model
{
    public class CityDto
    {
        public CityDto()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInteres { get {
                return this.PointsOfInterest.Count;
            } }

        public List<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
