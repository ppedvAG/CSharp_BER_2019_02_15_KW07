using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //KLASSEN sind Vorlagen für OOP-Objekte. Hier wird das Aussehen, das Verhalten und der Startzustand für Objekte dieses Typs definiert.
    //Von einer als ABSTRACT gesetzten Klasse können keine Objekte instanziiert werden. Sie ist rein zur Vererbung gedacht.
    public abstract class Fahrzeug
    {
        #region Statische Member
        //Als STATIC markierte Variablen und Methoden hängen an der Klasse selbst und nicht an instanziierten Objekten.
        public static int AnzahlFahrzeuge { get; set; } = 0;

        public static string ZeigeAnzahlFahrzeuge()
        {
            return "Es wurden " + AnzahlFahrzeuge + " Fahrzeuge produziert.";
        }

        //Mittels des OPERATOR-Stichworts können für einzelne Klassen Operatoren definiert werden
        //(Für Verwendung siehe TesteFahrzeugpark)
        public static bool operator ==(Fahrzeug fz1, Fahrzeug fz2)
        {
            return fz1.Equals(fz2);
        }

        public static bool operator !=(Fahrzeug fz1, Fahrzeug fz2)
        {
            return !fz1.Equals(fz2);
        }

        #endregion

        #region Felder und Eigenschaften
        //FELDER (Membervariablen) sind die Variablen einzelner Objekte, welche die Zustände dieser Objekte definieren
        private int maxGeschwingkeit;
        //EIGENSCHAFTEN (Properties) definieren mittels Getter/Setter den Lese-/Schreibzugriff für jeweils ein Feld.
        ///In den Eigenschaften können bestimmte Bedingungen für das Lesen und Schreiben der Felder gesetzt werden, sowie der Zugriff
        ///für Lesen und Schreiben einzeln angepasst werden
        public int MaxGeschwindigkeit
        {
            get { return maxGeschwingkeit; }
            set
            {
                //Das Schlüsselwort VALUE beschreibt in einer Set-Methode den übergebenen Wert
                if (value >= 0)
                    maxGeschwingkeit = value;
            }
        }

        //Wird in einer Eigenschaft keine Spezifizierung angegeben, generiert das Programm das entsprechende Feld unsichtbar im Hintergrund
        public string Name { get; set; }
        public int AktGeschwindigkeit { get; set; }
        public decimal Preis { get; set; }
        public bool MotorLäuft { get; set; } //:= Zustand  
        #endregion

        #region Konstruktor und Destruktor
        //KONSTRUKTOREN sind spezielle Methoden, welche ein neues Objekt instanziiert und den Anfangszustand festlegt. Sie definieren sich
        ///durch den Namen (derselbe, wie die Klasse) und den nicht vorhandenen Rückgabetyp (nicht mal void)
        public Fahrzeug(string name, int maxG, decimal preis)
        {
            this.Name = name;
            this.MaxGeschwindigkeit = maxG;
            this.Preis = preis;
            this.AktGeschwindigkeit = 0;
            this.MotorLäuft = false;

            AnzahlFahrzeuge++;
        }

        //Es können mehrere Konstruktoren definiert werden, welche unterschiedliche Übergabeparameter haben (Überladung). Ein Konstruktor, der keine
        //Übergabeparameter hat, wird als Basiskonstruktor bezeichnet
        public Fahrzeug()
        {
            //..
        }

        //Der DESTRUKTOR wird von der GarbageCollection aufgerufen, wenn ein Objekt aus dem Speicher gelöscht wird. Der Destruktor wird 
        ///automatisch (unsichtbar) erzeugt und muss nur selbst geschrieben werden, wenn neben der Objektzerstörung noch andere Anweisungen
        ///ausgeführt werden sollen.
        ~Fahrzeug()
        {
            Console.WriteLine($"{this.Name} wurde zerstört.");
        }
        #endregion

        #region Methoden
        //MEMBERMETHODEN sind Funktionen, welche jedes Objekt einer Klasse besitzt und speziell dieses Objekt manipuliert
        public void Beschleunige(int a)
        {
            if (this.MotorLäuft)
            {
                if (this.AktGeschwindigkeit + a > this.MaxGeschwindigkeit)
                    this.AktGeschwindigkeit = this.MaxGeschwindigkeit;
                else if (this.AktGeschwindigkeit + a < 0)
                    this.AktGeschwindigkeit = 0;
                else
                    this.AktGeschwindigkeit += a;
            }
        }

        public void StarteMotor()
        {
            this.MotorLäuft = true;
        }

        public void StoppeMotor()
        {
            this.MotorLäuft = false;
            this.AktGeschwindigkeit = 0;
        }

        //Eine als VIRTUAL gesetzte Methode erlaubt den Kindklassen diese per OVERRIDE zu überschreiben
        public virtual string BeschreibeMich()
        {
            if (this.MotorLäuft)
                return $"'{this.Name}' fährt mit {this.AktGeschwindigkeit} von {this.MaxGeschwindigkeit}km/h und kostet {this.Preis}€.";
            else
                return $"'{this.Name}' könnte mit {this.MaxGeschwindigkeit} km/h fahren und kostet {this.Preis}€.";
        }

        //Die ToString()-Methode wird von der object-Klasse an alle anderen Klassen vererbt. Sie wird immer dann aufgerufen, wenn ein Objekt als
        //String dargestellt werden soll
        public override string ToString()
        {
            return this.BeschreibeMich();
        }

        //Eine als ABSTRACT gesetzte Methode (nur in abstrakten Klassen möglich) beseht nur aus einem Methodenkopf und zwingt erbende
        //Klassen diese Methode zu implementieren
        public abstract void Hupen();
        #endregion
    }
}
