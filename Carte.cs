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
     
    }
}
