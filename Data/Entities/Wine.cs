using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Wine
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Variety Variety { get; set; } = Variety.None;
        public required int Year { get; set; }
        public required string Region { get; set; }
        [Range(1, int.MaxValue)]
        public int Stock { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<WineTastingWine> WineTastingWines { get; set; } = [];
    }
}
