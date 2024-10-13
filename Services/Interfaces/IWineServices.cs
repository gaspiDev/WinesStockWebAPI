using Common.Enums;
using Common.Models;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IWineServices
    {
        int CreateWine(NewWineDto createWineDTO);
        IEnumerable<Wine> ReadWine();
        IEnumerable<Wine> ReadWineByVariety(Variety variety);
        void UpdateWinestockById(int id, int stock);
    }
}