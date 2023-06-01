using System;
using System.Collections.Generic;
using System.Text;

namespace CeUAA11_2023_AjdiniSefedin
{
    public struct outils
    {
        /// <summary>
        /// permet de lire un nombre 
        /// </summary>
        /// <param name="question">c'est ce qui va etre demande a l'utilisateur</param>
        /// <param name="n">valeur resultat</param>
        public void LireReel(string question, out int n)
        {
            string nUser;
            Console.Write(question);
            nUser = Console.ReadLine();
            while (!int.TryParse(nUser, out n))
            {
                Console.WriteLine("Attention ! vous devez taper un nombre réel !");
                nUser = Console.ReadLine();
            }
        }
        /// <summary>
        /// A faire le cryptage de Vegenère ! 
        /// </summary>
        /// <param name="caract">phrase du user</param>
        /// <param name="motClef">motClef du user</param>
        public void cryptageVegenere(string caract, string motClef)
        {

            int longueurPhrase = caract.Length;

            int tailleGrille = 1;
            while (tailleGrille * tailleGrille < longueurPhrase)
            {
                tailleGrille++;
            }
            Console.Clear();


            int[,] grille = new int[tailleGrille, tailleGrille]; // Crée une grille de la taille calculée

            // Convertir la phrase en un tableau de caractères  
            char[] caracteres = caract.ToCharArray();

            // Placer chaque caractère du mot-clé dans la grille
            int indexClef = 0;
            for (int i = 0; i < tailleGrille; i++)
            {
                for (int j = 0; j < tailleGrille; j++)
                {
                    if (indexClef < motClef.Length)
                    {
                        grille[i, j] = motClef[indexClef];
                        indexClef++;
                    }
                }
            }

            // Placer chaque caractère dans la grille
            int index = 0;
            for (int i = 0; i < tailleGrille; i++)
            {
                for (int j = 0; j < tailleGrille; j++)
                {
                    if (index < caracteres.Length)
                    {
                        grille[i, j] = caracteres[index];
                        index++;
                    }
                }
            }
            // Afficher la grille avec des bordures
            Console.WriteLine("Vous avez choisis la méthode de Vigenère !");
            Console.WriteLine("------------------------------------------");

            // Afficher le mot-clé
            Console.WriteLine("Votre mot-clé :");
            Console.WriteLine("");
            Console.WriteLine(motClef);
            Console.WriteLine("");

            // Afficher le mot
            Console.WriteLine("Votre mot :");
            Console.WriteLine("");
            string motUser = caract.ToString();
            Console.WriteLine(motUser);
            Console.WriteLine("");


            // Afficher les numéros attribués à chaque lettre du mot-clé
            Console.WriteLine("Numéros :");
            Console.WriteLine("");
            for (int i = 0; i < motUser.Length; i++)
            {
                Console.Write(i + 1 + " | ");
            }
            Console.WriteLine();

            // Affichage de la grille
            Console.WriteLine("");
            Console.WriteLine("Grille :");
            Console.WriteLine("");
            Console.WriteLine("+" + new string('-', tailleGrille) + "+");

            for (int i = 0; i < tailleGrille; i++)
            {
                Console.Write("|");
                for (int j = 0; j < tailleGrille; j++)
                {
                    if (grille[i, j] != '\0')
                    {
                        Console.Write((char)grille[i, j]);
                    }
                    else
                    {
                        Console.Write("");
                    }
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+" + new string('-', tailleGrille) + "+");
        }
        static int a = 17;
        static int b = 20;
        public string cryptageAffine(char[] msg)
        {

            Console.WriteLine("Vous avez choisis la méthode de cryptage affine !");
            Console.WriteLine("------------------------------------------");
            /// innitialise le txt
            String cipher = "";
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] != ' ')
                {
                    cipher = cipher
                            + (char)((((a * (msg[i] - 'A')) + b) % 26) + 'A');
                }
                else
                {
                    cipher += msg[i];
                }
            }
            return cipher;
        }

        static String decryptCipher(String cipher)
        {
            String msg = "";
            int a_inv = 0;
            int flag = 0;

            //Trouver a^-1 (l'inverse multiplicatif de a
            //dans le groupe des entiers modulo m.)
            for (int i = 0; i < 26; i++)
            {
                flag = (a * i) % 26;

                // Vérifiez si (a*i)%26 == 1,
                // alors je serai l'inverse multiplicatif de a
                if (flag == 1)
                {
                    a_inv = i;
                }
            }
            for (int i = 0; i < cipher.Length; i++)
            {
                /*Application de la formule de déchiffrement a^-1 ( x - b ) modulo m
                 {ici x est cipher[i] et m est 26} et ajouté 'A'
                 pour l'amener dans la gamme de l'alphabet ASCII[ 65-90 | A-Z ] */
                if (cipher[i] != ' ')
                {
                    msg = msg + (char)(((a_inv *
                            ((cipher[i] + 'A' - b)) % 26)) + 'A');
                }
                else 
                {
                    msg += cipher[i];
                }
            }
            return msg;
        }
    }
}