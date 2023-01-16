using System;

namespace Cuisine
{
    class Program
    {
        static void Main(string[] _)
        {
            try
            {
                Console.WriteLine("Console de la cuisine");
                Cuisine cuisine = new()
                {
                    AnnoncerChangement = Console.WriteLine
                };
                while (true) // Cuisine éternelle
                    cuisine.Tour();
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
