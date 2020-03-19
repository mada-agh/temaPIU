using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Cititor
    {
        string nume;
        string prenume;
        int nrCarti;
        public Cititor(string _nume="", string _prenume="")
        {
            nume = _nume;
            prenume = _prenume;
            nrCarti = 0;
        }
        public void setNume(string _nume)
        {
            nume = _nume;
        }
        public void setPrenume(string _prenume)
        {
            prenume = _prenume;
        }
        public string getNume()
        {
            return nume;
        }
        public string getPrenume()
        {
            return prenume;
        }
        public int getNrCarti()
        {
            return nrCarti;
        }
        public string NumeComplet()
        {
            return nume + " " + prenume + " - " + nrCarti.ToString() + " carti";
        }
        public bool NrMaxCarti()
        {
            if (Program.TotCartiImprumut == getNrCarti())
                return true;
            return false;
        }
    }
}
