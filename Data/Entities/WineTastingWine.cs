using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WineTastingWine
    {
        public required int WineId { get; set; }
        public required Wine Wine { get; set; }

        public required int WineTastingId { get; set; }
        public  required WineTasting WineTasting { get; set; }
    }
}
