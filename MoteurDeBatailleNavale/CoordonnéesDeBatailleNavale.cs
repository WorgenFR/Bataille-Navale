using System;

namespace MoteurDeBatailleNavale
{

    public enum RésultatDeTir
    {
        Inconnu,
        Raté,
        Touché,
        TouchéCoulé,
        TouchéCouléFinal
    }

    public enum EtatDeSectionDeNavire
    {
        Intact,
        Touché
    }

    public enum EtatDeNavire
    {
        Intact,
        Touché,
        Coulé
    }

    public enum OrientationNavire
    {
        Horizontal,
        Vertical
    }
 

    public class CoordonnéesDeBatailleNavale
    {
        public char Colonne; //valeur comprise entre A et J
        public byte Ligne; //valeur comprise entre 1 et 10

        private CoordonnéesDeBatailleNavale() { }

        public CoordonnéesDeBatailleNavale(char colonne, byte ligne)
        {
            this.Colonne = colonne;
            this.Ligne = ligne;

            if (ligne < 1 || ligne > 10 || colonne < 'A' || colonne > 'J')
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public override bool Equals(object o)
        {
            bool res = false;
            if (o is CoordonnéesDeBatailleNavale d && d.Colonne != ' ' && d.Ligne != 0)
                if (d.Colonne == this.Colonne && d.Ligne == this.Ligne)
                    res = true;
            return res;
        }
    }
}
