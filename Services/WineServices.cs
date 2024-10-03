using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.VisualBasic;
using Common.Models;

namespace Services
{
    public class WineServices : IWineServices
    {
        public readonly IWineRepository _wineRepository;
        public WineServices(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }


        public int AddWine(CreateWineDTO createWineDTO)
        {
            if (_wineRepository.GetWines().All(wine => wine.Name != createWineDTO.Name))
            {
                int newWineId  = _wineRepository.AddWine(
                new Wine
                {
                    Id = _wineRepository.GetWines().Max(x => x.Id) + 1,
                    Name = createWineDTO.Name,
                    Variety = createWineDTO.Variety,
                    Year = createWineDTO.Year,
                    Region = createWineDTO.Region,
                    Stock = createWineDTO.Stock,
                    CreatedAt = DateTime.UtcNow,
                }
                );
                return newWineId;
            }
            else throw new InvalidOperationException();
        }

        public Dictionary<string, int> GetAllWinesStock()
        {
            return _wineRepository.GetAllWinesStock();
        }
    }
}
