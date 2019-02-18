using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fahrzeugpark;

namespace TesteFahrzeugpark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            #region Modul04 - OOP-Programmierung
            ////Instanzierung von Fahrzeugen
            //Fahrzeug fz = new Fahrzeug("BMW", 270);
            //Fahrzeug fz1 = new Fahrzeug("Mercedes", 310);

            ////Ausgabe der Maximalgeschwindigkeit von fz
            //Console.WriteLine(fz.MaxGeschwindigkeit);

            ////Änderung des Namens von fz1
            //fz.Name = "VW";

            ////Ausgabe der BeschreibeMich()-Methoden der Fahrzeuge
            //Console.WriteLine(fz.BeschreibeMich());
            //Console.WriteLine(fz1.BeschreibeMich());

            ////Neuzuweisung der fz1-Variable auf Objekt in fz-Variable
            //fz1 = fz;

            ////Manueller Aufruf der Garbage Collection
            //GC.Collect();
            #endregion

            #region Lab04 - Fahrzeug-Klasse

            ////Deklaration einer Fahrzeug-Variablen und Initialisierung mittels einer Fahrzeug-Instanz
            //Fahrzeug fz1 = new Fahrzeug("Mercedes", 190, 23000);
            ////Ausführen der BeschreibeMich()-Methode des Fahrzeugs und Ausgabe in der Konsole
            //Console.WriteLine(fz1.BeschreibeMich());

            ////Diverse Methodenausführungen
            //fz1.StarteMotor();
            //fz1.Beschleunige(120);
            //Console.WriteLine(fz1.BeschreibeMich());

            //fz1.Beschleunige(300);
            //Console.WriteLine(fz1.BeschreibeMich());

            //fz1.StoppeMotor();
            //Console.WriteLine(fz1.BeschreibeMich());

            #endregion

            #region Modul05 - Vererbung
            //PKW pkw1 = new PKW("BMW", 190, 23000);

            //Console.WriteLine(pkw1.BeschreibeMich());

            //Console.WriteLine(pkw1);

            //Console.WriteLine(Fahrzeug.AnzahlFahrzeuge); 
            #endregion

            #region Lab05 - PKW-, Schiff- und Flugzeug-Klasse

            //PKW pkw1 = new PKW("BMW", 250, 23000);
            //Console.WriteLine(pkw1.BeschreibeMich());

            //Schiff schiff1 = new Schiff("Titanic", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf);
            //Console.WriteLine(schiff1.BeschreibeMich());

            //Flugzeug flugzeug1 = new Flugzeug("Boing", 750, 3000000, 9990);
            //Console.WriteLine(flugzeug1.BeschreibeMich());

            //Console.WriteLine(Fahrzeug.ZeigeAnzahlFahrzeuge());

            #endregion

            #region Modul06 - Polymorphismus
            //PKW pkw = new PKW("BMW", 200, 24000);

            //Fahrzeug fahrzeug = pkw;

            //IBewegbar bewegbaresObjekt = pkw;

            //RadAb(pkw);
            #endregion

            #region Lab06 IBeladbar

            //PKW pkw1 = new PKW("BMW", 250, 23000);
            //Flugzeug flugzeug1 = new Flugzeug("Boing", 750, 3000000, 9990);
            //Schiff schiff1 = new Schiff("Titanic", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf);

            //BeladeFahrzeuge(pkw1, flugzeug1);
            //BeladeFahrzeuge(flugzeug1, schiff1);
            //BeladeFahrzeuge(schiff1, pkw1);

            //Console.WriteLine("\n" + schiff1.BeschreibeMich());

            #endregion

            #region Modul07 - Generische Listen
            //PKW pkw1 = new PKW("BMW", 250, 23000);
            //Flugzeug flugzeug1 = new Flugzeug("Boing", 750, 3000000, 9990);
            //Schiff schiff1 = new Schiff("Titanic", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf);

            //List<Fahrzeug> fahrzeugListe = new List<Fahrzeug>();

            //fahrzeugListe.Add(pkw1);
            //fahrzeugListe.Add(flugzeug1);
            //fahrzeugListe.Add(schiff1);
            //fahrzeugListe.Add(new PKW("VW", 180, 23999));

            //foreach (var item in fahrzeugListe)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //fahrzeugListe[1].Name = "Airbus";

            //Console.WriteLine(fahrzeugListe.Count); 
            #endregion

            #region Lab07 - Zufällige Fahrzeuglisten

            ////Deklaration der benötigten Variablen und und Initialisierung mit Instanzen der benötigten Objekte
            //Random generator = new Random();
            //Queue<Fahrzeug> fzQueue = new Queue<Fahrzeug>();
            //Stack<Fahrzeug> fzStack = new Stack<Fahrzeug>();
            //Dictionary<Fahrzeug, Fahrzeug> fzDict = new Dictionary<Fahrzeug, Fahrzeug>();
            ////Deklaration und Initialisierung einer Variablen zur Bestimmung der Anzahl der Durchläufe 
            //int AnzahlFZs = 10;

            ////Schleife zur zufälligen Befüllung von Queue und Stack
            //for (int i = 0; i < AnzahlFZs; i++)
            //{
            //    //Würfeln einer zufälligen Zahl im Switch
            //    switch (generator.Next(1, 4))
            //    {
            //        //Erzeugung von Objekten je nach zufälliger Zahl
            //        case 1:
            //            fzQueue.Enqueue(new Flugzeug($"Boing_Q{i}", 800, 3600000, 9999));
            //            fzStack.Push(new Flugzeug($"Boing_S{i}", 800, 3600000, 9999));
            //            break;
            //        case 2:
            //            fzQueue.Enqueue(new Schiff($"Titanic_Q{i}", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf));
            //            fzStack.Push(new Schiff($"Titanic_S{i}", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf));
            //            break;
            //        case 3:
            //            fzQueue.Enqueue(PKW.ErzeugeZufälligenPKW($"_Q{i}"));
            //            fzStack.Push(PKW.ErzeugeZufälligenPKW($"_S{i}"));
            //            break;
            //    }
            //}

            ////Schleife zur Prüfung auf das Interface und Befüllung des Dictionaries
            //for (int i = 0; i < AnzahlFZs; i++)
            //{
            //    //Prüfung, ob das Interface vorhanden ist (mittels Peek(), da die Objekte noch benötigt werden)...
            //    if (fzQueue.Peek() is IBeladbar)
            //    {
            //        //...wenn ja, dann Cast in das Interface und Ausführung der Belade()-Methode (mittels Peek())...
            //        ((IBeladbar)fzQueue.Peek()).Belade(fzStack.Peek());
            //        //...sowie Hinzufügen zum Dictionary (mittels Pop()/Dequeue(), um beim nächsten Durchlauf andere Objekte an den Spitzen zu haben)
            //        fzDict.Add(fzQueue.Dequeue(), fzStack.Pop());
            //    }
            //    else
            //    {
            //        //... wenn nein, dann Löschung der obersten Objekte (mittels Pop()/Dequeue())
            //        fzQueue.Dequeue();
            //        fzStack.Pop();
            //    }
            //}

            ////Programmpause
            //Console.ReadKey();
            //Console.WriteLine("\n----------LADELISTE----------");

            ////Schleife zur Ausgabe des Dictionaries
            //foreach (var item in fzDict)
            //{
            //    Console.WriteLine($"'{item.Key.Name}' hat '{item.Value.Name}' geladen.");
            //}

            #endregion

            //Vorbereitung
            Random generator = new Random();
            Flugzeug fz = new Flugzeug("Boing", 999, 500000000, 9999);
            Flugzeug fz2 = fz;
            Flugzeug flugzeug1 = new Flugzeug("Boing", 980, 3000000000, 9990);
            flugzeug1.PassagierListe.Add("Hugo");
            flugzeug1.PassagierListe.Add("Anna");
            flugzeug1.PassagierListe.Add("Otto");
            flugzeug1.PassagierListe.Add("Maria");

            //Bsp für die Verwendung der Indexer-Property (vgl. Flugzeug-Klasse)
            Console.WriteLine(flugzeug1[2]);

            //Bsp für die Verwendung von IEnumerable (vgl. Flugzeug-Klasse)
            foreach (var item in flugzeug1)
            {
                Console.WriteLine(item);
            }

            //Bsp für die Verwendung der in der Fahrzeug-Klasse definierten Operatoren
            Console.WriteLine(fz == fz2);
            Console.WriteLine(fz == new Flugzeug("Boing", 999, 500000000, 9999));

            //Bsp für die Verwendung einer Erweiterungsmethode (s.u.)
            Console.WriteLine(generator.NextInclusive(12, 45));

            //Programmpause
            Console.ReadKey();

        }

        //Methode Lab06
        public static void BeladeFahrzeuge(Fahrzeug fz1, Fahrzeug fz2)
        {
            if (fz1 is IBeladbar)
            {
                ////Vollständige Schreibweise des Casts mit Zwischenspeichern in Variable
                //IBeladbar beladbaresObj = (IBeladbar)fz1;
                //beladbaresObj.Belade(fz2);

                ////Kurzschreibweise
                ((IBeladbar)fz1).Belade(fz2);
            }
            else if (fz2 is IBeladbar)
            {
                //Alterb´nativer Cast (funktioniert nur bei nullbaren Typen)
                (fz2 as IBeladbar).Belade(fz1);
            }
            else
                Console.WriteLine("Keines der Fahrzeuge kann ein Fahrzeug transportieren.");
        }

        //Bsp-Methode Modul06
        public static void RadAb(IBewegbar bewegbar)
        {
            bewegbar.RäderAnzahl--;

            if (bewegbar is Fahrzeug)
            {
                Fahrzeug fz = (Fahrzeug)bewegbar;

                Console.WriteLine($"{fz.Name} hat einen Reifen verloren.");
            }
        }
    }

    public static class Hilfsklasse
    {
        //Mittels des THIS-Stichworts in der Parameterübergabe kann eine Methode als Erweiterungsmethode einer Klasse definiert
        //werden. Diese muss in einer statischen Klasse beschrieben werden und wird dann als Teil der zugeordneten Klasse betrachtet.
        public static int NextInclusive(this Random generator, int untergrenze, int obergrenze)
        {
            return generator.Next(untergrenze, obergrenze + 1);
        }
    }
}
