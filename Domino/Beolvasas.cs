using System;
using System.IO;

namespace Domino
{
    public static class Beolvasas
    {

        public static Elem[] Beolvas()
        {
            Elem[] data = new Elem[0];
            int szamlalo = 0;
            int end = Kezdosor();
            while (szamlalo < end)
            {
                TombNoveles(ref data,Sor());
                szamlalo++;
            }

            return data;
        }
        
        private static int Kezdosor()
        {
            int data = Int32.Parse(Console.ReadLine());
            return data;
            

        }
        private static Elem Sor()
        {
            return new Elem(Console.ReadLine());
        }

        private static void TombNoveles(ref Elem[] data, Elem ujElem)
        {
            Elem[] tmp = new Elem[data.Length + 1];
            for (int i = 0; i < data.Length; i++)
            {
                tmp[i] = data[i];
            }

            tmp[data.Length] = ujElem;
            data = tmp;
        }
    }
}