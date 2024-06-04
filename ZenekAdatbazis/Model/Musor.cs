using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenekAdatbazis.Model
{
    public class Musor
    {
        [Key]
        public int MusorAzonosito { get; set; }
        public int RadioId { get; set;} //foreign key
        public Ado Ado { get; set;}
        public int ZeneId { get; set;} //foreign key
        public Zene Zene { get; set;}
        public int AdoRadioId { get; set;}
    }
}
