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
                bool etatChange = platSeFaisantManger != null;
                
                if (etatChange) 
                    Annoncer();

                // Attendre 10 millisecondes si le plat est nul, sinon on va bombarder la BD
                int tempsDAttente = platSeFaisantManger is null ? 10 : platSeFaisantManger.Taille;
                Thread.Sleep(tempsDAttente);
                
                platSeFaisantManger = null;

                if (etatChange) 
                    Annoncer();
            }
        }

        private Plat PrendrePlat()
        {
            Plat p = null;

            lock (verrouChoixPlat) // Verrou partagé avec tous les ogres
            {
                try
                {
                    p = contexte.Plats.FirstOrDefault();
                    if (p != null)
                    {
                        contexte.Plats.Remove(p);
                        contexte.SaveChanges();
                    }
                }
                catch(Exception e)
                {
                    Console.Error.WriteLine(e);
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
