using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    abstract class UnJoueurAvecUneFlotteDeNavires : IContratDuJoueurDeBatailleNavale
    {
        public UneFlotteDeNavires Flotte { get; set; }
        public string Pseudo { get; private set; }

        public UnJoueurAvecUneFlotteDeNavires(String pseudo)
        {
            this.Pseudo = pseudo;

            if (pseudo == null)
            {
                throw new ArgumentNullException();
            }

            UneFlotteDeNavires flotte = new UneFlotteDeNavires();
            Flotte = flotte;
        }

        public virtual void PréparerLaBataille() { };

        abstract public CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir();

        abstract public RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coords);

        abstract public void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordo, RésultatDeTir res);

    }
}