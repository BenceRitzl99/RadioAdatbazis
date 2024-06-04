using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZenekAdatbazis.Model
{
    //A Model mappában elkülönítjük az adatbázis tábláinak megfeleltetett osztályokat.
    public class Ado // a majdai adok tábal, mint EGYED egy előfordulása, vagyis a tábla egy sora.
    {
        [Key] //ezzel tudjuk orvosolni hogy valóban kulcsként vegye figyelembe a vevő
        public int RadioId { get; set; } //property, vagyis az osztály egy tulajdonsága ami olvasható(get), és írható(set).
        public string Megnevezes { get; set; }
        public ICollection<Musor> musorok {  get; set; }
        public int AdoRadioId { get; internal set; }
        
    }
}
