using Common.Enums;
using Common.Models;

namespace Services.Interfaces
{
    public interface IWineServices
    {
        int AddWine(CreateWineDTO createWineDTO);
        Dictionary<string, int> GetAllWinesStock();
        Dictionary<string, int> GetByVarietyWinesStock(Variety variety);
        ModifyByIdWineStock ModifyWineStockByVariety(ModifyByIdWineStock newWineStock);
    }
}