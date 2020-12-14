using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    /// <summary>
    /// La classe qui représente un Joueur
    /// </summary>
    public class Joueur
    {
        /// <summary>
        /// Le nom du joueur (ne peut pas etre modifié apres construction)
        /// </summary>
        private readonly string nomJoueur;

        /// <summary>
        /// La liste des domino du joueur
        /// </summary>
        private List<Domino> jeu;

        /// <summary>
        /// La liste des domino du joueur
        /// </summary>
        public List<Domino> Jeu
        {
            get
            {
                return jeu;
            }
            set
            {
                jeu = value;
            }
        }

        /// <summary>
        /// le nom du joueur
        /// </summary>
        public string NomJoueur
        {
            get
            {
                return nomJoueur;
            }
        }

        /// <summary>
        /// Le constructeur avec simplement le nom du joueur
        /// </summary>
        /// <param name="nomJoueur">s</param>
        public Joueur(string nomJoueur)
        {
            this.nomJoueur = nomJoueur;
        }

        /// <summary>
        /// Affiche le nom du joueur
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return nomJoueur + " : " + DominoUtil.AffichageJeu(Jeu.ToArray());
        }

        /// <summary>
        /// La valeur totale du jeu du joueur
        /// </summary>
        /// <returns>La valeur totale</returns>
        public int Valeur()
        {
            int score = 0;
            foreach (Domino domino in Jeu)
            {
                score += domino.Valeur();
            }
            return score;

        }

    }
}
