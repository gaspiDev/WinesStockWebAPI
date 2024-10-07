using Data.Entities;
using Common.Models;
using Data.Repository.Interfaces;
using Services.Interfaces;
using Common.Enums;

namespace Services.Implementations
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
                int newWineId = _wineRepository.AddWine(
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

        public Dictionary<string, int> GetByVarietyWinesStock(Variety variety)
        {
            return _wineRepository.GetByVarietyWinesStock(variety);
        }

        public ModifyByIdWineStock ModifyWineStockByVariety(ModifyByIdWineStock newWineStock) 
        {
            return _wineRepository.ModifyWineStockByVariety(newWineStock);
        }
    }
}
