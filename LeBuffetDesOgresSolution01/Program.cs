using System;
using System.Collections.Generic;
using System.Text;

namespace Ogres
{
    class Program
    {
        private static readonly object verrouAffichage = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Console des ogres");
            try
            {
                TableOgres p = new TableOgres();
                p.Afficher = RafraichirConsole;
                p.Start();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            Console.ReadKey();
        }

        public static void RafraichirConsole(string s)
        {
            lock (verrouAffichage)
            {
               // Console.Clear();
                Console.WriteLine(s);
            }
        }
    }
}
