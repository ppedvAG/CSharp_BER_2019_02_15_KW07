using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //PKW erbt mittels des :-Zeichens von der Fahrzeug-Klasse und übernimmt somit alle Eigenschaften und Methoden von dieser. Zusätzlich
    ///implementiert diese Klasse das Interface IBewegbar.
    public class PKW : Fahrzeug, IBewegbar
    {
        //Zusätzliche PKW-eigene Eigenschaft
        public int AnzahlInsassen { get; set; }
        //Durch Interface verlangte Eigenschaft
        public int RäderAnzahl { get; set; }

        //PKW-Konstruktor, welcher per BASE-Stichwort den Konstruktor der Fahrzeugklasse aufruft. Dieser erstellt dann ein Fahrzeug, gibt dies
        ///an diesen Konstruktor zurück, welcher dann die zusätzlichen Eigenschaften einfügt
        public PKW(string name, int maxG, decimal preis) : base(name, maxG, preis)
        {
            this.AnzahlInsassen = 2;
        }

        //Per OVERRIDE werden virtuelle und abstrakte Methoden der Mutterklasse überschrieben. Bei dem Methodenaufruf wir die Methode der
        ///Kindklasse aufgerufen
        public override string BeschreibeMich()
        {
            //Mittels des BASE-Stichworts wird auf die Methode der Mutterklasse zugegriffen
            return "Der PKW " + base.BeschreibeMich() + $" Er hat {this.AnzahlInsassen} Insassen.";
        }

        //Durch Mutterklasse geforderte (weil als ABSTRACT gesetzte) Funktion
        public override void Hupen()
        {
            Console.WriteLine("HupHup");
        }

        //Durch Interface verlangte Methode
        public void Bewegen()
        {
            Console.WriteLine("Der PKW fährt...");
        }

        //Statische Methode (gilt für die gesamte Klasse) zur Erstellung eines zufälligen PKWs 
        private static Random generator = new Random();
        public static PKW ErzeugeZufälligenPKW(string suffix = "")
        {
            string name;
            switch (generator.Next(1, 5))
            {
                case 1:
                    name = "BMW" + suffix;
                    break;
                case 2:
                    name = "Mercedes" + suffix;
                    break;
                case 3:
                    name = "Audi" + suffix;
                    break;
                default:
                    name = "VW" + suffix;
                    break;
            }
            return new PKW(name, generator.Next(15, 31) * 10, generator.Next(15, 30) * 1000);
        }
    }
}
