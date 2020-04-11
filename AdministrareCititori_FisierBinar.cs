using LibrarieModele;
using System;
using System.Collections.Generic;

namespace NivelAccesDate2
{
    //clasa AdministrareStudenti_FisierBinar implementeaza interfata IStocareData
    public class AdministrareCititori_FisierBinar : IStocareData2
    {
        string NumeFisier { get; set; }
        public AdministrareCititori_FisierBinar(string numeFisiser)
        {
            this.NumeFisier = NumeFisier;
        }

        public void AddCititor(Cititor s)
        {
            throw new Exception("Optiunea AddCititor nu este implementata");
        }

        public Cititor[] GetCititori(out int nrCititori)
        {
            throw new Exception("Optiunea GetCititori nu este implementata");
        }

        public Cititor GetCititor(string nume, string prenume)
        {
            throw new Exception("Optiunea GetCititor nu este implementata");
        }
        public bool UpdateCititor(Cititor[] c, int cod)
        {
            throw new Exception("Optiunea UpdateCititor nu est implementata");
        }
    }
}
