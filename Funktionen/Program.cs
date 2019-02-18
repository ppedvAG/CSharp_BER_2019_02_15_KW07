using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funktionen
{
    class Program
    {
        //Jede Funktion/Methode besteht aus einem Kopf und einem Körper
        ///Der Kopf besteht aus den MODIFIERN (public static), dem RÜCKGABEWERT (int), dem NAMEN (Addiere) sowie den ÜBERGABEPARAMETERN
        ///Wird einem Parameter mittels =-Zeichen ein Defaultwert zugewiesen wird dieser Parameter OPTIONAL und muss bei Aufruf nicht zwangs-
        ///läufig mitgegeben werden. OPTIONALE Parameter müssen am Ende der Parameter stehen.
        public static int Addiere(int a, int b, int c = 0, int d = 0)
        {
            //Der RETURN-Befehl weist die Methode an einen Wert als Rückgabewert an den Aufrufe zurückzugeben
            return a + b + c + d;
        }

        //Funktion, welche den gleichen Bezeichner haben, nennt man ÜBERLADENE Funktionen. Diese müssen sich in Anzahl und/oder Art der 
        ///Übergabeparameter unterscheiden, damit der Aufruf eindeutig ist.
        public static double Addiere(double a, double b)
        {
            return a + b;
        }

        //Das OUT-Stichwort ermöglich einer Methode mehr als einen Rückgabewert zu haben. Dabei kann die Variable direkt in der Funktions-
        ///übergabe deklariert werden
        public static int AddiereUndSubtrahiere(int a, int b, out int diff)
        {
            diff = a - b;
            return a + b;
        }

        static void Main(string[] args)
        {
            //Funktionsaufruf mit zwei Übergabeparametern und Speichern des Rückgabewerts
            int erg = Addiere(12, 45);
            Console.WriteLine(erg);

            double erg2 = Addiere(12.2, 15.5);

            //Aufruf der Out-Funktion
            int summe = AddiereUndSubtrahiere(12, 10, out int differenz);
            Console.WriteLine("Summe: " + summe + " Differenz: " + differenz);

            //TryParse() als Bsp für Out-Verwendung
            if (int.TryParse(Console.ReadLine(),out int eingabe))
            {
                Console.WriteLine(eingabe*2);
            }

            //Programmpause
            Console.ReadKey();
        }

    }
}
