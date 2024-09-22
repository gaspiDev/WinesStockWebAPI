using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data.Entities;
using Microsoft.VisualBasic;

namespace Services
{
    public class WineServices
    {
        public readonly HardCodedDBRepository _hardCodedDBRepository;
        public WineServices(HardCodedDBRepository hardCodedDBRepository)
        {
            _hardCodedDBRepository = hardCodedDBRepository;
        }


        public void AddWine(CreateWineDTO createWineDTO)
        {
            if (_hardCodedDBRepository.wines.All((wine => wine.Name != createWineDTO.Name)))
            {
                _hardCodedDBRepository.AddWine(
                new Wine
                {
                    Id = _hardCodedDBRepository.wines.Max(x => x.Id) + 1,
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
            return _hardCodedDBRepository.GetAllWinesStock();
        }
    }
}
