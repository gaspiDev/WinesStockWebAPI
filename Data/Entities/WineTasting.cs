using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WineTasting
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<string> Guests { get; set; } = [];
        public ICollection<WineTastingWine> WineTastingWines { get; set; } = [];
    }
}
