using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibrarieModele;

namespace NivelAccesDate2
{
    public interface IStocareData2
    {
        void AddCititor(Cititor s);
        Cititor[] GetCititori(out int nrCititori);
        bool UpdateCititor(Cititor[] cititori, int _cod);
    }
}
