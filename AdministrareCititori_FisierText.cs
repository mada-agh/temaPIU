using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibrarieModele;

namespace NivelAccesDate2
{
    public class AdministrareCititori_FisierText: IStocareData2
    {
        private const int PAS_ALOCARE = 10;//suprascriem fisierul cand dam update
        string NumeFisier { get; set; }
        public AdministrareCititori_FisierText(string numeFisier)
        {
            this.NumeFisier = numeFisier;
            Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            sFisierText.Close();

            //liniile de mai sus pot fi inlocuite cu linia de cod urmatoare deoarece
            //instructiunea 'using' va apela sFisierText.Close();
            //using (Stream sFisierText = File.Open(numeFisier, FileMode.OpenOrCreate)) { }
        }
        public void AddCititor(Cititor s)
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

        public Cititor[] GetCititori(out int nrCititori)
        {
            Cititor[] cititori = new Cititor[PAS_ALOCARE];

            try
            {
                // instructiunea 'using' va apela sr.Close()
                using (StreamReader sr = new StreamReader(NumeFisier))
                {
                    string line;
                    nrCititori = 0;

                    //citeste cate o linie si creaza un obiect de tip Student pe baza datelor din linia citita
                    while ((line = sr.ReadLine()) != null)
                    {
                        cititori[nrCititori++] = new Cititor(line);
                        if (nrCititori == PAS_ALOCARE)
                        {
                            Array.Resize(ref cititori, nrCititori + PAS_ALOCARE);
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

            return cititori;
        }
        public bool UpdateCititor(Cititor[] cititori, int _cod)
        {
            bool rez = false;
            try
            {
                string[] linii = File.ReadAllLines(NumeFisier);
                using (StreamWriter swFisierText = new StreamWriter(NumeFisier))
                {
                    for (int i = 0; i < linii.Length; i++)
                    {
                        if (cititori[i].Cod == _cod)
                        {
                            swFisierText.WriteLine(cititori[i].ConversieLaSir_PentruFisier());
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
