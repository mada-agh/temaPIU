using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate1
{
    public interface IStocareData1
    {
        void AddCarte(Carte s);
        Carte[] GetCarti(out int nrCarti);
        bool UpdateCarte(Carte[] carti, int _cod);
    }
}
