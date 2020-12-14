using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    public class Paquet
    {
        private const int ITERATION_MELANGE = 30;

        private const int NOMBRE_DOMINOS = (Domino.MAX_VALUE+1)* (Domino.MAX_VALUE + 2)/2;
        // ou alors
        // private const int NOMBRE_DOMINOS = 28;

        private Domino[] dominos;

        public Domino[] Dominos { get { return dominos; } set { dominos = value; } }

        private int indiceDominoLibre;

        public Paquet()
        {
            indiceDominoLibre = 0;

            Dominos = new Domino[NOMBRE_DOMINOS];
            int k = 0;
            for (int i = 0; i <= Domino.MAX_VALUE; i++)
            {
                for (int j = i; j <= Domino.MAX_VALUE; j++)
                {
                    Domino domino = new Domino(i, j);
                    Dominos[k] = domino;
                    k++;
                }
            }
            Melanger();
        }

        public override string ToString()
        {
            return DominoUtil.AffichageJeu(Dominos);
        }

        public Domino Distribue()
        {
            Domino prochain = null;
            if(indiceDominoLibre <= Dominos.Length)
            {
                prochain = Dominos[indiceDominoLibre];
                indiceDominoLibre++;
            }
            return prochain;
        }


        public List<Domino> Distribue(int nombre)
        {
            List<Domino> prochains = new List<Domino>();
            for (int i = 0; i < nombre; i++)
            {
                prochains.Add(Distribue());
            }
            return prochains;
        }

        private void Permuter(int i, int j)
        {
            if (0 <= i && i <= Dominos.Length && 0 <= j && j <= Dominos.Length)
            {
                Domino temp = Dominos[i];
                Dominos[i] = Dominos[j];
                Dominos[j] = temp;
            }
            //Todo manage erreurs
        }

        private void Melanger()
        {
            Random rand = new Random();
            for (int i = 0; i <= ITERATION_MELANGE; i++) 
            {
                int x= rand.Next(0, Dominos.Length);
                int y= rand.Next(0, Dominos.Length);
                Permuter(x, y);

            }


        }
    }
}
