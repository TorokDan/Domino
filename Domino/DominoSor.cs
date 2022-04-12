using System.ComponentModel;

namespace Domino
{
    public class DominoSor
    {
        private Elem[] _data;
        
        public DominoSor(Elem[] data)
        {
            _data = data;
        }

        public char SorbaRakas()
        {
            while (0 < _data.Length && Keres(_data[0].Ertek[0]) != -1)
            {
                
            }
            return 0 == _data.Length ? 'Y' : 'N';
        }

        private int Keres(int keresett)
        {
            int szamlalo = 0;
            while (szamlalo < _data.Length && !Vizsgal(szamlalo, keresett))
                szamlalo++;

            int vissza;
            if (szamlalo < _data.Length)
            {
                if (_data[szamlalo].Ertek[0] == keresett)
                    vissza = _data[szamlalo].Ertek[1];
                else
                    vissza = _data[szamlalo].Ertek[0];
                ElemTorles(szamlalo);
            }
            else
                vissza = -1;
            return vissza;
        }

        private void ElemTorles(int szamlalo)
        {
            Elem[] tmp = new Elem[_data.Length - 1];
            int seged = 0;
            for (int i = 0; i < tmp.Length; i++)
                if (seged != szamlalo)
                    tmp[i] = _data[seged++];
            _data = tmp;
        }

        private bool Vizsgal(int szamlalo ,int ertek)
        {
            if (_data[szamlalo].Ertek[0] == ertek ||
                _data[szamlalo].Ertek[1] == ertek)
                return true;
            return false;
        }
    }
}