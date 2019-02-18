using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //vgl. IBeladbar
    public interface IBewegbar
    {
        int RäderAnzahl { get; set; }

        void Bewegen();

    }
}
