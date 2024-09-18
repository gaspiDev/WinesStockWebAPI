using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Data.Entities;

namespace Services
{
    public class WineServices
    {
        public readonly HardCodedDBRepository _hardCodedDBRepository;
        public WineServices(HardCodedDBRepository hardCodedDBRepository) 
        {
            _hardCodedDBRepository = hardCodedDBRepository;
        }


        public bool AddWine(CreateWineDTO createWineDTO) 
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
                return true;
            } else return false;
        }

        public Dictionary<string, int> WinesStock() 
        {
            return _hardCodedDBRepository.WinesStock();
        }
    }
}
