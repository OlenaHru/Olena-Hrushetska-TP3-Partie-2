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
        private const int NOMBRE_JOUEURS = 4;

        /// <summary>
        /// Peut on diviser par 4 le nombre total de domino ici?
        /// </summary>
        private const int NOMBRE_DOMINOS = Paquet.NOMBRE_DOMINOS/ NOMBRE_JOUEURS;

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
            joueurs = new Joueur[NOMBRE_JOUEURS];

            for(int j = 0; j<NOMBRE_JOUEURS;j++)
            {
                joueurs[j] = new Joueur("Joueur " + j+1);
            }

        }

        /// <summary>
        /// Jouer qui distribue 7 dominos à chaque joueurs
        /// et affiche son jeu. Elle devra etre modifiée pour simuler une ou des parties
        /// </summary>
        public void Jouer()
        {

            for(int i = 0; i < NOMBRE_JOUEURS; i++ )
            {
                joueurs[i].Jeu = paquet.Distribue(NOMBRE_DOMINOS);
            }
            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Console.WriteLine($"{joueurs[i]} valeur: {joueurs[i].Valeur()}");
            }
        }
    }
}
