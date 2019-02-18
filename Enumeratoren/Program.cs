using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeratoren
{
    //ENUMERATOREN sind spezialisierte selbst-definierte Datentypen mit festgelegten möglichen Zuständen.
    ///Dabei ist jeder Zustand an einen Integer-Wert gekoppelt, wodurch eine explizite Umwandlung (Cast) möglich ist.
    enum Wochentag { Montag = 1, Dienstag, Mittwoch, Donnerstag, Freitag, Samstag, Sonntag }

    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration und Initialisierung einer Variablen vom Enumerator-Typ
            Wochentag heute = Wochentag.Mittwoch;
            Console.WriteLine(heute);

            //Cast: Int -> Wochentag
            Wochentag morgen = (Wochentag)4;
            Console.WriteLine(morgen);

            //For-Schleife über die möglichen Zustande des Enumerators
            Console.WriteLine("Wähle einen Wochentag aus: ");
            for (int i = 1; i <= Enum.GetValues(typeof(Wochentag)).Length; i++)
            {
                Console.WriteLine($"{i}: {(Wochentag)i}");
            }

            //Speichern einer Benutzereingabe (Int) als Enumerator
            heute = (Wochentag)int.Parse(Console.ReadLine());

            Console.WriteLine($"Du hast {heute} gewählt.");

            //Bsp für Vergleichsoperaton eines Enumeratorzustandes
            if (heute < Wochentag.Donnerstag)
            {
                Console.WriteLine("Die Woche dauert noch");
            }

            //SWITCHs sind eine verkürzte Schreibweise für IF-ELSE-Blöcke. Mögliche Zustände der übergebenen Variablen werden 
            //in den CASES definiert
            switch (heute)
            {
                case Wochentag.Montag:
                    Console.WriteLine("Schönen Wochenstart");
                    //Jeder speziell definierte CASE muss mit einer BREAK-Anweisung beendet werden
                    break;
                //Wenn in einem CASE keine Anweisungen geschrieben stehen kann auf den BREAK-Befehl verzichtet werden. In diesem Fall
                //springt das Programm in diesem CASE zum Nachfolgenden
                case Wochentag.Dienstag:
                case Wochentag.Mittwoch:
                case Wochentag.Donnerstag:
                    Console.WriteLine("Arbeit, Arbeit");
                    break;
                //Wenn die übergebene Variable keinen der vordefinierten Zustände erreicht, wird der DEFAULT-Fall ausgeführt
                default:
                    Console.WriteLine("Schönes Wochenende");
                    break;
            }

            string wort = "Hallo";

            //Mittels des WHEN-Stichworts kann auf Eigenschaften des betrachteten Objekts näher eingegangen werden
            switch (wort)
            {
                case string b when b.Length < 5:
                    Console.WriteLine(wort);
                    break;
                default:
                    break;
            }

            //Programmpause
            Console.ReadKey();
        }
    }
}
