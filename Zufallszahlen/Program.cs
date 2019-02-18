using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zufallszahlen
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration und Initialisierung eines Random-Objekts mittels Konstruktor-Aufruf (vgl. Modul 04)
            Random generator = new Random();
            int benutzerZahl;
            //Aufruf der Würfel-Funktion des Random-Objekts (beachte: 1. Grenze inklusiv / 2. Grenze exklusiv)
            int zufallZahl = generator.Next(1, 6);

            //Schleife für erneuten Versuch
            do
            {
                //Abfrage des Tipps des Benutzers
                Console.Write("Bitte gib eine Zahl zwischen 1 und 5 ein: ");
                benutzerZahl = int.Parse(Console.ReadLine());

                //Vergleich Tipp <> Zufallszahl mittels If
                if (zufallZahl == benutzerZahl)
                {
                    Console.WriteLine("Herzlichen Glückwunsch. Deine Zahl ist richtig.");
                }
                else if (zufallZahl < benutzerZahl)
                {
                    Console.WriteLine("Deine Zahl ist zu groß");
                }
                else
                {
                    Console.WriteLine("Deine Zahl ist zu klein");
                }
                //Bedingung für neuen Versuch
            } while (zufallZahl != benutzerZahl);
            
            Console.ReadKey();
        }
    }
}
