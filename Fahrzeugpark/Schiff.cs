using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //vgl. auch PKW
    public class Schiff : Fahrzeug, IBeladbar
    {
        //Klassen-eigener Enumerator
        public enum SchiffsTreibstoff { Diesel = 0, Dampf, Wind, Muskelkraft }

        public SchiffsTreibstoff Treibstoff { get; set; }
        public Fahrzeug Ladung { get; set; }

        public Schiff(string name, int maxG, decimal preis, SchiffsTreibstoff treibstoff) : base(name, maxG, preis)
        {
            this.Treibstoff = treibstoff;
        }

        public override string BeschreibeMich()
        {
            if (this.Ladung == null)
                return "Das Schiff " + base.BeschreibeMich() + $" Es fährt mit {this.Treibstoff}.";
            else
                return "Das Schiff " + base.BeschreibeMich() + $" Es fährt mit {this.Treibstoff} und transportiert '{this.Ladung.Name}'.";
        }

        public override void Hupen()
        {
            Console.WriteLine("Trööööt");
        }

        public void Belade(Fahrzeug fz)
        {
            if (this.Ladung == null)
            {
                this.Ladung = fz;
                Console.WriteLine($"Ladevorgang von '{fz.Name}' auf '{this.Name}' erfolgreich.");
            }
            else
                Console.WriteLine($"Ladeplatz auf '{this.Name}' bereits durch '{this.Ladung.Name}' belegt.");
}

        public void Entlade()
        {
            if (this.Ladung != null)
            {
                Console.WriteLine($"Entladevorgang von '{this.Ladung.Name}' erfolgreich.");
                this.Ladung = null;
            }
            else
                Console.WriteLine($"'{this.Name} hat keine Ladung geladen.");
        }
    }
}
