using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    class Carte
    {
        string titlu;
        string autor;
        string editura;
        int cod;
        static int nextID;
        public Carte(string _titlu="", string _autor="", string _editura = "")
        {
            titlu = _titlu;
            autor = _autor;
            editura = _editura;
            cod = ++nextID;
        }
        public void setTitlu(string _titlu)
        {
            titlu = _titlu;
        }
        public void setAutor(string _autor)
        {
            autor = _autor;
        }
        public void setEditura(string _editura)
        {
            editura = _editura;
        }
        public string getTitlu()
        {
            return titlu;
        }
        public string getAutor()
        {
            return autor;
        }
        public string getEditura()
        {
            return editura;
        }
        public int getCod()
        {
            return cod;
        }
        public string NumeComplet()
        {
            return getTitlu() + " - " + getAutor() + " - " + getEditura();
        }
    }
}
