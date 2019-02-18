using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructVsClass
{
    //vgl. auch Modul 4 -> Fahrzeug
    public class KlassenPerson
    {
        public string name;
        public int alter;

        public KlassenPerson(string name, int alter)
        {
            this.alter = alter;
            this.name = name;
        }
    }

    //STRUCTS sind Klassenähnliche Konstrukte, welche nicht, wie Klassen, als Referenztypen behandelt werden, sondern ein Wertetyp sind. D.h
    //bei Übergabe eines Structs an eine Methode oder Variable wird eine Kopie dieses Objekts erstellt
    public struct StructPerson
    {
        public string name;
        public int alter;

        public StructPerson(string name, int alter)
        {
            this.alter = alter;
            this.name = name;
        }
    }
    class Program
    {
        public static void Altern(KlassenPerson person)
        {
            person.alter++;
        }

        public static void Altern(StructPerson person)
        {
            person.alter++;
        }

        //Mittels des REF-Stichworts können Wertetypen als Referenz an Methoden übergeben werden. D.h. die übergebene Speicherstelle selbst 
        ///wird manipuliert und nicht, wie normalerweise bei Wertetypen, eine Kopie des Werts.
        public static void Altern(ref StructPerson person)
        {
            person.alter++;
        }

        static void Main(string[] args)
        {
            //Erstellung von Objekten
            KlassenPerson kPerson = new KlassenPerson("Otto", 30);
            StructPerson sPerson = new StructPerson("Anna", 30);

            //Ausgabe
            Console.WriteLine("Otto: " + kPerson.alter);
            Console.WriteLine("Anna: " + sPerson.alter);

            //Funktionsaufruf
            Altern(kPerson);
            Altern(sPerson);

            //Erneute Ausgabe: Nur das Klassenobjekt (Referenztyp) hat sich verändert
            Console.WriteLine("Otto: " + kPerson.alter);
            Console.WriteLine("Anna: " + sPerson.alter);

            //Übergabe des Wertetyps als Refernz mittels Ref-Stichwort
            Altern(ref sPerson);
            Console.WriteLine("Anna: " + sPerson.alter);

            //Programmpause
            Console.ReadKey();
        }
    }
}
