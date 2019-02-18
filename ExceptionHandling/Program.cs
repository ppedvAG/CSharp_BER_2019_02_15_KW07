using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    //Eine EXCEPTION wird von dem Programm geworfen, wenn dieses auf einen unerwarteten Zustand trifft. Jede Exception muss durch einen
    ///CATCH-Block abgefangen und bearbeitet werden. Ansonsten stürzt das Programm ab.

    //Eigene Exceptions müssen von der Klasse EXCEPTION erben, damit sie die Eigenschaften einer Exception übernehmen. 
    public class MeineException : Exception
    {
        public MeineException() : base("Dies ist mein Fehler") { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //In einen TRY-Block werden die Code-Teile geschrieben, welche möglicherweise eine Exception werfen könnten. Wenn eine Exception
            ///geworfen wird, bricht dass Programm die Ausführung des TRY-Blocks ab und springt in den CATCH-Block.
            try
            {
                int zahl = int.Parse(Console.ReadLine());

                Console.WriteLine("Try-Block vollständig ");

                //Mit dem THROW-Befehl können manuell Exceptions geworfen werden
                throw new MeineException();
            }
            //Jeder TRY-Block benötigt mindestens einen CATCH-Block um die geworfenen Exceptions abfangen zu können. Jeden CATCH-Block kann eine
            ///Exception-Art zugewiesen werden, welche in diesem Block bearbeitet werden soll. 
            catch (FormatException ex)
            {
                Console.WriteLine("Gib eine Zahl ein. " + ex.Message);

                throw;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Deine Zahl ist zu groß/zu klein. " + ex.Message);
            }
            //Werden mehrere CATCH-Blöcke angegeben, müssen diese in der Reihenfolge von speziell nach allgemein angeordnet sein.
            catch (Exception ex)
            {
                Console.WriteLine("Ein unbekannter Fehler ist aufgetreten. " + ex.Message);
            }
            //Der FINALLY-Block wird ungeachtet der Prozesse, welche in den anderen Blöcke durchgeführt werden, immer ausgeführt
            finally
            {
                Console.WriteLine("Dies wird immer angezeigt");
            }

            //Nach der Ausführung des TRY-, bzw eines CATCH-Blocks macht das Programm im 'normalen' Code weiter
            Console.WriteLine("Ende der Methode");

            Console.ReadKey();
        }
    }
}
