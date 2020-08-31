using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
    public class ITSupport:Werknemer
    {
        public ITSupport (string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, string functie, string iBANNummer, string typecontract = "Voltijds", double startloon = 2050.00) : base(naam, geslacht, geboorteDatum, rijksRegisterNummer, indiensttreding, functie, iBANNummer, typecontract, startloon)
        {

        }
    }
}
