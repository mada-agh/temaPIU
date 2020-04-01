using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Carte
    {
        public static int NextID { get; set; } = 0;
        public int Cod { get; set; }
        public string Titlu { get; set; }
        public string Autor { get; set; }
        public string Editura { get; set; }
        public string NumeComplet { get { return Titlu + " - " + Autor + " - " + Editura; } }

        public Carte(string _titlu = "", string _autor = "", string _editura = "")
        {
            Titlu = _titlu;
            Autor = _autor;
            Editura = _editura;
            Cod = ++NextID;
        }
        public Carte(string date)
        {
            string[] infoCarte = date.Split(new string[] { ", " }, StringSplitOptions.None);
            Titlu = infoCarte[0];
            Autor = infoCarte[1];
            Editura = infoCarte[2];
            Cod = ++NextID;
        }
        public string ConversieLaSir()
        {
            return Titlu + " - " + Autor + " - " + Editura+" - "+Cod.ToString();
        }
        public int Compara(Carte c)
        {
            if (this.Cod > c.Cod)
                return Program.MAI_MARE;
            else if (this.Cod == c.Cod)
            {
                if (this.Titlu.CompareTo(c.Titlu) == Program.MAI_MARE)
                    return Program.MAI_MARE;
                else if (this.Titlu.CompareTo(c.Titlu) == Program.EGAL)
                    return Program.EGAL;
                else
                    return Program.MAI_MIC;
            }
            else
                return Program.MAI_MIC;
        }
    }
}
