using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Cititor
    {
        private const int MAI_MARE = 1;
        private const int MAI_MIC = 1;
        private const int EGAL = 0;
        private const int MAX_CARTI_IMPRUMUT = 10;
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int COD = 0;
        private const int NUME = 1;
        private const int PRENUME = 2;
        private const int NR_CARTI = 3;

        Carte[] imprumut;
        public static int NextID { get; set; } = 0;
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public int NrCarti { get; set; }
        public int Cod { get; set; }
        public string NumeComplet { get { return Nume + " " + Prenume + " - " + NrCarti.ToString() + " carti"; } }
        public Cititor(string _nume = "", string _prenume = "")
        {
            Nume = _nume;
            Prenume = _prenume;
            NrCarti = 0;
            Cod = ++NextID;
        }
        public Cititor(string dateCititor)
        {
            //string[] infoCititor = dateCititor.Split(new string[] { ", " }, StringSplitOptions.None);
            string[] infoCititor = dateCititor.Split(SEPARATOR_PRINCIPAL_FISIER);
            Cod = Int32.Parse(infoCititor[COD]);
            NextID = Cod;
            Nume = infoCititor[NUME];
            Prenume = infoCititor[PRENUME];
            NrCarti = Int32.Parse(infoCititor[NR_CARTI]);
        }
        public bool NrMaxCarti()
        {
            if (MAX_CARTI_IMPRUMUT == NrCarti)
                return true;
            return false;
        }
        public string ConversieLaSir()
        {
            return "#"+Cod.ToString()+" "+Nume + " " + Prenume + " - " + NrCarti.ToString() + " carti";
        }
        public int Compara(Cititor c)
        {
            if (this.Nume.CompareTo(c.Nume) == MAI_MARE)
                return MAI_MARE;
            else if (this.Nume.CompareTo(c.Nume) == EGAL)
            {
                if (this.Prenume.CompareTo(c.Prenume) == MAI_MARE)
                    return MAI_MARE;
                else if (this.Prenume.CompareTo(c.Prenume) == EGAL)
                    return EGAL;
                else
                    return MAI_MIC;
            }
            else
                return MAI_MIC;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}",
                SEPARATOR_PRINCIPAL_FISIER, Cod.ToString(), (Nume ?? "NECUNOSCUT"), (Prenume ?? " NECUNOSCUT "), NrCarti.ToString());

            return s;
        }
    }
}
