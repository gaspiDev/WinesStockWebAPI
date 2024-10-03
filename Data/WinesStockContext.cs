using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WinesStockContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wine> Wines{ get; set; }

        public WinesStockContext(DbContextOptions<WinesStockContext> options) : base(options) //Acá estamos llamando al constructor de DbContext que es el que acepta las opciones
        {

        }
    }
}
