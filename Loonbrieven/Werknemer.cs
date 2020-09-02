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
        public string IBANNummer { get; set; }
        public string Typecontract { get; set; }
        public double Startloon { get; set; }
        public double BedrijfsVoorheffing { get; set; }
        public double SocialeZekerheid { get; set; }
        public int AantalGepresenteerdUren { get; set; }
        public bool Bedrijfswagen { get; set; }
        public Werknemer(string naam, string geslacht, DateTime geboorteDatum, string rijksRegisterNummer, DateTime indiensttreding, int aantalGepresenteerdUren, bool bedrijfswagen, string functie = "Werknemer", string typecontract = "Voltijds", double startloon = 1900.00, double bedrijfsVoorheffing = 13.68, double socialeZekerheid = 200)
        {
            Naam = naam;
            Geslacht = geslacht;
            GeboorteDatum = geboorteDatum;
            RijksRegisterNummer = rijksRegisterNummer;
            Indiensttreding = indiensttreding;
            AantalGepresenteerdUren = aantalGepresenteerdUren;
            Bedrijfswagen = bedrijfswagen;
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
        public virtual double Uurberekening()
        {
            double uurberekening = 0;
            uurberekening = AantalGepresenteerdUren / 38 * Startloon;
            return Math.Round(uurberekening, 2);
        }
        public virtual double Ancienniteit()
        {
            int aantaljaren = 0;
            double ancienniteit = Uurberekening();
            aantaljaren = DateTime.Now.Year - Indiensttreding.Year;

            for (int i = 0; i < aantaljaren; i++)
            {
                ancienniteit *= 1.01;
            }
            ancienniteit -= Startloon;
            return Math.Round(ancienniteit, 2);
        }
        public virtual double NaSocialeZekerheid()
        {
            double Nasociale = Uurberekening() + Ancienniteit();
            Nasociale -= 200;
            return Math.Round(Nasociale, 2);
        }
        public virtual double Netto()
        {
            double netto = NaSocialeZekerheid();
            netto -= (netto * 0.1368);
            return Math.Round(netto, 2);
        }
        public virtual string Beschrijf()
        {
            string beschrijf = "";
            beschrijf =
                  $"Naam: {Naam}" + "\n"
                + $"Geslacht: {Geslacht}" + "\n"
                + $"GeboorteDatum: {GeboorteDatum.ToString("dd/MM/yyyy")}" + "\n"
                + $"RijksRegisterNummer: {RijksRegisterNummer}" + "\n"
                + $"InDatumIndiensttreding: {Indiensttreding.ToString("dd/MM/yyyy")}" + "\n"
                + $"Functie: {Functie}" + "\n"
                + $"TypeContract: {Typecontract}" + "\n";
            return beschrijf;
        }
        public virtual string Loonbrieven()
        {
            string beschrijf = "";
            beschrijf =
            $"STARTLOON                 :   € {Uurberekening()}" + "\n"
           + $"ANCIENNITEIT              : + € {Math.Round(Ancienniteit(), 2)}" + "\n"
           + $"                          :      € {Math.Round(Uurberekening() + Ancienniteit(), 2)}" + "\n"
           + $"SOCIALE ZEKERHEID         : - €200" + "\n"
           + $"                          :      €{Math.Round(Uurberekening() + Ancienniteit(), 2) - 200}" + "\n"
           + $"BEDRIJFSVOORHEFFING       : - €{Math.Round(NaSocialeZekerheid() * BedrijfsVoorheffing / 100, 2)}" + "\n"
           + $"                          :      €{Math.Round(Uurberekening() + Ancienniteit() - 200 - NaSocialeZekerheid() * BedrijfsVoorheffing / 100, 2)}" + "\n"
           + $"NETTOLOON                 :  €{Netto()}";
            return beschrijf;
        }
        public void MaakLoonBrief(string bestandsLocatie)
        {
            string bestandsNaam = bestandsLocatie + $"LOONBRIEF  {Naam} {RijksRegisterNummer} {DateTime.Now.ToString("MM yyyy")}.txt";
            using (StreamWriter writer = new StreamWriter(bestandsNaam))
            {
                writer.WriteLine("-----------------------------------------------------------");
                writer.WriteLine($"NAAM                     :{Naam}");
                writer.WriteLine($"RIJKSREGISTERNUMMER      :{RijksRegisterNummer}");
                writer.WriteLine($"GESLACHT                 :{Geslacht}");
                writer.WriteLine($"GEBOORTEDATUM            :{GeboorteDatum.ToShortDateString()}");
                writer.WriteLine($"DATUM INDIENSTTREDING    :{Indiensttreding.ToShortDateString()}");
                writer.WriteLine($"FUNCTIE                  :{Functie}");
                writer.WriteLine($"AANTAL GEPRESTEERDE UREN :{AantalGepresenteerdUren}");
                writer.WriteLine($"BEDRIJFSWAGEN            :{(Bedrijfswagen ? "Ja" : "Nee")}");
                writer.WriteLine("-----------------------------------------------------------");
                writer.WriteLine($"STARTLOON                :   € {Math.Round(Uurberekening(), 2)}");
                writer.WriteLine($"ANCIËNNITEIT             : + € {Math.Round(Ancienniteit(), 2)}");
                writer.WriteLine($"                             €{Math.Round(Uurberekening() + Ancienniteit(), 2)}");
                writer.WriteLine($"SOCIALE ZEKERHEID        : - €200");
                writer.WriteLine($"                             €{Math.Round(Uurberekening() + Ancienniteit(), 2) - 200}");
                writer.WriteLine($"BEDRIJFSVOORHEFFING      : - €{Math.Round(NaSocialeZekerheid() * BedrijfsVoorheffing / 100, 2)}");
                writer.WriteLine($"                             €{Math.Round(Uurberekening() + Ancienniteit() - 200 - NaSocialeZekerheid() * BedrijfsVoorheffing / 100, 2)}");
                writer.WriteLine($"NETTOLOON                :   €{Math.Round(Netto(), 2)}");

                writer.WriteLine("-----------------------------------------------------------");
            }
        }
    }
}
