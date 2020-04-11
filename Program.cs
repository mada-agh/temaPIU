using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelAccesDate1;
using LibrarieModele;
using NivelAccesDate2;

namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Carte[] carti;

            //variabila de tip interfata 'IStocareData' care este initializata 
            //cu o instanta a clasei 'AdministrareStudenti_FisierText' sau o instanta a clasei 'AdministrareStudenti_FisierBinar' in functie de setarea 'FormatSalvare' din fisierul AppConfig
            IStocareData1 adminCarti = StocareFactory.GetAdministratorStocare1();
            int nrCarti;
            carti = adminCarti.GetCarti(out nrCarti);
            Carte.NextID = nrCarti;

            string optiune;
            do
            {
                optiune = Meniu();
                switch (optiune.ToUpper())
                {
                    case "L":
                        AfisareCarti(carti, nrCarti);
                        break;
                    case "A":
                        Carte s = CitireCarteTastatura();
                        carti[nrCarti] = s;
                        nrCarti++;
                        //adaugare carte in fisier
                        adminCarti.AddCarte(s);
                        break;
                    case "M":
                        Console.WriteLine("Titlu: ");
                        string titluMod = Console.ReadLine();
                        Console.WriteLine("Autor: ");
                        string autorMod = Console.ReadLine();
                        Console.WriteLine("Editura: ");
                        string edituraMod = Console.ReadLine();
                        s = CautareCarte(titluMod, autorMod,edituraMod, nrCarti, carti);
                        if (s != null)
                        {
                            int n;
                            Console.WriteLine("Cate exemplare detine biblioteca? ");
                            bool rez = Int32.TryParse(Console.ReadLine(), out n);
                            if (rez == true)
                            {
                                s.NumarExemplare = n;
                                if (adminCarti.UpdateCarte(carti, s.Cod) == true)
                                    Console.WriteLine("S-a actualizat fisierul cu succes");
                                else
                                    Console.WriteLine("Nu s-a putut actualiza fisierul");
                            }
                            else
                                Console.WriteLine("- Nu ati introdus un numar valid -");
                        }
                        else
                            Console.WriteLine("- Nu s-a gasit aceasta carte -");
                        break;
                }
            } while (optiune.ToUpper() != "X");
            return;
        }
        public static string Meniu()
        {
            Console.WriteLine("L. Listare carti");
            Console.WriteLine("A. Adaugare carte");
            Console.WriteLine("M. Modificare carte");
            Console.WriteLine("X. Inchidere program");
            Console.WriteLine("Alegeti o optiune");
            return Console.ReadLine();
        }
        public static Carte CitireCarteTastatura()
        {
            Console.WriteLine("Introduceti titlul:");
            string titlu = Console.ReadLine();
            Console.WriteLine("Introduceti autorul:");
            string autor = Console.ReadLine();
            Console.WriteLine("Introduceti editura:");
            string editura = Console.ReadLine();
            Carte c = new Carte(titlu, autor, editura);
            //adauga si limba si genul
            return c;
        }
        public static Cititor CitireCititorTastatura()
        {
            Console.WriteLine("Introduceti numele:");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti prenumele:");
            string prenume = Console.ReadLine();
            Cititor c = new Cititor(nume, prenume);
            return c;
        }
        public static Cititor CautareCititor(string nume, string prenume, int nrCititori, Cititor[] cititori)
        {
            for (int i = 0; i < nrCititori; i++)
            {
                if (String.Equals(nume, cititori[i]) && String.Equals(prenume, cititori[i]))
                {
                    return cititori[i];
                }
            }
            return null;
        }
        public static void AfisareCarti(Carte[] carti, int nrCarti)
        {
            Console.WriteLine("Colectia de carti:");
            for (int i = 0; i < nrCarti; i++)
            {
                Console.WriteLine(carti[i].ConversieLaSir());
                Console.WriteLine();
            }
        }
        public static Carte CautareCarte(string titluMod, string autorMod, string edituraMod, int nrCarti, Carte[] carti)
        {
            for(int i=0; i<nrCarti; i++)
            {
                if (titluMod.CompareTo(carti[i].Titlu) == 0 && autorMod.CompareTo(carti[i].Autor) == 0 && edituraMod.CompareTo(carti[i].Editura) == 0)
                    return carti[i];
            }
            return null;
        }
    }
}
