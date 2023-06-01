using System;

namespace CeUAA11_2023_AjdiniSefedin
{
    class program
    {
        static void Main(string[] args)
        {
            //cryptage AFFINE pas réussi
            outils mesOutils = new outils();
            bool continuer = true;
            int tailleGrille = 1;
            char[] msg;
            string cypher = "";
            int[,] grille = new int[tailleGrille, tailleGrille]; // Crée une grille de la taille calculée
            int choix; /// choix entre les options
            do
            {
                mesOutils.LireReel("Choisissez parmis les options suivantes : \n   1 = cryptage de Vigenère\n   2 = cryptage avec la méthode affine\n ", out choix);
                if (choix == 1)
                {
                        // Convertir le mot-clé en un tableau de caractères
                        Console.WriteLine("Entrez un mot-clé :");
                        string motClef = Console.ReadLine();
                        motClef = motClef.Replace(" ", "").Replace("-", "").Replace("_", "").Replace(",", "");
                        char[] motClefs = motClef.ToCharArray();

                        Console.WriteLine("Entrez une phrase :");
                        string caract = Console.ReadLine(); // Demande à l'utilisateur d'entrer une phrase
                        caract = caract.Replace(" ", "").Replace("-", "").Replace("_", "").Replace(",", "");

                        mesOutils.cryptageVegenere(caract, motClef);
                        Console.WriteLine("Voulez-vous encoder une autre phrase ? (o/n)");
                        string reponse = Console.ReadLine();
                        if (reponse.ToLower() != "o")
                        {
                            continuer = false;
                        }
                        Console.Clear();
                }
                if (choix == 2) /// 
                {
                    Console.WriteLine("Entrez une msg :");
                    //char* = new char And char* = new char[N]

                    mesOutils.cryptageAffine(msg);
                    mesOutils.decryptCipher(cipher);
                    Console.WriteLine("Voulez-vous encoder une autre phrase ? (o/n)");
                    string reponse = Console.ReadLine();
                    if (reponse.ToLower() != "o")
                    {
                        continuer = false;
                    }
                    Console.Clear();
                }
            } while (true);
        }
    }
}
