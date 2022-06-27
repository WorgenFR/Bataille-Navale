using System;

namespace JouerUnePartieDeBatailleNavale
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bataille navale");
            Console.WriteLine("Bonjour joueur 1 ");
            UnJoueurHumainDerrièreLaConsole joueur1 = new UnJoueurHumainDerrièreLaConsole();
            Console.WriteLine("Bonjour joueur 2 ");
            UnJoueurHumainDerrièreLaConsole joueur2 = new UnJoueurHumainDerrièreLaConsole();
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1, joueur2);
            bool nouvellePartie;
            do
            {
                partie.ChoisirLesRôlesDeDépartDesJoueurs();
                Console.WriteLine("Le joueur {0} est le premier attaquant",partie.Attaquant.Pseudo);
        

                partie.PréparerLaBataille();
                Console.WriteLine("La partie commence maintenant");
                partie.JouerLaPartie();

                Console.WriteLine("Nouvelle partie ? (O/N) :");
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                if (keyinfo.KeyChar == 'O' || keyinfo.KeyChar == 'o')
                    nouvellePartie = true;
                else
                    nouvellePartie = false;
            }
            while (nouvellePartie);
        }
    }
}
