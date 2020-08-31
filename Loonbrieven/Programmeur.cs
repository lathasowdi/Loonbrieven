using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
   public class Programmeur:Werknemer
    {
        public bool BedrijfWagen;
        public Programmeur(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, string functie, string iBANNummer, string typecontract = "Voltijds", double startloon = 2200.00, double socialeZekerheid = 200, bool bedrijfWagen) : base(naam, geslacht,geboorteDatum, rijksRegisterNummer, indiensttreding,functie, iBANNummer,typecontract,startloon,socialeZekerheid)
        {
            BedrijfWagen = bedrijfWagen;
            BedrijfsVoorheffing = (bedrijfWagen == true ? 17.30 : 13.68);

        }
    }
}
