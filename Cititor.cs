using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Cititor
    {
        private const int MAX_CARTI_IMPRUMUT = 10;
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int NrCarti { get; set; }
        public string NumeComplet { get { return Nume + " " + Prenume + " - " + NrCarti.ToString() + " carti"; } }
        public Cititor(string _nume = "", string _prenume = "")
        {
            Nume = _nume;
            Prenume = _prenume;
            NrCarti = 0;
        }
        public Cititor(string dateCititor)
        {
            string[] infoCititor = dateCititor.Split(new string[] { ", " }, StringSplitOptions.None);
            Nume = infoCititor[0];
            Prenume = infoCititor[1];
            NrCarti = 0;
        }
        public bool NrMaxCarti()
        {
            if (MAX_CARTI_IMPRUMUT == NrCarti)
                return true;
            return false;
        }
    }
}
