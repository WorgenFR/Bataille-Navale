using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    public class PartieDeBatailleNavale    
    {
        public IContratDuJoueurDeBatailleNavale Attaquant { get; private set; }
        public IContratDuJoueurDeBatailleNavale Défenseur { get; private set; }

        private IContratDuJoueurDeBatailleNavale Joueur1;
        private IContratDuJoueurDeBatailleNavale Joueur2;

        public PartieDeBatailleNavale(IContratDuJoueurDeBatailleNavale Joueur1, IContratDuJoueurDeBatailleNavale Joueur2)
        {
            if (Joueur1 == null || Joueur2 == null)
            {
                throw new ArgumentNullException();
            }
        }

        public void ChoisirLesRôlesDeDépartDesJoueurs()
        {
            Random objRandom = new Random();
            int choix = objRandom.Next(1,3);

            if (choix == 2)
            {
                Attaquant = this.Joueur1;
                Défenseur = this.Joueur2;
            }
            if (choix == 1)
            {
                Attaquant = this.Joueur2;
                Défenseur = this.Joueur1;
            }
        }

        public void IntervertirLesRôlesDesJoueurs()
        {
            if (Attaquant == this.Joueur1)
            {
                Défenseur = this.Joueur1;
                Attaquant = this.Joueur2;
            }
            else
            {
                Défenseur = this.Joueur2;
                Attaquant = this.Joueur1;
            }
        }

        public void PréparerLaBataille()
        {
            this.Joueur1.PréparerLaBataille();
            this.Joueur2.PréparerLaBataille();
        }

        public void JouerLaPartie()
        {
            RésultatDeTir res = RésultatDeTir.Inconnu;
            ChoisirLesRôlesDeDépartDesJoueurs();
            while ( res != RésultatDeTir.TouchéCouléFinal)
            {
                CoordonnéesDeBatailleNavale coordo = Attaquant.Attaquant_ChoisirLesCoordonnéesDeTir();
                res = Défenseur.Défenseur_FournirLeRésultatDuTir(coordo);

                if (res != RésultatDeTir.TouchéCouléFinal)
                {
                    IntervertirLesRôlesDesJoueurs();
                }
            }
        }

    }
}



