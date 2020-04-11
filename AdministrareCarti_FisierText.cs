using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieModele;

namespace NivelAccesDate1
{
    public class AdministrareCarti_FisierText : IStocareData1 //trebuie sa fac clasa ca aceasta si pentru cicitori? cum fac cu app.config?
    {
        private const int PAS_ALOCARE = 10;//suprascriem fisierul cand dam update
        string NumeFisier { get; set; }
        public AdministrareCarti_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();

            //liniile de mai sus pot fi inlocuite cu linia de cod urmatoare deoarece
            //instructiunea 'using' va apela sFisierText.Close();
            //using (Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate)) { }
        }
        public void AddCarte(Carte s)
        {
            try
            {
                //instructiunea 'using' va apela la final swFisierText.Close();
                //al doilea parametru setat la 'true' al constructorului StreamWriter indica modul 'append' de deschidere al fisierului
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier, true))
                {
                    swFisierText.WriteLine(s.ConversieLaSir_PentruFisier());
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
        }

        public Carte[] GetCarti(out int nrCarti)
        {
            Carte[] carti = new Carte[PAS_ALOCARE];

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrCarti = 0;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        carti[nrCarti++] = new Carte(line);
                        if (nrCarti == PAS_ALOCARE)
                        {
                            Array.Resize(ref carti, nrCarti + PAS_ALOCARE);
                        }
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }

            return carti;
        }
        public bool UpdateCarte(Carte[] carti, int _cod)
        {
            bool rez = false;
            try
            {
                string[] linii = File.ReadAllLines(NumeFisier);
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier))
                {
                    for (int i = 0; i < linii.Length; i++)
                    {
                        if (carti[i].Cod == _cod)
                        {
                            swFisierText.WriteLine(carti[i].ConversieLaSir_PentruFisier());
                            rez = true;
                        }
                        else
                            swFisierText.WriteLine(linii[i]);
                    }
                }
            }
            catch (IOException eIO)
            {
                throw new Exception("Eroare la deschiderea fisierului. Mesaj: " + eIO.Message);
            }
            catch (Exception eGen)
            {
                throw new Exception("Eroare generica. Mesaj: " + eGen.Message);
            }
            return rez;
        }
    }
}
