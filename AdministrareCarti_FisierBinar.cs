using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelAccesDate1
{
    //clasa AdministrareStudenti_FisierBinar implementeaza interfata IStocareData
    public class AdministrareCarti_FisierBinar : IStocareData1
    {
        string NumeFisier { get; set; }
        public AdministrareCarti_FisierBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddCarte(Carte s)
        {
            throw new Exception("Optiunea AddCarte nu este implementata");
        }

        public Carte[] GetCarti(out int nrCarti)
        {
            throw new Exception("Optiunea GetCarti nu este implementata");
        }

        public Carte GetCarte(string titlu, string autor)
        {
            throw new Exception("Optiunea GetCarte nu este implementata");
        }
        public bool UpdateCarte(Carte[] c,int cod)
        {
            throw new Exception("Optiunea UpdateCarte nu est implementata");
        }
    }
}
