using Common.Enums;
using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;

namespace Data.Repository.Implementations
{
    public class WineRepository : IWineRepository
    {
        private readonly WinesStockContext _context;
        public WineRepository(WinesStockContext winesStockContext)
        {
            _context = winesStockContext;
        }
        public IEnumerable<Wine> GetWines()
        {
            return _context.Wines.ToList();
        }
        public int AddWine(Wine wine)
        {
            _context.Add(wine);
            _context.SaveChanges();
            return _context.Wines.Max(w => w.Id);
        }
        public Dictionary<string, int> GetAllWinesStock()
        {
            return _context.Wines.ToDictionary(wine => wine.Name, wine => wine.Stock);
        }
        public Dictionary<string, int> GetByVarietyWinesStock(Variety variety)
        {
            return _context.Wines.Where(w => w.Variety == variety).ToDictionary(wine => wine.Name, wine => wine.Stock);
        }
        public ModifyByIdWineStock ModifyWineStockByVariety(ModifyByIdWineStock newWineStock) 
        {
            Wine updatedWineStock = _context.Wines.SingleOrDefault(w => w.Id == newWineStock.Id);
            updatedWineStock.Stock = newWineStock.Stock;
            _context.SaveChanges();
            return new ModifyByIdWineStock() { Id = updatedWineStock.Id, Stock = newWineStock.Stock };
        }
    }
}
