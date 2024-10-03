using Common.Models;

namespace Services
{
    public interface IWineServices
    {
        int AddWine(CreateWineDTO createWineDTO);
        Dictionary<string, int> GetAllWinesStock();
    }
}