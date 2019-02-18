using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //Ein INTERFACE zwingt die implementieren Klassen bestimmte Methoden und Eigenschaften zu implementieren, so dass diesbezüglich 
    ///eine Typsicherheit besteht. Diese Interface fordert die Implementierung zweier Methoden und einer Eigenschaft und ermöglicht einer
    ///einer Klasse Fahrzeuge 'aufzuladen'.
    public interface IBeladbar
    {
        //In einem Interface sind keine Zugriffsmodifier erlaubt
        Fahrzeug Ladung { get; set; }

        //Es werden (wie bei abstarkten Methoden) nur die Methodenköpfe geschrieben. Der Rest wird in den implementierenden Klassen hinzugefügt
        void Belade(Fahrzeug fz);

        void Entlade();
    }
}
