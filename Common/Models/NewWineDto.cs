using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class NewWineDto
    {
        public required string Name { get; set; }
        public Variety Variety { get; set; } = Variety.None;
        public int? Year { get; set; }
        public string? Region { get; set; }
        [Range(1, int.MaxValue)]
        public int? Stock { get; set; }
    }
}
