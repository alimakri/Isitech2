using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    class Animal
    {
        public string Nom;
        public DateTime DateNaissance;
        public override string ToString()
        {
            return Nom;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // var resultat = VersionPrimitive();
            // var resultat = VersionLinq();
            var resultat = VersionLinqAvance();

            // Affichage du résultat
            foreach (var i in resultat)
            {
                Console.WriteLine(i);
            }

            Console.Read();
        }
        private static List<string> VersionLinqAvance()
        {
            var animaux = new List<Animal>
            {
                new Animal{ Nom="Medor", DateNaissance= DateTime.Now},
                new Animal{ Nom="Titi", DateNaissance= DateTime.Now.AddDays(-1)},
                new Animal{ Nom="GrosMinet", DateNaissance= DateTime.Now.AddDays(-2)},
                new Animal{ Nom="Minou", DateNaissance= DateTime.Now.AddDays(-3)},
                new Animal{ Nom="Toto", DateNaissance= DateTime.Now.AddDays(-2)},
            };

            return animaux
                        .Where(x => (int)((DateTime.Now - x.DateNaissance).TotalDays) == 2)
                        .Select(x => x.Nom)
                        .ToList();

        }
        private static List<int> VersionLinq()
        {
            var tableauEntier = new int[] { 12, 58, 39, 2, 7, 4, 154, 11 };

            // Corps
            var resultat = tableauEntier
                                .Where(x => x % 2 == 1)
                                .Where(x => x > 10)
                                .ToList();

            return resultat;
        }

        private static List<int> VersionPrimitive()
        {
            var tableauEntier = new int[] { 12, 58, 39, 2, 7, 4, 154, 11 };

            // Corps
            List<int> resultat = new List<int>();
            foreach (var i in tableauEntier)
            {
                if (i % 2 == 1) resultat.Add(i);
            }

            return resultat;
        }
    }
}
