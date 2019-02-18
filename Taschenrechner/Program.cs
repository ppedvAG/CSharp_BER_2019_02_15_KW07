using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner
{
    //Definition des Enumerator-Datentyps 'Rechenoperation'
    enum Rechenoperation { Addition = 1, Subtraktion, Multiplikation, Division }
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration der benötigten Variablen
            double zahl1, zahl2, ergebnis;
            Rechenoperation op;

            //Abfragen der Zahlen über Benutzereingabe
            Console.Write("Gib eine Zahl ein: ");
            zahl1 = double.Parse(Console.ReadLine());
            Console.Write("Gib eine weitere Zahl ein: ");
            zahl2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Wähle eine Rechenoperation aus: ");
            //Präsentation der möglichen Optionen
            for (int i = 1; i < 5; i++)
            {
                Console.WriteLine($"{i}: {(Rechenoperation)i}");
            }
            //Abfragen der gewünschten Operation über Benutzereingabe und Cast 
            op = (Rechenoperation)int.Parse(Console.ReadLine());

            //Aufruf der Berechne()-Funktion mit Übergabe der Zahlen und der gewählten Operation und Speichern des Rückgabewerts
            ergebnis = Berechne(zahl1, zahl2, op);
            if (double.IsNaN(ergebnis))
                Console.WriteLine("Fehlerhafte Eingabe");
            else
                //Ausgabe des Ergebnisses
                Console.WriteLine("Ergebnis: " + ergebnis);

            //Programmpause
            Console.ReadKey();
        }

        //Funktion zur Berechnung der gewählten Operation
        public static double Berechne(double a, double b, Rechenoperation operation)
        {
            //Verzweigung je nach gewählter Operation
            switch (operation)
            {
                case Rechenoperation.Addition:
                    return a + b;
                case Rechenoperation.Subtraktion:
                    return a - b;
                case Rechenoperation.Multiplikation:
                    return a * b;
                case Rechenoperation.Division:
                    return a / b;
                default:
                    //Rückgabe der Double-Konstanten 'NaN' (Not A Number) bei fehlerhafter Eingabe durch den Benutzer
                    return double.NaN;
            }
        }
    }
}
