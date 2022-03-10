using System;
using System.Collections.Generic;
using System.Text;

namespace Ogres
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Console des ogres");
            try
            {
                TableOgres p = new TableOgres();
                p.Afficher = (s) => { Console.Clear(); Console.WriteLine(s); };
                p.Start();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
