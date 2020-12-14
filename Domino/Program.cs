using System;

namespace JeuDomino
{
    class Program
    {
        static void Main(string[] args)
        {
			TesterDominos();

			TesterPaquet();

			TesterJouer();
			
            Console.ReadKey();

        }

		private static void TesterJouer() {

			Console.WriteLine();
			Console.WriteLine(); 
			Console.WriteLine("JOUER");
			new Jeu().Jouer();
		}

		private static void TesterPaquet() {
			Paquet paquet = new Paquet();

			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("PAQUET");

			Console.WriteLine(paquet);

		}


		private static void TesterDominos()
        {
			// Déclaration et instantiation des objets de type Domino
			Domino d1 = new Domino(1,2);
			Domino d2 = new Domino(1, 0);
			Domino d3 = new Domino(2, 6);
			Domino d4 = new Domino(5, 5);
			Domino d5 = new Domino(-5, 50);
			Domino d50 = new Domino(0, 0);
			Console.WriteLine(d50.Equals(d5));

			// Afficher chaque domino
			Console.WriteLine(d2);
			Console.WriteLine(d3);
			Console.WriteLine(d4);
			Console.WriteLine(d5);



			// Afficher si chaque domino est un doublons
			Console.WriteLine("\nDOUBLONS:");
			Console.WriteLine(d2 + "  : " + d2.IsDouble());
			Console.WriteLine(d2 + "  : " + d2.IsDouble());
			Console.WriteLine(d3 + "  : " + d3.IsDouble());
			Console.WriteLine(d4 + "  : " + d4.IsDouble());

			// #2 - Afficher si chaque domino est adjacent à un autre
			Console.WriteLine("\nADJACENTS: ");
			Console.WriteLine(d2 + " ET " + d3 + "  : " + (d2.IsAdjacent(d3)));
			Console.WriteLine(d2 + " ET " + d4 + "  : " + (d2.IsAdjacent(d4)));
			Console.WriteLine(d2 + " ET " + d3 + "  : " + (d2.IsAdjacent(d3)));
			Console.WriteLine(d2 + " ET " + d4 + "  : " + (d2.IsAdjacent(d4)));
			Console.WriteLine(d3 + " ET " + d4 + "  : " + (d3.IsAdjacent(d4)));
		}


    }
}
