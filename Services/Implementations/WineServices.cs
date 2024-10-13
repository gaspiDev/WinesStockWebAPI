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


        public int CreateWine(NewWineDto createWineDTO)
        {
            if (_wineRepository.GetWines().All(wine => wine.Name != createWineDTO.Name))
            {
                try
                {
                    int newWineId = _wineRepository.CreateWine(
                    new Wine
                    {
                        Name = createWineDTO.Name,
                        Variety = createWineDTO.Variety,
                        Year = createWineDTO.Year,
                        Region = createWineDTO.Region,
                        Stock = createWineDTO.Stock,
                    }
                    );
                    return newWineId;
                }
                catch (Exception) 
                {
                    throw new Exception();
                }
            }
            else throw new InvalidOperationException();
        }

        public IEnumerable<Wine> ReadWine()
        {
            try
            {
                return _wineRepository.ReadWine();
            }
            catch (Exception) 
            {
                throw new Exception();
            }
        }

        public IEnumerable<Wine> ReadWineByVariety(Variety variety)
        {
            try 
            {
                return _wineRepository.ReadWineByVariety(variety);
            } catch (Exception)
            { 
                throw new Exception();
            }
        }

        public void UpdateWinestockById(int id, int stock)
        {
            try
            {
                _wineRepository.UpdateWinestockById(id, stock);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
