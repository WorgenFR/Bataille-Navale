using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    public class UneSectionDeNavire
    {
        public EtatDeSectionDeNavire Etat; //Etat de la section
        public CoordonnéesDeBatailleNavale Position; //Position de la section sur la grille

        public UneSectionDeNavire()
        {
            this.Etat = EtatDeSectionDeNavire.Intact;
            this.Position = new CoordonnéesDeBatailleNavale('A',1);
        }


    }
}
