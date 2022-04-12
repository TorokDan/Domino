using System;

namespace Domino
{
    class Program
    {
        static void Main(string[] args)
        {
            DominoSor sor = new DominoSor(Beolvasas.Beolvas());
            Console.WriteLine(sor.SorbaRakas());
            ;
        }
    }
}