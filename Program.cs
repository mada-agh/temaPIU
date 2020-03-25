using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    class Program
    {
        public const int TotCartiImprumut = 10;
        static void Main(string[] args)
        {
            Carte c1 = new Carte("Harry Potter si prizonierul din Azkaban", "J.K. Rowling", "ARTUR");
            Cititor p1 = new Cititor("Madalina", "Agheorghiesei");
            Console.WriteLine("introduceti datele unei carti (titlu, autor, editura)");
            Carte c2 = new Carte(Console.ReadLine());
            Console.WriteLine("introduceti datele unui cititor (nume, prenume)");
            Cititor p2 = new Cititor(Console.ReadLine());
            Console.WriteLine(c1.NumeComplet());
            Console.WriteLine(p1.NumeComplet());
            Console.WriteLine(c2.NumeComplet());
            Console.WriteLine(p2.NumeComplet());
            Console.ReadKey();
        }
    }
}
