using System;
using System.Collections.Generic;
using System.IO;
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
        public string IbanNummer { get; set; }
        public string Typecontract { get; set; }
        public double Startloon { get; set; }
        public double BedrijfsVoorheffing { get; set; }
        public double SocialeZekerheid { get; set; }
        public int AantalGepresenteerdUren { get; set; }
        public bool Bedrijfswagen { get; set; }
        public Werknemer(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, string ibanNummer, string functie = "Werknemer", string typecontract = "Voltijds", double startloon = 1900.00, double bedrijfsVoorheffing = 13.68, double socialeZekerheid = 200)
        {
            Naam = naam;
            Geslacht = geslacht;
            GeboorteDatum = geboorteDatum;
            RijksRegisterNummer = rijksRegisterNummer;
            Indiensttreding = indiensttreding;
            AantalGepresenteerdUren = aantalGepresenteerdUren;
            IbanNummer = ibanNummer;
            Functie = functie;
            Typecontract = typecontract;
            Startloon = startloon;
            BedrijfsVoorheffing = bedrijfsVoorheffing;
            SocialeZekerheid = socialeZekerheid;

        }

        public override string ToString()
        {
            return Naam;
        }
        public virtual double Uurberekendstartloon()
        {
            double uurberekening = (double)AantalGepresenteerdUren / 38;
            return uurberekening*Startloon;
        }
        public virtual double Ancienniteit()
        {
            double ancienniteit = Uurberekendstartloon();
            int aantaljaren = DateTime.Now.Year - Indiensttreding.Year;

            for (int i = 1; i <= aantaljaren; i++)
            {
                ancienniteit *= 1.01;
            }
            ancienniteit -= Uurberekendstartloon();
            return Math.Round(ancienniteit, 2);
        }
        public virtual double NaSocialeZekerheid()
        {
            double Nasociale = Uurberekendstartloon() + Ancienniteit();
            Nasociale -= 200;
            return Math.Round(Nasociale, 2);
        }
        
        public virtual double Bedrijfsvoorheffing()
        {
            return NaSocialeZekerheid() * 0.1368;
        }
        public virtual double Netto()
        {
            double netto = NaSocialeZekerheid()- Bedrijfsvoorheffing();
            return Math.Round(netto, 2);
        }
        public virtual string Beschrijf()
        {
            string beschrijf = "";
            beschrijf =
                  $"NAAM                 :{Naam}" + "\n"
                + $"GESLACHT              :{Geslacht}" + "\n"
                + $"GEBOORTEDATUM        :{GeboorteDatum.ToString("dd/MM/yyyy")}" + "\n"
                + $"RIJKSREGISTERNUMMER   :{RijksRegisterNummer}" + "\n"
                + $"INDATUMINDIENSTTREDING:{Indiensttreding.ToString("dd/MM/yyyy")}" + "\n"
                + $"FUNCTIE               :{Functie}" + "\n"
                + $"TYPECONTRACT          :{Typecontract}" + "\n"
                + $"IBANNUMMER          :{IbanNummer}" + "\n";
            return beschrijf;
        }
        public virtual string Loonbrieven()
        {
            string beschrijf = "";
            beschrijf =
            $"STARTLOON                :€ {Uurberekendstartloon()}" + "\n"
           + $"ANCIENNITEIT            :€ {Math.Round(Ancienniteit(), 2)}" + "\n"
           + $"SOCIALE ZEKERHEID       :€200" + "\n"
           + $"NASOCIALEZEKERHEID      :€{ NaSocialeZekerheid()}" + "\n"
           + $"BEDRIJFSVOORHEFFING     :€{Math.Round(Bedrijfsvoorheffing(),2)}" + "\n"
           + $"NETTOLOON               :€{Netto()}";
            return beschrijf;
        }
        public void MaakLoonBrief(string bestandsLocatie)
        {
            string bestandsNaam = bestandsLocatie + $"LOONBRIEF  {Naam} {RijksRegisterNummer} {DateTime.Now.ToString("MM yyyy")}.txt";
            using (StreamWriter writer = new StreamWriter(bestandsNaam))
            {
                writer.WriteLine("-----------------------------------------------------------");
                writer.WriteLine($"NAAM                     :{Naam}");
                writer.WriteLine($"GESLACHT                 :{Geslacht}");
                writer.WriteLine($"GEBOORTEDATUM            :{GeboorteDatum.ToShortDateString()}");
                writer.WriteLine($"RIJKSREGISTERNUMMER      :{RijksRegisterNummer}");
                writer.WriteLine($"DATUM INDIENSTTREDING    :{Indiensttreding.ToShortDateString()}");
                writer.WriteLine($"FUNCTIE                  :{Functie}");
                writer.WriteLine($"TYPECONTRACT             :{Typecontract}");
                writer.WriteLine($"AANTAL GEPRESTEERDE UREN :{AantalGepresenteerdUren}");
                writer.WriteLine($"IBANNUMMER               :{IbanNummer}");
                if (Functie == "Programmeur")
                {
                    writer.WriteLine($"BEDRIJFSWAGEN            :{(Bedrijfswagen ? "Ja" : "Nee")}");
                }
                writer.WriteLine("-----------------------------------------------------------");
                writer.WriteLine($"STARTLOON                :   € {Math.Round(Uurberekendstartloon(), 2)}");
                writer.WriteLine($"ANCIËNNITEIT             : + € {Math.Round(Ancienniteit(), 2)}");
                writer.WriteLine($"                             €{Math.Round(Uurberekendstartloon() + Ancienniteit(), 2)}");
                writer.WriteLine($"SOCIALE ZEKERHEID        : - €200");
                writer.WriteLine($"                             €{Math.Round(NaSocialeZekerheid())}");
                writer.WriteLine($"BEDRIJFSVOORHEFFING      : - €{Math.Round(Bedrijfsvoorheffing(), 2)}");
                if (Functie.ToLower().Contains("support"))
                {
                    writer.WriteLine("THUISWERKTWEEDAGEN           :+ €50");
                    if (Functie.ToLower() == "customersupport")
                    {
                        writer.WriteLine("OPLEIDING            :+€19.50");
                    }
                }
                writer.WriteLine($"NETTOLOON                :   €{Math.Round(Netto(), 2)}");

                writer.WriteLine("-----------------------------------------------------------");
            }
        }
    }
}
