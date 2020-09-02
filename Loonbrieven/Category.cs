using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loonbrieven
{
   public class Category
    {
        public string CategoryNaam { get; set; }
        public List<Werknemer> WerknemersLijst { get; set; }

        public Category(string categoryNaam)
        {
            CategoryNaam = categoryNaam;
            WerknemersLijst = new List<Werknemer>();
        }
        
        public void WerknemerRemove(Werknemer nieuwewerknemer)
        {
            WerknemersLijst.Remove(nieuwewerknemer);
        }
        public void WerknemerAdd(Werknemer nieuwewerknemer)
        {
            WerknemersLijst.Add(nieuwewerknemer);

        }
        public override string ToString()
        {
            return CategoryNaam;
        }

    }
}
