using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class WineTastingWine
    {
        public int WineId { get; set; }
        public Wine Wine { get; set; }

        public int WineTastingId { get; set; }
        public WineTasting WineTasting { get; set; }
    }


}
