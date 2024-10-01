using Common.Models;

namespace Services
{
    public interface IWineServices
    {
        void AddWine(CreateWineDTO createWineDTO);
        Dictionary<string, int> GetAllWinesStock();
    }
}