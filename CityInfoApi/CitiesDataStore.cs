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
                    NumberOfPointsOfInteres = 7
                },
                new CityDto(){
                    Id = 2,
                    Name = "Ohrid",
                    Description = "Nasakan na svet",
                    NumberOfPointsOfInteres = 17
                },
                new CityDto(){
                    Id = 3,
                    Name = "Kocani",
                    Description = "Najvesel na svet",
                    NumberOfPointsOfInteres = 12
                }
            };
        }
    }
}
