using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WineHardCodedDBRepository
    {
        public List<Wine> wines = new List<Wine>()
        {
            new Wine
            {
                Id = 1,
                Name = "Malbec Reserve",
                Variety = "Malbec",
                Year = 2018,
                Region = "Mendoza",
                Stock = 50,
                CreatedAt = new DateTime(2020, 5, 15)
            },
            new Wine
            {
                Id = 2,
                Name = "Cabernet Sauvignon Premium",
                Variety = "Cabernet Sauvignon",
                Year = 2019,
                Region = "La Rioja",
                Stock = 30,
                CreatedAt = new DateTime(2021, 3, 10)
            },
            new Wine
            {
                Id = 3,
                Name = "Syrah Gran Reserva",
                Variety = "Syrah",
                Year = 2020,
                Region = "Salta",
                Stock = 75,
                CreatedAt = new DateTime(2022, 1, 20)
            },
            new Wine
            {
                Id = 4,
                Name = "Chardonnay Selección Especial",
                Variety = "Chardonnay",
                Year = 2021,
                Region = "Patagonia",
                Stock = 40,
                CreatedAt = new DateTime(2023, 2, 15)
            },
            new Wine
            {
                Id = 5,
                Name = "Torrontés Vintage",
                Variety = "Torrontés",
                Year = 2022,
                Region = "Catamarca",
                Stock = 25,
                CreatedAt = new DateTime(2023, 6, 5)
            }
        };
        public void AddWine(Wine wine)
        { 
            wines.Add(wine);
        }
        public Dictionary<string, int> GetAllWinesStock()
        {
            return wines.ToDictionary(wine => wine.Name, wine => wine.Stock);
        }
    }
}
