using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    public class UnNavire
    {
        public String Nom { get; private set; }
        public EtatDeNavire Etat { get; private set; }
        public OrientationNavire Orientation { get; private set; }
        public UneSectionDeNavire[] Sections { get; private set; }

        private UnNavire() {} 
        public UnNavire(String Name, byte nbSec)
        {
            this.Nom = Name;

            if (nbSec < 1 || nbSec > 6)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (nbSec == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}