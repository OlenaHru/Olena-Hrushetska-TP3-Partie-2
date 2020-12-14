using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    public class Jeu
    {
        private Joueur[] joueurs;

        private Paquet paquet;

        public Jeu()
        {
            paquet = new Paquet();
            joueurs = new Joueur[4];


            joueurs[0] = new Joueur("J1");
            joueurs[1] = new Joueur("J2");
            joueurs[2] = new Joueur("J3");
            joueurs[3] = new Joueur("J4");



        }


        public void Jouer()
        {

            for(int i = 0; i < 4 ; i++ )
            {
                joueurs[i].Jeu = paquet.Distribue(7);
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{joueurs[i]} valeur: {joueurs[i].Valeur()}");
            }
        }
    }
}
