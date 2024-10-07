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
        public DateTime Date { get; set; }
        [Key]
        [Required]
        public string Title { get; set; }
        [ForeignKey("Wine")]
        public ICollection<Wine> Wines { get; set; }
        public ICollection<string> Guests { get; set; }
        // Migration pending due to not knowing if the relationship One(WineTastieng) to Many(Wine) is well implemented.
    }
}
