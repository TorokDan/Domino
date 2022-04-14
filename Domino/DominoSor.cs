
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
            int dataEredetiHossza = _data.Length;
            Elem talalt = _data[0];
            Elem elso = _data[0];
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
            return _sor.Length == dataEredetiHossza ? 'Y' : 'N';
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
    }
}