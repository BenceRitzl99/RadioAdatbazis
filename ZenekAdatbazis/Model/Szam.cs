using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenekAdatbazis.Model
{
    public class Szam
    {
        [Key]
        public int SzamId { get; set; }
        public string Cim { get; set; }
        public ICollection<Zene> zenek { get; set; }
    }
}
