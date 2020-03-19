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
            var c1 = new Carte("Harry Potter si prizonierul din Azkaban", "J.K. Rowling", "ARTUR");
            var p1 = new Cititor("Madalina", "Agheorghiesei");
            Console.WriteLine(c1.NumeComplet());
            Console.WriteLine(p1.NumeComplet());
            Console.ReadKey();
        }
    }
}
