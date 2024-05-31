using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenekAdatbazis.Model
{
    public class Eloado //Az Entity Framework az olyan tulajdonságokat, ami Id vagy azt tartalmazza EGYEDI AZONOSÍTÓNAK tekint (primary key)
    {
        [Key]
        public int EloadoId { get; set; }
        public string Nev { get; set; }
    }
}
