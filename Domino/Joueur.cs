using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    public class Joueur
    {
        private readonly string nomJoueur;
        private List<Domino> jeu;

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

        public string NomJoueur
        {
            get
            {
                return nomJoueur;
            }
        }

        public Joueur(string nomJoueur)
        {
            this.nomJoueur = nomJoueur;
        }

        public override string ToString()
        {
            return nomJoueur + " : " + DominoUtil.AffichageJeu(Jeu.ToArray());
        }

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
