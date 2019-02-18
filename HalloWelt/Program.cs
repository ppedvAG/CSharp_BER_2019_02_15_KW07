//Mittels der USING-Anweisungen kann ein vereinfachter Zugriff auf Programm-Externe Klassen ermöglicht werden. Es muss nun nicht mehr der
///vollständige Pfad angegeben werden, sondern es reicht der Klassenbezeichner
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//NAMESPACE: Die Umgebung unseres aktuellen Programms: Alles innerhalb des Namespaces gehört zu dem Programm
namespace HalloWelt
{
    //Die PROGRAM-Klasse beinhaltet den Einstiegspunkt des Programms und muss in jedem C#-Programm vorhanden sein
    class Program
    {
        //Die MAIN()-Methode ist der Einstiegspunkt jedes C#-Programms: Hier beginnt das Programm IMMER
        static void Main(string[] args)
        {
            //Deklaration einer Integer-Variable 
            int alter;
            //Initialisierung der Integer-Variablen
            alter = 29;
            //Gleichzeitige Deklaration und Initialisierung einer String-Variablen
            string stadt = "Berlin";

            //Ausgabe einer Integer-Variablen
            Console.WriteLine(alter);
            //Ausgabe eines String-Literals
            Console.WriteLine("Hallo Welt");
            //Ausgabe einer String-Variablen
            Console.WriteLine(stadt);

            ///Einfügen dynamischer Inhalte in Strings
            //'traditionell' (Verknüpfung mittels +-Operator)
            Console.WriteLine("Ich bin " + alter + " Jahre alt und wohne in " + stadt + ".");
            //Indexschreibweise ({Indizies} werden durch hintenan gestellte Variablen ersetzt)
            Console.WriteLine("Ich bin {0} Jahre alt und wohne in {1}.", alter, stadt);
            //$-Operator (Variablen können direkt in {} gesetzt werden)
            Console.WriteLine($"Ich bin {alter} Jahre alt und wohne in {stadt}.");

            //Ausgabe einer Berchnung in Strings
            int a = 15;
            int b = 23;
            Console.WriteLine($"Das Ergebnis ist {a + b}");

            //String-Formatierung mittels Escape-Sequenzen
            Console.WriteLine("Dies ist ein\nZeilenumbruch und dies ein horizontaler\tTabulator \\");

            //String-Formatierung mittels VerbaTim-String (Einleitung mittels @ / Escape-Sequenzen sind nicht möglich, 
            ///dynamische Inhalte mittels $ schon)
            Console.WriteLine($@"Dies ist ein
 Zeilenumbruch und dies ein         horizontaler Tabulator. \\");


            //Eingabe eines Strings durch den Benutzer und Abspeichern in einer String-Variablen
            Console.WriteLine("Bitte gib einen String ein: ");
            string input = Console.ReadLine();
            Console.WriteLine(input);

            //Umwandlung eines numerischen (!) Strings in einen Integerwert
            int inputAsInt = int.Parse(input);
            Console.WriteLine(inputAsInt * 10);

            //Programmpause
            Console.ReadKey();
        }
    }
}
