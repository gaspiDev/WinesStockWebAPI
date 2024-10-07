using Common.Enums;
using Common.Models;
using Data.Entities;

namespace Data.Repository.Interfaces
{
    public interface IWineRepository
    {
        IEnumerable<Wine> GetWines();
        int AddWine(Wine wine);
        Dictionary<string, int> GetAllWinesStock();
        Dictionary<string, int> GetByVarietyWinesStock(Variety variety);
        ModifyByIdWineStock ModifyWineStockByVariety(ModifyByIdWineStock newWineStock);
    }
}