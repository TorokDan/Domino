
namespace Domino
{
    public class DominoSor
    {
        private Elem[] _data;
        private Elem[] _sor;
        private Elem[] _seged;
        
        public DominoSor(Elem[] data)
        {
            _data = data;
            _seged = new Elem[_data.Length];
            for (int i = 0; i < _seged.Length; i++)
                _seged[i] = new Elem(_data[i].Elso, _data[i].Masodik);
            _sor = new Elem[0];
        }

        public char SorbaRakas()
        {
            char valasz = 'N';
            int szamlalo = 0;
            while (valasz != 'Y' &&
                   szamlalo < _seged.Length)
            {
                Reset();
                int dataEredetiHossza = _data.Length;
                Elem talalt = _data[szamlalo];
                Elem elso = _data[szamlalo];
                BeIllesztes(talalt);

                while (_data.Length != 0 &&
                       talalt != null)
                {
                    talalt = Keres(talalt);
                }

                talalt = elso;
                while (_data.Length != 0 &&
                       talalt != null)
                {
                    talalt = Keres(talalt);
                }

                if (_sor.Length == dataEredetiHossza)
                    valasz = 'Y';
                szamlalo++;
            }
            return valasz;
        }

        /// <summary>
        /// Megkeresi azt az elemet a _data tömbben, ami tartalmazza a keresett elem eddig fel nem használt értékét, azon végrehajtja
        /// a Beillesztést, és visszatér az értékével, különben null.
        /// </summary>
        /// <param name="keresett"></param>
        /// <returns></returns>
        private Elem Keres(Elem keresett)
        {
            int szamlalo = 0;
            int keresettSzam = keresett.ElsoSzabad ? keresett.Elso : keresett.Masodik;
            while (szamlalo < _data.Length &&
                   _data[szamlalo].Elso != keresettSzam &&
                   _data[szamlalo].Masodik != keresettSzam)
            {
                szamlalo++;
            }

            if (szamlalo == _data.Length)
            {
                keresett.ElsoHasznal();
                return null;
            }
            else
            {
                Elem tmp = _data[szamlalo];
                if (tmp.Elso == keresettSzam)
                    tmp.ElsoHasznal();
                else
                    tmp.MasodikHasznal();
                if (keresett.ElsoSzabad && keresett.MasodikSzabad)
                {
                    if (keresett.Elso == keresettSzam)
                        keresett.ElsoHasznal();
                    else
                        keresett.MasodikHasznal();
                }
                BeIllesztes(tmp);
                return tmp;
            }
        }

        /// <summary>
        /// A megadott elemet beilleszti a _sor változóba, valamit törli a _datából.
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

            tmp = new Elem[_data.Length - 1];
            int seged = 0;
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] != beillesztendo)
                    tmp[seged++] = _data[i];
            }

            _data = tmp;
        }

        private void Reset()
        {
            _sor = new Elem[0];
            _data = new Elem[_seged.Length];
            for (int i = 0; i < _seged.Length; i++)
                _data[i] = new Elem(_seged[i].Elso, _seged[i].Masodik);
        }
    }
}