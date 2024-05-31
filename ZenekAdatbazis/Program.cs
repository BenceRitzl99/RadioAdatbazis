using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ZenekAdatbazis.Model;

namespace ZenekAdatbazis
{

    //Az adatbazisunk tehát:
    //adok(Id*,megnevezes)
    //eloadok(Id*,nev)
    //szam(Id*,cim)

    //SAJNOS homonímák ütötték fel a fejüket, hiszen az id más-más jelentést hordoz

    //adok(RadioId*,megnevezes)
    //eloadok(EloadoId*,nev)
    //szam(SzamId*,cim)

    //Az így rendelkezésre álló adatmodell azonban még nem teljes, hiszen nem tudjuk pl. hogy kinek a zeneszáma került adott rádión sugárzásra.
    
    //További szükséges táblák:

        //zenek(ZeneId*,EloadoId,SzamId,perc,masodperc)
        //musorok(musorazonosito*,RadioId,ZeneId)

    //eloado -1-----N- zenek -N-----1- szamok
    //adok -1-----N- musorok -N-----1- zenek

    //(A kapcsolatok egy a többhöz)





    internal class Program
    {
        static StreamReader file = new StreamReader("K://zenek.txt");
        static RadiokMusorai rm = new RadiokMusorai();
        static void Main(string[] args)
        {
            rm.Database.EnsureCreated(); //lényegében ez garantálja az adatbázis létrejöttét.

            //Rádióadók tekintetében a zenek.txt mindössze 1, 2, 3 kódértéket tartalmaz, megtehetjük, hogy azokat előre felvesszük

            Ado ado = new Ado(); //Ado elég egyszer
            ado.RadioId = 1;
            ado.Megnevezes = "Retro";
            rm.adok.Add(ado); //a rádiót, mint egy listához az adok táblájához hozzáadjuk
            ado = new Ado();
            ado.RadioId = 2;
            ado.Megnevezes = "Petőfi";
            rm.adok.Add(ado);
            ado = new Ado();
            ado.RadioId = 3;
            ado.Megnevezes = "Rádió 1";
            rm.adok.Add(ado);
            rm.SaveChanges(); //ez vezeti át ténylegesen a bővítést

            //a file-t olvasva feltölthetjük az előadókat is
            Dictionary<string, int> eloadok_egyedi = new Dictionary<string, int>();
            Dictionary<string, int> cimek_egyedi = new Dictionary<string, int>();
            while (!file.EndOfStream)
            {
                string sor = file.ReadLine();
                string[] reszek = sor.Split(':');
                try
                {
                    cimek_egyedi[reszek[1]]++;
                }
                catch 
                {
                    cimek_egyedi[reszek[1]] = 1;
                }
                reszek = reszek[0].Split(' ');
                string eloado_neve = reszek[3];
                for (int i = 4; i < reszek.Length; i++)
                {
                    eloado_neve += (" " + reszek[i]);
                }
                try
                {
                    eloadok_egyedi[eloado_neve]++;
                }
                catch 
                {
                    eloadok_egyedi[eloado_neve] = 1;
                }



            }
            file.Close();
            foreach (KeyValuePair<string,int> e in eloadok_egyedi)
            {
                Eloado eloado = new Eloado();
                eloado.Nev = e.Key;
                rm.eloadok.Add(eloado);

                    

            }
            foreach (KeyValuePair<string,int> e in cimek_egyedi)
            {
                Szam szam = new Szam();
                szam.Cim = e.Key;
                rm.szamok.Add(szam);
            }

        }
    }
}
