﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
     public class Support:Werknemer
    {
        public double Tweedagenperweekextra;
        public Support(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, string ibanNummer, string functie, string typecontract = "Voltijds", double startloon = 2050.00, double tweedagenperweekextra=50.0) : base(naam, geslacht, geboorteDatum, rijksRegisterNummer, indiensttreding, aantalGepresenteerdUren, ibanNummer, functie, typecontract, startloon)
        {
            Tweedagenperweekextra = tweedagenperweekextra;
        }
        public override double Netto()
        {
            return base.Netto() + 50;
        }
        public override string Loonbrieven()
        {
            return base.Loonbrieven() +"\n"+ "Extra €50 added" +"\n"+"to Netto voor Tweedagenperweekextrathuis";
        }

    }
}
