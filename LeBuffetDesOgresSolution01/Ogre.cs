using Ogres.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ogres
{
    public class Ogre
    {
        public Action Annoncer { get; set; }

        private readonly BuffetBDContext contexte = new BuffetBDContext();

        private Plat platSeFaisantManger;

        private static readonly object verrouChoixPlat = new object();

        public string Name { get; set; }

        public Ogre(string name)
        {
            Name = name;
        }

        public void Demarrer()
        {
            while (true) // Manger pour l'éternité
            {
                platSeFaisantManger = PrendrePlat();
                Annoncer();

                int tempsDAttente = platSeFaisantManger is null ? 10 : platSeFaisantManger.Taille;
                // Attendre 10 millisecondes si le plat est nul, sinon on va bombarder la BD
                Thread.Sleep(tempsDAttente);
                
                platSeFaisantManger = null;
                Annoncer();
            }
        }

        private Plat PrendrePlat()
        {
            Plat p = null;

            lock (verrouChoixPlat)
            {
                if (Name.Contains("1"))
                {

                }
                else if (Name.Contains("2"))
                {

                }
                else if (Name.Contains("3"))
                {

                }
                else if (Name.Contains("4"))
                {

                }
                else if (Name.Contains("5"))
                {

                }
                p = contexte.Plats.FirstOrDefault();
                if (p != null)
                {
                    contexte.Plats.Remove(p);
                    contexte.SaveChanges();
                }
            }
            return p;
        }

        public override string ToString()
        {
            return Name + " mange " + platSeFaisantManger;
        }
    }
}
