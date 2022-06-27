using System;
using System.Collections.Generic;
using System.Text;

namespace MoteurDeBatailleNavale
{
    public class UneFlotteDeNavires
    {
        public UnNavire[] Navires {get; set;}

        public UneFlotteDeNavires()
        {
            this.Navires[] =  new UnNavire[] { new UnNavire("porte-avion", 5), new UnNavire("croiseur", 4) , new UnNavire("contre-torpilleur", 3), new UnNavire("sous-marin", 3), new UnNavire("torpilleur", 2};
        }
    }
}
