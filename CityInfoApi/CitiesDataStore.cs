using System;
using System.Collections.Generic;
using CityInfoApi.Model;

namespace CityInfoApi
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities;

        public CitiesDataStore()
        {
            this.Cities = new List<CityDto>()
            {
                new CityDto(){
                    Id = 1,
                    Name = "Skopje",
                    Description = "Najubav na svet",
                    //NumberOfPointsOfInteres = 7
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 100,
                            Name = "Starata Turska Carsija",
                            Description = "Antique bazar / marketplace"
                        },
                        new PointOfInterestDto(){
                            Id = 101, Name = "Milanium Cross", Description = "Marker of 2000 years of "
                        }
                    }
                },
                new CityDto(){
                    Id = 2,
                    Name = "Ohrid",
                    Description = "Nasakan na svet",
                    //NumberOfPointsOfInteres = 17,
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){
                            Id = 102, Name = "Kaneo", Description = "Old Church by the Lake"
                        },
                        new PointOfInterestDto(){
                            Id = 103, Name = "Plaosnik", Description = "Antique Church"
                        }
                    }
                },
                new CityDto(){
                    Id = 3,
                    Name = "Kocani",
                    Description = "Najvesel na svet",
                    //NumberOfPointsOfInteres = 12
                    PointsOfInterest = new List<PointOfInterestDto>(){
                        new PointOfInterestDto(){ Id = 104 , Name = "Kocansko Pole", Description = "Wide open area for fun activities"}
                    }
                }
            };
        }
    }
}
