using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    class UnJoueurHumainDerrièreLaConsole : IContratDuJoueurDeBatailleNavale
    {
        public string Pseudo { get; private set;}
        public UnJoueurHumainDerrièreLaConsole()
        {
            Console.WriteLine("Saisissez un pseudo");
            string txt = Console.ReadLine();
            Pseudo = txt;
        }
        public void PréparerLaBataille() {}

        public CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir()
        {
            Console.WriteLine(Pseudo + " : Saisissez des coordonnées de tir comprises entre 'A-J' et '1-10' ");
            string saisie = Console.ReadLine();
            return new CoordonnéesDeBatailleNavale('A', 1);

        }

        public RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coords)
        {
            Console.WriteLine(Pseudo + "Saisissez des coordonnées de tir comprises entre 'A-J' et '1-10' ");
            string valeur = Console.ReadLine();
            foreach (string i in Enum.GetValues(typeof(RésultatDeTir)))
            {
                switch (i)
                {
                    case "Inconnu":
                        return RésultatDeTir.Inconnu;
                    case "Raté":
                        return RésultatDeTir.Raté;
                    case "Touché":
                        return RésultatDeTir.Touché;
                    case "TouchéCoulé":
                        return RésultatDeTir.TouchéCoulé;
                    case "TouchéCouléFinal":
                        return RésultatDeTir.TouchéCouléFinal;
                }
            }
            return RésultatDeTir.Inconnu;
        }

        public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordo, RésultatDeTir res)
        {
            res = Défenseur_FournirLeRésultatDuTir(coordo);
            Console.WriteLine(res);
        }
    }
}
