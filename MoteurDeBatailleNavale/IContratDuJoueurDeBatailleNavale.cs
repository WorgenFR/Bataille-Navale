using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    public interface IContratDuJoueurDeBatailleNavale
    {
        string Pseudo { get; }

        void PréparerLaBataille();

        CoordonnéesDeBatailleNavale Attaquant_ChoisirLesCoordonnéesDeTir();


        RésultatDeTir Défenseur_FournirLeRésultatDuTir(CoordonnéesDeBatailleNavale coordo);

        void Attaquant_GérerLeRésultatDuTir(CoordonnéesDeBatailleNavale coordo, RésultatDeTir res);

    }
}
