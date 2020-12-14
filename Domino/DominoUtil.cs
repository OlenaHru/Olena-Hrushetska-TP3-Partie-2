using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    public static class DominoUtil
    {
        public static string AffichageJeu(Domino[] dominos)
        {
            StringBuilder jeu = new StringBuilder();

            foreach(Domino domino in dominos)
            {
                jeu.Append(domino + " " );

            }
            return jeu.ToString();
        }
    }
}
