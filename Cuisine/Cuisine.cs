
using Cuisine.Modeles;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Cuisine
{
    // TODO : Terminer la journée
    // TODO : Afficher les statistiques à la fin de la journée

    public class Cuisine
    {
        public BuffetBDContext Contexte { get; set; }

        public Action<string> Notifier { get; set; }

        public const int TAILLE_PLAT_MOYEN = 5000;
        public const int TEMPS_MOYEN_PREPARATION_PLAT = 800;

        private readonly string[] plats;

        static readonly Random rand = new Random();

        public Cuisine()
        {
            Contexte = new BuffetBDContext();
            plats = new string[] {
                "Asperge", "Artichaut", "Aubergine", "Betterave", "Beurre", "Brocoli", "Cambembert", "Chataîgne", "Carotte",
                "Datte", "Echalote", "Epinard", "Fenouil", "Fève", "Figue", "Grenade", "Groseille", "Goyave",
                "Haricot", "Huitre", "Kiwi", "Laitue", "Lentille", "Lait de vache", "Mais", "Mangue", "Melon",
                "Navet", "Noix de coco", "Oeuf", "Orange", "Pain", "Patate", "Poireau", "Radis", "Raisin", "Riz",
                "Sardine", "Saumon", "Tomate", "Yogourt" };
        }


        public void Tour()
        {
            Plats c = NouveauPlat();
            Contexte.Plats.Add(c);
            Contexte.SaveChanges();
            Notifier(c.ToString());

            Thread.Sleep((int)DistributionExponentielle(TEMPS_MOYEN_PREPARATION_PLAT));
        }

        public Plats NouveauPlat()
        {
            return new Plats
            {
                Taille = (int)DistributionExponentielle(TAILLE_PLAT_MOYEN),
                Nom = plats[rand.Next(0, plats.Length)],
                DateCreation = DateTime.Now,
            };
        }

        private double DistributionExponentielle(int esperance)
        {
            return -esperance * Math.Log(1 - rand.NextDouble());
        }
    }
}

// PM > Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=BuffetBD;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
