using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

namespace MSE_ClassLibrary
{
    public class SearchService
    {
        private readonly MovieDB _db;

        public SearchService(MovieDB db)
        {
            _db = db;
        }

        public SearchResult PerformSearch(string term)
        {
            term = term.Trim();

            // Ergebnisse aus Methoden holen
            var filmMatches = SucheFilme(term);
            var dirMatches = SucheRegisseure(term);
            var actMatches = SucheSchauspieler(term);
            var syncMatches = SucheSynchronsprecher(term);
            var yearMatches = SucheJahr(term);

            // SearchResult-Objekt bauen
            return new SearchResult
            {
                FilmMatches = filmMatches.ToImmutableList(),
                DirMatches = dirMatches.ToImmutableList(),
                ActMatches = actMatches.ToImmutableList(),
                SyncMatches = syncMatches.ToImmutableList(),
                YearMatches = yearMatches.ToImmutableList()
            };
        }

        // Private Suchmethoden

        private List<IFilm> SucheFilme(string term)
        {
            return _db.tbl_film
                .Where(f => f.TitelD!.ToLower().Contains(term.ToLower()) ||
                            f.TitelOG!.ToLower().Contains(term.ToLower()))
                .Cast<IFilm>()
                .ToList();
        }

        private List<IDir> SucheRegisseure(string term)
        {
            return _db.tbl_dir
                .Where(d => d.Vorname!.ToLower().Contains(term.ToLower()) ||
                            d.Nachname!.ToLower().Contains(term.ToLower()))
                .Cast<IDir>()
                .ToList();
        }

        private List<IAct> SucheSchauspieler(string term)
        {
            return _db.tbl_act
                .Where(a => a.Vorname!.ToLower().Contains(term.ToLower()) ||
                            a.Nachname!.ToLower().Contains(term.ToLower()))
                .Cast<IAct>()
                .ToList();
        }

        private List<ISync> SucheSynchronsprecher(string term)
        {
            return _db.tbl_sync
                .Where(s => s.Vorname!.ToLower().Contains(term.ToLower()) ||
                            s.Nachname!.ToLower().Contains(term.ToLower()))
                .Cast<ISync>()
                .ToList();
        }

        private List<IFilm> SucheJahr(string term)
        {
            if (int.TryParse(term, out var year)) // ist Eingabe ein int?
            {
                // exakte Jahr-Suche, z.B. "1999"
                return _db.tbl_film
                    .Where(f => f.Jahr == year)
                    .Cast<IFilm>()
                    .ToList();
            }

            // partielle Jahr-Suche, z.B. "99" oder "20"
            return _db.tbl_film
                    .Where(f => f.Jahr.ToString().Contains(term))
                    .Cast<IFilm>()
                    .ToList();
        }
    }

    public sealed class SearchResult
    {
        // leer initialisierte Listen, um NullReferenceExceptions zu vermeiden
        public ImmutableList<IFilm> FilmMatches { get; set; } = [];
        public int FilmCount => FilmMatches.Count;

        public ImmutableList<IDir> DirMatches { get; set; } = [];
        public int DirCount => DirMatches.Count;

        public ImmutableList<IAct> ActMatches { get; set; } = [];
        public int ActCount => ActMatches.Count;

        public ImmutableList<ISync> SyncMatches { get; set; } = [];
        public int SyncCount => SyncMatches.Count;

        public ImmutableList<IFilm> YearMatches { get; set; } = [];
        public int YearCount => YearMatches.Count;

        public int TotalCount => FilmCount + DirCount + ActCount + SyncCount + YearCount;
    }

}

