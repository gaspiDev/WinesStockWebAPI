using Data.Entities;

namespace Data.Repository
{
    public interface IWineHardCodedDBRepository
    {
        public List<Wine> GetWines();
        void AddWine(Wine wine);
        Dictionary<string, int> GetAllWinesStock();
    }
}