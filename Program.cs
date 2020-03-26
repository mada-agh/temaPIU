using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Biblioteca
{
    class Program
    {
        static void Main(string[] args)
        {
            Carte c1 = new Carte("Harry Potter si prizonierul din Azkaban", "J.K. Rowling", "ARTUR");
            Cititor p1 = new Cititor("Madalina", "Agheorghiesei");
            Console.WriteLine("introduceti datele unei carti (titlu, autor, editura)");
            Carte c2 = new Carte(Console.ReadLine());
            Console.WriteLine("introduceti datele unui cititor (nume, prenume)");
            Cititor p2 = new Cititor(Console.ReadLine());
            Console.WriteLine(c1.NumeComplet);
            Console.WriteLine(p1.NumeComplet);
            Console.WriteLine(c2.NumeComplet);
            Console.WriteLine(p2.NumeComplet);
            Carte c3 = CitireCarteTastatura();
            Cititor p3 = CitireCititorTastatura();
            Console.WriteLine(c3.NumeComplet);
            Console.WriteLine(p3.NumeComplet);
            Console.ReadKey();
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
    }
}
