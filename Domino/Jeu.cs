using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    /// <summary>
    /// Classe qui modélise le jeu
    /// </summary>
    public class Jeu
    {
        /// <summary>
        /// Peut on diviser par 4 le nombre total de domino ici?
        /// </summary>
        private const int NOMBRE_DOMINOS = 7;

        /// <summary>
        /// La liste de joueurs
        /// </summary>
        private Joueur[] joueurs;

        /// <summary>
        /// Le paquet de domino
        /// </summary>
        private Paquet paquet;

        /// <summary>
        /// Le constructeur du jeu qui crée un paquet et un tableau de 4 joueurs
        /// 
        /// </summary>
        public Jeu()
        {
            paquet = new Paquet();
            joueurs = new Joueur[4];


            joueurs[0] = new Joueur("J1");
            joueurs[1] = new Joueur("J2");
            joueurs[2] = new Joueur("J3");
            joueurs[3] = new Joueur("J4");

        }

        /// <summary>
        /// Jouer qui distribue 7 dominos à chaque joueurs
        /// et affiche son jeu. Elle devra etre modifiée pour simuler une ou des parties
        /// </summary>
        public void Jouer()
        {

            for(int i = 0; i < 4 ; i++ )
            {
                joueurs[i].Jeu = paquet.Distribue(NOMBRE_DOMINOS);
            }
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{joueurs[i]} valeur: {joueurs[i].Valeur()}");
            }
        }
    }
}
