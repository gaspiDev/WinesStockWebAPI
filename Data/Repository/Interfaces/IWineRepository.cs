using Common.Enums;
using Common.Models;
using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IWineRepository
    {
        IEnumerable<Wine> GetWines();
        int CreateWine(Wine wine);
        IEnumerable<Wine> ReadWine();
        IEnumerable<Wine> ReadWineByVariety(Variety variety);
        void UpdateWinestockById(int id, int stock);
    }
}