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
                    PointsOfInteres = new List<PointOfInteresDto>(){
                        new PointOfInteresDto(){
                            Id = 100,
                            Name = "Starata Turska Carsija",
                            Description = "Antique bazar / marketplace"
                        },
                        new PointOfInteresDto(){
                            Id = 101, Name = "Milanium Cross", Description = "Marker of 2000 years of "
                        }
                    }
                },
                new CityDto(){
                    Id = 2,
                    Name = "Ohrid",
                    Description = "Nasakan na svet",
                    //NumberOfPointsOfInteres = 17,
                    PointsOfInteres = new List<PointOfInteresDto>(){
                        new PointOfInteresDto(){
                            Id = 102, Name = "Kaneo", Description = "Old Church by the Lake"
                        },
                        new PointOfInteresDto(){
                            Id = 103, Name = "Plaosnik", Description = "Antique Church"
                        }
                    }
                },
                new CityDto(){
                    Id = 3,
                    Name = "Kocani",
                    Description = "Najvesel na svet",
                    //NumberOfPointsOfInteres = 12
                    PointsOfInteres = new List<PointOfInteresDto>(){
                        new PointOfInteresDto(){ Id = 104 , Name = "Kocansko Pole", Description = "Wide open area for fun activities"}
                    }
                }
            };
        }
    }
}
