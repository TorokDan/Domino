using System;
using System.ComponentModel;

namespace Domino
{
    public class DominoSor
    {
        private Elem[] _data;
        private Elem[] _sor;
        
        public DominoSor(Elem[] data)
        {
            _data = data;
            _sor = new Elem[0];
        }

        public char SorbaRakas()
        {
            Elem talalt = _data[0];
            BeIllesztes(talalt);
            while (_sor.Length != _data.Length&&
                   talalt != null)
            {
                talalt = Keres(talalt.Elso);
            }
            while (_sor.Length != _data.Length&&
                   talalt != null)
            {
                talalt = Keres(talalt.Masodik);
            }

            return _sor.Length == _data.Length ? 'Y' : 'N';
        }

        /// <summary>
        /// Megkeresi azt az elemet a _data tömbben, ami tartalmazza a keresett értéket, azon végrehajtja
        /// a Beillesztést, és visszatér az értékével, különben null.
        /// </summary>
        /// <param name="keresett"></param>
        /// <returns></returns>
        private Elem Keres(int keresett)
        {
            int szamlalo = 0;
            while (szamlalo < _data.Length && 
                   ((_data[szamlalo].Elso == keresett && _data[szamlalo].ElsoSzabad) || 
                   (_data[szamlalo].Masodik == keresett && _data[szamlalo].MasodikSzabad)))
            {
                szamlalo++;
            }
            if (szamlalo == _data.Length)
                return null;
            else
            {
                if (_data[szamlalo].Elso == keresett && _data[szamlalo].ElsoSzabad)
                    _data[szamlalo].ElsoHasznal();
                else
                    _data[szamlalo].MasodikHasznal();
                BeIllesztes(_data[szamlalo]);
                return _data[szamlalo];
            }
        }

        /// <summary>
        /// A megadott elemet beilleszti a _sor változóba.
        /// </summary>
        /// <param name="beillesztendo"></param>
        private void BeIllesztes(Elem beillesztendo)
        {
            Elem[] tmp = new Elem[_sor.Length + 1];
            for (int i = 0; i < _sor.Length; i++)
            {
                tmp[i] = _sor[i];
            }

            tmp[_sor.Length] = beillesztendo;
            _sor = tmp;
        }
    }
}