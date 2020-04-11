using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Carte
    {
        private const int MAI_MARE = 1;
        private const int MAI_MIC = 1;
        private const int EGAL = 0;
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const int TITLU = 0;
        private const int AUTOR = 1;
        private const int EDITURA = 2;
        private const int COD = 3;
        private const int N_EXEMPLARE = 4;
        private const int LIMBA = 5;
        private const int GEN = 6;

        public static int NextID { get; set; } = 0;
        public int Cod { get; set; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public string Editura { get; set; }
        public int NumarExemplare { get; set; }
        public string NumeComplet { get { return Titlu + " - " + Autor + " - " + Editura; } }
        public LimbaCarte Limba { get; set; }
        public GenCarte Gen { get; set; }

        public Carte(string _titlu = "", string _autor = "", string _editura = "", int nrex = 1)
        {
            Titlu = _titlu;
            Autor = _autor;
            Editura = _editura;
            Cod = ++NextID;
            NumarExemplare = nrex;
        }
        public Carte(string date)
        {
            //string[] infoCarte = date.Split(new string[] { ", " }, StringSplitOptions.None);
            string[] infoCarte = date.Split(SEPARATOR_PRINCIPAL_FISIER);
            Titlu = infoCarte[TITLU];
            Autor = infoCarte[AUTOR];
            Editura = infoCarte[EDITURA];
            Cod = Convert.ToInt32(infoCarte[COD]);
            NextID = Cod;
            NumarExemplare = Convert.ToInt32(infoCarte[N_EXEMPLARE]);
            Limba = (LimbaCarte)Enum.Parse(typeof(LimbaCarte), infoCarte[LIMBA]);
            Gen = (GenCarte)Enum.Parse(typeof(GenCarte), infoCarte[GEN]);
        }
        public string ConversieLaSir()
        {
            return "#"+Cod.ToString()+" - "+Titlu + " - " + Autor + " - " + Editura + " - " +"\nLimba: "+Limba+"\nGen: "+Gen+"\nNumar exemplare: "+NumarExemplare.ToString();
        }
        public int Compara(Carte c)
        {
            if (this.Cod > c.Cod)
                return MAI_MARE;
            else if (this.Cod == c.Cod)
            {
                if (this.Titlu.CompareTo(c.Titlu) == MAI_MARE)
                    return MAI_MARE;
                else if (this.Titlu.CompareTo(c.Titlu) == EGAL)
                    return EGAL;
                else
                    return MAI_MIC;
            }
            else
                return MAI_MIC;
        }
        public string ConversieLaSir_PentruFisier()
        {
            string s = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
                SEPARATOR_PRINCIPAL_FISIER, (Titlu ?? "NECUNOSCUT"), (Autor ?? " NECUNOSCUT "), (Editura ?? " NECUNOSCUT "), Cod.ToString(), NumarExemplare.ToString(), Limba, Gen);

            return s;
        }
    }
}
