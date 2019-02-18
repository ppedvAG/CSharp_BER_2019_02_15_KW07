using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fahrzeugpark;

namespace UnitTest_Fahrzeugpark
{
    //UNIT-TESTS sind kleinteilige Software-Tests, welche jeweils zum Testen einer einzige Funktion gedacht sind. Ausgeführt werden sie
    ///über den Test-Explorer
    [TestClass]
    public class UT_PKW
    {
        [TestMethod]
        public void Teste_Beschleunigung()
        {
            //Initialisierungphase
            PKW pkw = new PKW("BMW", 190, 26000);

            //Vorbereitungsphase
            pkw.StarteMotor();
            pkw.Beschleunige(200);

            //Testphase

            //Die ASSERT-Klasse enthält diverse Vergleichsmethoden, welche in Unit-Tests verwendet werden können. Pro Test-Methode
            ///muss es mindesten einen Assert-Aufruf geben
            Assert.AreEqual(pkw.MaxGeschwindigkeit, pkw.AktGeschwindigkeit);
        }
    }
}
