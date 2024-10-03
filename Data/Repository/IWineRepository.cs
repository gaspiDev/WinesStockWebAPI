using Data.Entities;

namespace Data.Repository
{
    public interface IWineRepository
    {
        public List<Wine> GetWines();
        int AddWine(Wine wine);
        Dictionary<string, int> GetAllWinesStock();
    }
}