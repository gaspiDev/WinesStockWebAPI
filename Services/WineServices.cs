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
        public readonly IWineHardCodedDBRepository _wineHardCodedDBRepository;
        public WineServices(IWineHardCodedDBRepository hardCodedDBRepository)
        {
            _wineHardCodedDBRepository = hardCodedDBRepository;
        }


        public void AddWine(CreateWineDTO createWineDTO)
        {
            if (_wineHardCodedDBRepository.GetWines().All(wine => wine.Name != createWineDTO.Name))
            {
                _wineHardCodedDBRepository.AddWine(
                new Wine
                {
                    Id = _wineHardCodedDBRepository.GetWines().Max(x => x.Id) + 1,
                    Name = createWineDTO.Name,
                    Variety = createWineDTO.Variety,
                    Year = createWineDTO.Year,
                    Region = createWineDTO.Region,
                    Stock = createWineDTO.Stock,
                    CreatedAt = DateTime.UtcNow,
                }
                );
            }
            else throw new InvalidOperationException();
        }

        public Dictionary<string, int> GetAllWinesStock()
        {
            return _wineHardCodedDBRepository.GetAllWinesStock();
        }
    }
}
