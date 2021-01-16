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
        //
        //**********************************************
        private List<Domino> tableJeu;
        bool pas = false;

        string message = "";
        int turnJoueur;
        //**********************************************

        //Emilio
        //**************************************************************

        private Domino point=new Domino(Domino.MAX_VALUE, Domino.MAX_VALUE);
        
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
                    Console.WriteLine($" Joueur {i + 1} commence!!! ");

                    message=$"-> le Joueur {i + 1} a joué:  {domino}";
                    //point = domino;!!!!!!!!!!!!!!ici  ereur
                    turnJoueur = i+1;
                    AffichageJou();
                    break;
                }
            }
          }

        public void ContinuationTurn()
         {
            //Definir premier Joueur et faire une boucle pour quil ne depasse pas de 4 (ver porque 5).
           
             if (turnJoueur == 4)
            {
                turnJoueur = 0;
            }



            if (joueurs[turnJoueur].AvoirDomino(point))
            {
                Domino domino = joueurs[turnJoueur].DominoSorti();
                 message=$"->le Joueur {turnJoueur+1} a joue {domino}";

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



               
                //point = domino;//esto esta mal tengo que fabricarlo con las dos puntas
               // Joueurs[turnJoueur].Jeu.Remove(domino);

                AffichageJou();
                 
                point.Gauche = tableJeu[0].Gauche;
                
                 point.Droite = tableJeu[tableJeu.Count - 1].Droite;


                pas = true;
                }

            //definir pour quil commence a cero dans la prochain ronde
              turnJoueur ++;
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
        public List<Domino> TrierTableau(List<Domino> test)
        {
            int n = test.Count;
            int valeurMax=0;
            List < Domino > trie = new List<Domino>();
            for(int i = 0; i < n; i++)
            {
                valeurMax = test[0].Valeur();
                int index = 0;
               for(int j=1;j<test.Count;j++)
                {
                    
                    if (test[j].Valeur() > valeurMax) 
                    {
                        valeurMax = test[j].Valeur();
                        index=test.IndexOf(test[j]);
                    }
                }
                trie.Add(test[index]);
                test.Remove(test[index]);                             
            }
            return trie;
        }
        /// <summary>
        /// Jouer qui distribue 7 dominos à chaque joueurs
        /// et affiche son jeu. Elle devra etre modifiée pour simuler une ou des parties
        /// </summary>
        public void Jouer()
        {

            //************************************
            int bonus = 10;
            bool finiJeu;
            //************************************
            tableJeu = new List<Domino>();
            //

            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Joueurs[i].Jeu = paquet.Distribue(NOMBRE_DOMINOS);
                Joueurs[i].Jeu = TrierTableau(Joueurs[i].Jeu);
            }
            
            for (int i = 0; i < NOMBRE_JOUEURS; i++)
            {
                Console.WriteLine($"{Joueurs[i]} valeur: {Joueurs[i].Valeur()}");
            }

            //
            //*************************************
            finiJeu = false;

            for (int i = 0; ; i++)
            {
                int count = 0;
                message = "";

                //on trouve  le joueur qui débutera la partie est deplace lui a la position 0 dans la tableau de joueurs
                if (i == 0)
                {
                    PremierTurn();
                 }

                for (int j = turnJoueur; j < NOMBRE_JOUEURS; j++)
                {
                    
                    if (!pas)
                    {
                        ContinuationTurn();
                    }



                    //AffichageJou();

                    ////tous les autre pas
                    if (Joueurs[j].Jeu.Count == 0)
                    {
                        message = $"{Joueurs[j].NomJoueur} est gagnant(e)!!!";
                        Joueurs[j].Score += bonus;
                        finiJeu = true;
                        break;
                    }
                   
                    if (!pas) 
                            {
                         count++;
                        Console.WriteLine($"-> Joueur {Joueurs[j].NomJoueur} a passé son tour, count: {count} ");

                        //Les 4 joueurs ont dû passer leur tour
                        if (count == NOMBRE_JOUEURS)
                        {
                            Console.WriteLine($"Les 4 joueurs ont dû passer leur tour!!!");
                            finiJeu = true;
                        }
                        
                    }
                    pas = false;
                }
                if (turnJoueur == 4)
                {
                    turnJoueur = 0;
                }
                if (finiJeu)
                {
                    AffichageValeurJou();
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
            AffichageTableJou();
        }

        /// <summary>
        /// Afficgage la table de jou
        /// </summary>
        public void AffichageTableJou()
        {
            Console.WriteLine();
            Console.WriteLine("********************tableJeu de jou***********************");
            foreach (Domino domino in tableJeu)
            {
                Console.Write(domino.ToString());
             }
            Console.WriteLine();
            Console.WriteLine("*************************************************************");
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