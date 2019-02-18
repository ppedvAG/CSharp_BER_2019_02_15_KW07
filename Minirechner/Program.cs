using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minirechner
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deklaration der Variablen
            int zahl1;
            double zahl2;

            //Initialisierung der Variablen über Benutzereingabe
            Console.Write("Bitte gib eine ganze Zahl ein: ");
            zahl1 = int.Parse(Console.ReadLine());
            Console.Write("Bitte gib eine Kommazahl ein: ");
            zahl2 = double.Parse(Console.ReadLine());

            //Berechnung und Ausgabe der Summen:
            Console.WriteLine($"\nSumme als Integer: {(int)(zahl1 + zahl2)}");
            Console.WriteLine($"Summe als Double: {zahl1 + zahl2}\n");

            //Berechnung und Ausgabe der Division:
            double max = Math.Max(zahl1, zahl2);
            double min = Math.Min(zahl1, zahl2);
            double erg = max / min;
            Console.WriteLine($"{max} / {min} = {erg}");
            //Alternative:
            Console.WriteLine($"{Math.Max(zahl1, zahl2)} / {Math.Min(zahl1, zahl2)} = {Math.Max(zahl1, zahl2) / Math.Min(zahl1, zahl2)}");


            //Programmpause
            Console.ReadKey();
        }
    }
}
