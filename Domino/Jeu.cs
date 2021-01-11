﻿using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDomino
{
    /// <summary>
    /// Classe qui modélise le jeu
    /// </summary>
    public class Jeu
    {
        //
        //**********************************************
        private List<Domino> tableJeu;


        string message = "";
        int turnJoueur;
        //**********************************************

        //Emilio
        //**************************************************************


        private Domino point;

        public void Affichage()
        {
            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                {
                    Console.WriteLine($"{joueurs[i]} valeur: {joueurs[i].Valeur()}");
                }
            }

        }

        public void PremierTurn()
        {

            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                // aplico metodo si tiene el doble 6, aficho el domino, lo agrego a la lista  mesa, lo pongo en el domino punta y declaro quien comienza el juego
                if (joueurs[i].DoubleSix())
                {
                    Domino domino = joueurs[i].DominoSorti();

                    tableJeu.Add(domino);
                    Console.WriteLine();
                    Console.WriteLine($"le Joueur {i + 1} commence!!! ");
                    Console.WriteLine($"le Joueur {i + 1} a joué:  {domino}");
                    point = domino;//???????
                    turnJoueur = i;
                    Console.WriteLine($"la point de la table cest {point}");///????
                    break;
                }
            }
        }

        public void ContinuationTurn()
        {
            //Definir premier Joueur et faire une boucle pour quil ne depasse pas de 4 (ver porque 5)
            turnJoueur += 1;
            if (turnJoueur == 5)
            {
                turnJoueur = 0;
            }



            if (joueurs[turnJoueur].AvoirDomino(point))
            {
                Domino domino = joueurs[turnJoueur].DominoSorti();
                tableJeu.Add(domino);
                Console.WriteLine(domino);

            }

            //definir pour quil commence a cero dans la prochain ronde
            turnJoueur = NOMBRE_JOUEURS;
        }


        private const int NOMBRE_JOUEURS = 4;

        /// <summary>
        /// Peut on diviser par 4 le nombre total de domino ici?
        /// </summary>
        private const int NOMBRE_DOMINOS = Paquet.NOMBRE_DOMINOS / NOMBRE_JOUEURS;

        /// <summary>
        /// La liste de joueurs
        /// </summary>
        private Joueur[] joueurs;

        /// <summary>
        /// Le paquet de domino
        /// </summary>
        private Paquet paquet;

        public Joueur[] Joueurs { get => joueurs; set => joueurs = value; }

        /// <summary>
        /// Le constructeur du jeu qui crée un paquet et un tableau de 4 joueurs
        /// 
        /// </summary>
        public Jeu()
        {
            paquet = new Paquet();
            Joueurs = new Joueur[NOMBRE_JOUEURS];

            for (int j = 0; j < NOMBRE_JOUEURS; j++)
            {
                Joueurs[j] = new Joueur($"Joueur {j + 1}");
            }

        }

        /// <summary>
        /// Jouer qui distribue 7 dominos à chaque joueurs
        /// et affiche son jeu. Elle devra etre modifiée pour simuler une ou des parties
        /// </summary>
        public void Jouer()
        {
            bool pas = false;
            //************************************
            int bonus = 10;
            bool finiJou;
            //************************************
            tableJeu = new List<Domino>();
            //

            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Joueurs[i].Jeu = paquet.Distribue(NOMBRE_DOMINOS);
            }
            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Console.WriteLine($"{Joueurs[i]} valeur: {Joueurs[i].Valeur()}");
            }

            //
            //*************************************
            finiJou = false;

            for (int i = 0; ; i++)
            {
                int count = 0;
                message = "";

                //on trouve  le joueur qui débutera la partie est deplace lui a la position 0 dans la tableau de joueurs
                PremierTurn();
                Console.WriteLine();

                for (int j = turnJoueur; turnJoueur < NOMBRE_JOUEURS; j++)
                {

                    ContinuationTurn();
                    pas = true;


                    ////tous les autre pas
                    if (pas)
                    {
                        foreach (Domino domino in Joueurs[j].Jeu)
                        {
                            //si le joueur va fair son pas 
                            if (!finiJou && !pas && (domino.IsAdjacent(tableJeu[0]) || domino.IsAdjacent(tableJeu[tableJeu.Count - 1])))
                            {
                                if (domino.Gauche == tableJeu[0].Gauche)
                                {

                                    domino.Permute(domino);
                                    tableJeu.Insert(0, domino);
                                }
                                else if (domino.Droite == tableJeu[0].Gauche)
                                {
                                    tableJeu.Insert(0, domino);
                                }
                                else if (domino.Droite == tableJeu[tableJeu.Count - 1].Droite)
                                {
                                    domino.Permute(domino);
                                    tableJeu.Add(domino);
                                }
                                else
                                {
                                    tableJeu.Add(domino);
                                }

                                //supprime le Domino du tableau de domino de joueur
                                Joueurs[j].Jeu.Remove(domino);
                                message = $"-> {Joueurs[j].NomJoueur} a mit domino: {domino} sur la table ";
                                AffichageJou();
                                pas = true;

                                //Un joueur a posé son dernier domino 
                                if (Joueurs[j].Jeu.Count == 0)
                                {
                                    Console.WriteLine($"{Joueurs[j].NomJoueur} est gagnant(e)!!! ***Bonus 10points!!!***");
                                    Joueurs[j].Score += bonus;
                                    Joueur temp = Joueurs[0];
                                    Joueurs[0] = Joueurs[j];
                                    Joueurs[j] = temp;
                                    finiJou = true;
                                }
                                break;
                            }
                        }
                        if (!pas)
                        {
                            count++;
                            Console.WriteLine($"-> Joueur {Joueurs[j].NomJoueur} a passé son tour, count: {count} ");

                            //Les 4 joueurs ont dû passer leur tour
                            if (count == NOMBRE_JOUEURS)
                            {
                                Console.WriteLine($"Les 4 joueurs ont dû passer leur tour!!!");
                                finiJou = true;
                            }
                        }
                    }
                    if (finiJou)

                    {
                        AffichageValeurJou();
                        break;
                    }
                }
                if (finiJou)
                {
                    break;
                }
            }

        }


        /// <summary>
        /// Affichage Jou
        /// </summary>
        public void AffichageJou()
        {
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("*******************JOU DOMINO******************");
            Console.WriteLine();
            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Console.WriteLine($"{Joueurs[i]}");
            }
            Console.WriteLine();

            Console.WriteLine(message);
            AffichageTableDeJou();
        }

        /// <summary>
        /// Afficgage la table de jou
        /// </summary>
        public void AffichageTableDeJou()
        {
            Console.WriteLine();
            Console.WriteLine("********************tableJeu de jou***********************");
            foreach (Domino domino in tableJeu)
            {
                Console.Write(domino.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("************************************************************");
            Console.WriteLine();
        }

        /// <summary>
        /// affichage les valeur de jou et les scores
        /// </summary>
        public void AffichageValeurJou()
        {
            Console.WriteLine();

            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Joueurs[i].Score += (100 - Joueurs[i].Valeur()) / 10;
            }
            for (int j = 0; j < NOMBRE_JOUEURS; j++)
            {

                for (int k = j; k < NOMBRE_JOUEURS; k++)
                {
                    int score = Joueurs[j].Score;

                    if (Joueurs[k].Score > score)
                    {
                        //score = Joueurs[k].Score;
                        Joueur temp = Joueurs[j];
                        Joueurs[j] = Joueurs[k];
                        Joueurs[k] = temp;
                    }
                }
            }
            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Console.WriteLine($"{Joueurs[i]} valeur: {Joueurs[i].Valeur()} score: {Joueurs[i].Score}");

            }
        }
    }
}