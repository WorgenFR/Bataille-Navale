using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoteurDeBatailleNavale;
using System;
using System.Reflection;

namespace TestsDuMoteurDeBatailleNavale
{
    [TestClass]
    public class Tests_Phase_1_Partie
    {
        [TestMethod]
        public void Phase1_1_Coordonn�esDeBatailleNavale()
        {
            // v�rification du constructeur par d�faut non public
            Type t = typeof(Coordonn�esDeBatailleNavale);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    // v�rification de visibilit�
                    Assert.IsFalse(constructeur.IsPublic, "Le constructeur par d�fautne doit pas �tre public.");
                }
            }
            // v�rification que les param�tres hors plage valide produisent une exception IndexOutOfRangeException
            bool ThrowException = false;
            try
            {
                ThrowException = false;
                for (char c = char.MinValue; c < 'A'; c++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                    Coordonn�esDeBatailleNavale(c, 1);
                }
                for (char c = (char)('J' + 1); c < char.MaxValue; c++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                    Coordonn�esDeBatailleNavale(c, 1);
                }
                Coordonn�esDeBatailleNavale coordonn�eInvalide2 = new
                Coordonn�esDeBatailleNavale('A', 0);
                for (byte l = 11; l < byte.MaxValue; l++)
                {
                    Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                    Coordonn�esDeBatailleNavale('A', l);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La construction de Coordonn�esDeBatailleNavale ne doit accepter que des colonnes de 'A' � 'J' et des lignes de 1 � 10");
            // v�rification que les param�tres dans la plage valide ne produisent pas d'exception
            try
            {
                ThrowException = false;
                for (char c = 'A'; c <= 'J'; c++)
                {
                    for (byte l = 1; l <= 10; l++)
                    {
                        Coordonn�esDeBatailleNavale coordonn�eInvalide = new
                        Coordonn�esDeBatailleNavale(c, l);
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                ThrowException = true;
            }
            Assert.IsFalse(ThrowException, "La construction de Coordonn�esDeBatailleNavale doit accepter des colonnes entre 'A' et 'J' et des lignes entre 1 et 10");
            // v�rification de la m�thode Equals
            try
            {
                Coordonn�esDeBatailleNavale uneInstance = new
                Coordonn�esDeBatailleNavale('C', 5);
                uneInstance.Equals(null);
                uneInstance.Equals(new object());
                uneInstance.Equals(uneInstance);
            }
            catch
            {
                Assert.Fail("Le test d'�galit� ne doit pas provoquer d'exception");
            }
            Assert.IsTrue(new Coordonn�esDeBatailleNavale('C', 5).Equals(new Coordonn�esDeBatailleNavale('C', 5)), "L'�galit� C5 avec C5 doit �tre vraie");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals(null),
           "L'�galit� avec null doit �tre fausse");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals(new Coordonn�esDeBatailleNavale('A', 2)), "L'�galit� A1 avec A2 doit �tre fausse");
            Assert.IsFalse(new Coordonn�esDeBatailleNavale('A', 1).Equals("A1"),
           "L'�galit� entre deux types diff�rents doit �tre fausse");
        }




        public class joueurTest : IContratDuJoueurDeBatailleNavale
        {
            public joueurTest(string pseudo)
            {
                Pseudo = pseudo;
            }
            public string Pseudo { get; private set; }
            public Coordonn�esDeBatailleNavale Attaquant_ChoisirLesCoordonn�esDeTir()
            {
                return new Coordonn�esDeBatailleNavale('A', 1);
            }
            public void Attaquant_G�rerLeR�sultatDuTir(Coordonn�esDeBatailleNavale
           coordonn�esDuTir, R�sultatDeTir r�sultatDuTir)
            {
            }
            public R�sultatDeTir
           D�fenseur_FournirLeR�sultatDuTir(Coordonn�esDeBatailleNavale coordonn�esDuTir)
            {
                return R�sultatDeTir.Touch�Coul�Final;
            }
            public void Pr�parerLaBataille()
            {
            }
        }
        [TestMethod]
        public void Phase1_2_PartieDeBatailleNavale_Constructeur()
        {
            // v�rification du constructeur public
            Type t = typeof(PartieDeBatailleNavale);
            ConstructorInfo constructeurPublique = t.GetConstructor(new Type[] { typeof(IContratDuJoueurDeBatailleNavale), typeof(IContratDuJoueurDeBatailleNavale) });
            Assert.IsNotNull(constructeurPublique, "PartieDeBatailleNavale doit avoir un constructeur public attendant en param�tre 2 instance deIContratDuJoueurDeBatailleNavale");
            bool ThrowException = false;
            try
            {
                PartieDeBatailleNavale p = new PartieDeBatailleNavale(null, null);
                p = new PartieDeBatailleNavale(null, new joueurTest("joueur test"));
                p = new PartieDeBatailleNavale(new joueurTest("joueur test"), null);
            }
            catch (ArgumentNullException)
            {
                ThrowException = true;
            }
            Assert.IsTrue(ThrowException, "La construction de PartieDeBatailleNavalene doit pas accepter les param�tes null");
        }
        [TestMethod]
        public void Phase1_3_PartieDeBatailleNavale_ChoisirLesR�lesDeD�partDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1, joueur2);
            // partie.ChoisirLesR�lesDeD�partDesJoueurs();
            // IContratDuJoueurDeBatailleNavale attaquantDeD�part = partie.Attaquant;
            int joueur1Attaquant = 0;
            int joueur2Attaquant = 0;
            for (int x = 0; x < 1000; x++)
            {
                partie.ChoisirLesR�lesDeD�partDesJoueurs();
                Assert.IsNotNull(partie.Attaquant, "L'attaquant ne peut pas �tre null");
                Assert.IsNotNull(partie.D�fenseur, "Le d�fenseur ne peut pas �tre null");
                if (partie.Attaquant == joueur1)
                {
                    joueur1Attaquant++;
                    Assert.AreEqual(partie.D�fenseur, joueur2, "Incoh�rence entre joueur ataquant et d�fenseur");
                }
                else if (partie.Attaquant == joueur2)
                {
                    joueur2Attaquant++;
                    Assert.AreEqual(partie.D�fenseur, joueur1, "Incoh�rence entre joueur ataquant et d�fenseur");
                }
                else
                {
                    Assert.Fail("Incoh�rence entre joueur ataquant et d�fenseur");
                }
            }
            if (Math.Abs(joueur1Attaquant - joueur2Attaquant) > 100)
            {
                Assert.Fail("Un joueur semble favoris� au tirage au sort de d�part");
            }
        }
        [TestMethod]
        public void Phase1_4_PartieDeBatailleNavale_IntervertirLesR�lesDesJoueurs()
        {
            IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur 1");
            IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur 2");
            PartieDeBatailleNavale partie = new PartieDeBatailleNavale(joueur1, joueur2);
            partie.ChoisirLesR�lesDeD�partDesJoueurs();
            IContratDuJoueurDeBatailleNavale attaquantActuel = partie.Attaquant;
            IContratDuJoueurDeBatailleNavale d�fenseurActuel = partie.D�fenseur;
            for (int x = 0; x < 100; x++)
            {
                partie.IntervertirLesR�lesDesJoueurs();
                if (attaquantActuel == partie.Attaquant)
                {
                    Assert.Fail("L'attaquant n'a pas chang� apr�s l'appel � IntervertirLesR�lesDesJoueurs()");
                }
                Assert.AreEqual(d�fenseurActuel, partie.Attaquant, "Incoh�rence apr�s l'interversion des r�les des joueurs");

                attaquantActuel = partie.Attaquant;
                d�fenseurActuel = partie.D�fenseur;
            }
        }
        [TestMethod]
        public void Phase1_5_PartieDeBatailleNavale_JouerLaPartie()
        {
            for (int x = 0; x < 100; x++)
            {
                try
                {
                    IContratDuJoueurDeBatailleNavale joueur1 = new joueurTest("joueur1");
                    IContratDuJoueurDeBatailleNavale joueur2 = new joueurTest("joueur2");

                    PartieDeBatailleNavale partie = new
                    PartieDeBatailleNavale(joueur1, joueur2);
                    partie.ChoisirLesR�lesDeD�partDesJoueurs();
                    partie.Pr�parerLaBataille();
                    partie.JouerLaPartie();
                }
                catch (Exception)
                {
                    Assert.Fail("Il semble encore y avoir des anomalies dans le d�roulement de la partie...");
                }
            }
        }

        public void Phase_2_1_UneSectionDeNavire()
        {
            Type t = typeof(UneSectionDeNavire);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsTrue(constructeurParDefautPublic, "Le constructeur de UneSectionDeNavire par d�faut doit �tre public.");
            UneSectionDeNavire section = new UneSectionDeNavire();
            Assert.AreEqual(section.Etat, EtatDeSectionDeNavire.Intact, "L'�tat doit �tre initialis� � Intact");
            Assert.IsNotNull(section.Position, "La position ne peut pas �tre null");
            Assert.AreEqual(section.Position, new Coordonn�esDeBatailleNavale('A', 1), "La position doit �tre initialis�e avec A1 ");
        }

        public void Phase_2_2_UnNavire()
        {
            Type t = typeof(UnNavire);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsFalse(constructeurParDefautPublic, "Le constructeur de UnNavire par d�faut ne doit pas �tre public.");
            bool testConstructeurNomNull = false;
            try
            {
                UnNavire testConstructeur = new UnNavire(null, 5);
            }
            catch (ArgumentNullException)
            {
                testConstructeurNomNull = true;
            }
            Assert.IsTrue(testConstructeurNomNull, "Le nom du navire ne peut pas �tre null");
            bool testConstructeurNomVide = false;
            try
            {
                UnNavire testConstructeur = new UnNavire("", 5);
            }
            catch (ArgumentNullException)
            {
                testConstructeurNomVide = true;
            }
            Assert.IsTrue(testConstructeurNomVide, "Le nom du navire ne peut pas �tre vide");
            bool testNbSectionValide = false;
            try
            {
                for (byte s = 0; s < 2; s++)
                {
                    UnNavire testConstructeur = new UnNavire("NomValide", s);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                testNbSectionValide = true;
            }
            Assert.IsTrue(testNbSectionValide, "Le nombre de section ne peut �tre inf�rieur � 2");
            try
            {
                for (byte s = 6; s < byte.MaxValue; s++)
                {
                    UnNavire testConstructeur = new UnNavire("NomValide", s);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                testNbSectionValide = true;
            }
            Assert.IsTrue(testNbSectionValide, "Le nombre de section ne peut �tre sup�rieur � 5");
            for (byte taille = 2; taille < 6; taille++)
            {
                try
                {
                    UnNavire navireDeTailleCorrecte = new UnNavire("MonNavire", taille);
                    Assert.AreEqual(navireDeTailleCorrecte.Sections.Length, taille, "Le nombre de sections doit �tre initialis� par le constructeur");
                }
                catch
                {
                    Assert.Fail("La construction du navire doit accepter une taille entre 2 minimum et 5 maximum");
                }
            }
            UnNavire navire = new UnNavire("Nom_TEST", 5);
            Assert.AreEqual(navire.Nom, "Nom_TEST", "Le nom du navire doit �tre initialis� par le constructeur");
        }

        private string[] NomsDesNaviresDeLaFlotte
        {
            get
            {
                return new string[] { "porte avion", "croiseur", "contre torpilleur", "sous-marin", "torpilleur" };
            }
        }
        private byte[] TaillesDesNaviresDeLaFlotte
        {
            get
            { return new byte[] { 5, 4, 3, 3, 2 }; }
        }
        [TestMethod]
        public void Phase_2_3_UneFlotteDeNavires()
        {
            Type t = typeof(UneFlotteDeNavires);
            ConstructorInfo[] constructeursPubliques = t.GetConstructors();
            bool constructeurParDefautPublic = false;
            foreach (ConstructorInfo constructeur in constructeursPubliques)
            {
                // recherche du constructeur sans param�tre
                if (constructeur.GetParameters().Length == 0)
                {
                    constructeurParDefautPublic = true;
                }
            }
            Assert.IsTrue(constructeurParDefautPublic, "Le constructeur de UneFlotteDeNavire par d�faut doit �tre public");
            UneFlotteDeNavires flotte = new UneFlotteDeNavires();
            Assert.IsTrue(flotte.Navires.Length == 5, "La flotte de navire doit �tre compos�e de 5 navires exactement");
            int navireIndex = 0;
            foreach (UnNavire navire in flotte.Navires)
            {
                Assert.AreEqual(NomsDesNaviresDeLaFlotte[navireIndex], navire.Nom, "Ce navire ne porte pas le bon nom");
                Assert.AreEqual(TaillesDesNaviresDeLaFlotte[navireIndex],
                navire.Sections.Length, String.Format("Le navire {0} n'a pas le bon nombre de section", navire.Nom));
                navireIndex++;
            }
        }
    }
}
