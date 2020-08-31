using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
   public class Werknemer
    {
        public string Naam { get; set; }
        public string Geslacht { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string RijksRegisterNummer { get; set; }
        public DateTime Indiensttreding { get; set; }
        public string Functie { get; set; }
        public string IBANNummer { get; set; }
        public string Typecontract { get; set; }
        public double Startloon { get; set; }
        public double BedrijfsVoorheffing { get; set; }
        public double SocialeZekerheid { get; set; }
        public double Tweedagenperweek;

        public Werknemer(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, string functie, string iBANNummer, string typecontract="Voltijds", double startloon=1900.00, double bedrijfsVoorheffing=13.68, double socialeZekerheid=200)
        {
            Naam = naam;
            Geslacht = geslacht;
            GeboorteDatum = geboorteDatum;
            RijksRegisterNummer = rijksRegisterNummer;
            Indiensttreding = indiensttreding;
            Functie = functie;
            IBANNummer = iBANNummer;
            Typecontract = typecontract;
            Startloon = startloon;
            BedrijfsVoorheffing = bedrijfsVoorheffing;
            SocialeZekerheid = socialeZekerheid;
        }

        public override string ToString()
        {
            return Naam;
        }
        public double Uurberekening()
        {
            double uurberekening = 0;
            int uren;

            if (Typecontract == "Voltijds")
                uren = 38;
            else
                uren =25;
            uurberekening = uren / 38 * Startloon;
            return uurberekening;
        }
        public virtual double Ancienniteit()
        {
            int aantaljaren = 0;
            double ancienniteit=Startloon;
            aantaljaren = DateTime.Now.Year - Indiensttreding.Year;
            
            for (int i=0;i<aantaljaren;i++)
            {
                ancienniteit *= 1.01;
            }
            ancienniteit -= Startloon;
            return ancienniteit;
        }
    }
}
