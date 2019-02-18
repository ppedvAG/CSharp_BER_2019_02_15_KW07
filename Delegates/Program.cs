using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        //Ein DELEGATE ist eine Variable, in welcher man Funktionen mit einem gleichen Methodenkopf speichern kann. Eigene Delegate-Typen müssen
        ///vorher definiert werden.
        public delegate int MeinDelegate(int x, int y);

        static void Main(string[] args)
        {
            //Zuweisung der Addiere()-Methode zur einer Variablen vom Typ MyDelegate
            MeinDelegate delegateVariable = new MeinDelegate(Addiere);

            //Ausführung der Delegate-Variablen
            int ergebnis = delegateVariable(12, 45);
            Console.WriteLine(ergebnis);

            //Neuzuweisung der Variable (Kurzschreibweise)
            delegateVariable = Subtrahiere;

            ergebnis = delegateVariable(12, 45);
            Console.WriteLine(ergebnis);

            //Zuweisung einer zweiten Methode zur Delegate-Variablen
            delegateVariable += Addiere;

            //Bei Ausführung einer Delegate-Variablen werden alle referenzierten Methoden in der Reihenfolge ihrer Zuweisung ausgeführt.
            ///Nur die letzte Methode gibt einen Rückgabewert zurück
            ergebnis = delegateVariable(12, 45);
            Console.WriteLine(ergebnis);

            //Erstellung und Ausgabe einer Liste der in der Variablen gespeicherten Methode
            var Methodenliste = delegateVariable.GetInvocationList().ToList();
            foreach (var item in Methodenliste)
            {
                Console.WriteLine(item.Method);
                Debug.Print(item.Method.ToString());
            }

            //Löschen einer Referenz aus der Variablen
            delegateVariable -= Addiere;
            //Löschen aller Zuweisungen
            delegateVariable = null;

            //FUNC<> / ACTION<> /PREDICATE<> sind die von C# vordefinierten Delegate-Typen
            Func<int, int, int> meinFunc = Addiere;
            ergebnis = meinFunc(12, 45);
            Console.WriteLine(ergebnis);

            FühreAus(meinFunc);
            FühreAus(Addiere);

            List<string> städteListe = new List<string>() { "Berlin", "München", "Köln", "Bonn" };

            //ANONYME METHODEN sind Methoden, welche nicht mit Kopf und Körper geschrieben stehen, sondern nur innerhalb von Delegate-Variablen
            ///existieren

            //Übergabe einer Methode an eine andere Methode
            string gefundeneStadt = städteListe.Find(SucheStadtMitM);
            Console.WriteLine(gefundeneStadt);

            //Übergabe der Methode als anonyme Methode
            gefundeneStadt = städteListe.Find(
                delegate (string stadt)
                {
                    return stadt.StartsWith("M");
                });

            //Übergabe der anonymen Methode in LAMBDA-Schreibweise (Lang und Kurz)
            gefundeneStadt = städteListe.Find((string stadt) => { return stadt.StartsWith("M"); });
            gefundeneStadt = städteListe.Find(stadt => stadt.StartsWith("M"));

            //Weiteres Bsp für die Übergabe einer anonymen Methode in Lambda (Sortierung der Einträge nach dem ersten Buchstaben)
            städteListe = städteListe.OrderBy(stadt => stadt[0]).ToList();
            foreach (var item in städteListe)
            {
                Console.WriteLine(item);
            }

            //weiteres Bsp der Lambda-Schreibweise (Methode empfängt zwei int und gibt deren Summe als String zurück)
            Func<int, int, string> funky = (x, y) => (x + y).ToString();

            Console.ReadKey();

        }

        //Bsp-Methode zur Übergabe an eine Liste
        public static bool SucheStadtMitM(string stadt)
        {
            return stadt.StartsWith("M");
        }

        //Funktion mit Delegate-Übergabeparameter
        public static void FühreAus(Func<int, int, int> methode)
        {
            Console.WriteLine(methode(45, 78));
        }

        //Funktion mit Delegate-Rückgabewert
        public static Func<int, int, int> BaueFunc()
        {
            return Addiere;
        }

        //Bsp-Methoden zur Demonstration der Delegate-Funktionalität
        public static int Addiere(int a, int b)
        {
            Console.WriteLine("Addition");
            return a + b;
        }

        public static int Subtrahiere(int a, int b)
        {
            Console.WriteLine("Subtraktion");
            return a - b;
        }
    }
}
