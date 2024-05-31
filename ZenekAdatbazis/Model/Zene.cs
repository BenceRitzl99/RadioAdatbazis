using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenekAdatbazis.Model
{
    public class Zene
    {
        [Key]
        public int ZeneId { get; set; }
        public int EloadoId { get; set; } //foreign key
        public Eloado Eloado { get; set; }
        public int SzamId { get; set; } //foreign key
        public Szam Szam { get; set; }
        public int Perc { get; set; }
        public int Masodperc { get; set; }
        public ICollection<Musor> musorok { get; set; }
    }
}
