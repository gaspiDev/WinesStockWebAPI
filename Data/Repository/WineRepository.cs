using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class WineRepository : IWineRepository
    {
        private readonly WinesStockContext _context;
        public WineRepository(WinesStockContext winesStockContext)
        {
            _context = winesStockContext;
        }
        public List<Wine> GetWines()
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
    }
}
