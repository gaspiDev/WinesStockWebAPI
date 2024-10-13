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
        public int CreateWine(Wine wine)
        {
            try
            {
                _context.Add(wine);
                _context.SaveChanges();
                return _context.Wines.Max(w => w.Id);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public IEnumerable<Wine> ReadWine()
        {
            try
            {
                return _context.Wines.Where(w => w.Stock > 0);
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
                return _context.Wines.Where(w => w.Variety == variety && w.Stock > 0);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        public void UpdateWinestockById(int id, int stock)
        {
            try
            {
                _context.Wines.Single(w => w.Id == id).Stock = stock;
                _context.SaveChanges();
            }
            catch (Exception) 
            {
                throw new Exception();
            } 
        }
    }
}
