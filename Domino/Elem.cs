using System;

namespace Domino
{
    public class Elem
    {
        private int[] _ertek;

        public int[] Ertek => _ertek;
        
        public Elem(int elso, int masodik)
        {
            _ertek = new int[2];
            _ertek[0] = elso;
            _ertek[1] = masodik;
        }

        public Elem(string szoveg)
        {
            _ertek = Array.ConvertAll(szoveg.Split('|'), Int32.Parse);
        }
    }
}