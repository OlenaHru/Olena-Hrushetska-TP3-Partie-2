using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    /// <summary>
    /// Classe statique contenant quelques utilitaires
    /// concernant le jeu
    /// </summary>
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
