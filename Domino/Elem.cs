using System;

namespace Domino
{
    public class Elem
    {
        private int _elso;
        private bool _elsoSzabad;
        private int _masodik;
        private bool _masodikSzabad;
        private bool _lerakott = false;


        public int Elso => _elso;
        public bool ElsoSzabad => _elsoSzabad;
        public int Masodik => _masodik;
        public bool MasodikSzabad => _masodikSzabad;
        public bool Lerakott
        {
            get => _lerakott;
            set => _lerakott = value;
        }


        public Elem(int elso, int masodik)
        {
            _elso = elso;
            _elsoSzabad = true;
            _masodik = masodik;
            _masodikSzabad = true;
            
        }

        public Elem(string szoveg)
        {
            int[] tmp = Array.ConvertAll(szoveg.Split('|'), Int32.Parse);
            _elso = tmp[0];
            _elsoSzabad = true;
            _masodik = tmp[1];
            _masodikSzabad = true;
        }

        public void ElsoHasznal()
        {
            _elsoSzabad = false;
        }
        public void MasodikHasznal()
        {
            _masodikSzabad = false;
        }

        public void Lerak()
        {
            _lerakott = true;
        }
    }
}