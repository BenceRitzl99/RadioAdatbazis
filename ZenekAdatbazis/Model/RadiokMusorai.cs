using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Pomelo.EntityFrameworkCore.MySql;

namespace ZenekAdatbazis.Model
{
    public class RadiokMusorai : DbContext //a majdani adatbázisunk öröklődéssel, mint UTÓD a DbContext ŐS-ből szármaik (SPECIALIZÁCIÓ)
    {
        
        public DbSet<Ado> adok { get; set; }  //generikus egy olyan típus, amelynek elemei típusának megadása egy paraméterként valósul meg.
        public DbSet<Eloado> eloadok { get; set; }
        public DbSet<Szam> szamok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("SERVER=127.0.0.1;USERNAME=root;PASSWORD=;DATABASE=RadiokMusoraiAdatbazis");
        }
    }
}
