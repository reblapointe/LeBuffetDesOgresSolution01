using Ogres.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ogres
{
    class TableOgres
    {
        public const int NB_OGRES = 7;

        private List<Ogre> ogres;

        private readonly BuffetBDContext contexte = new BuffetBDContext();
        public Action<string> Afficher { get; set; }

        public TableOgres() { }

        public void Start()
        {
            ogres = new List<Ogre>();

            for (int i = 0; i < NB_OGRES; i++)
            {
                Ogre o = new Ogre("Ogre #" + i);
                ogres.Add(o);
                o.Annoncer += Update;
                Task.Run(o.Demarrer);
            }

            Update();
        }

        public void Update()
        {
            string s = "";

            ogres.ForEach(o => s += o.ToString() + Environment.NewLine);
            s += Environment.NewLine + "Table :" + Environment.NewLine;

            foreach (Plat p in contexte.Plats)
                s += p + Environment.NewLine;
            Afficher(s);
        }
    }
}
