using Microsoft.EntityFrameworkCore;

namespace MSE_ClassLibrary
{
    public class SearchService
    {
        private readonly MovieDB _db;

        public SearchService(MovieDB db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }

        public SearchResult PerformSearch(string term)
        {
            var lowerTerm = term.ToLower();
            var result = new SearchResult();

            // Filme
            var filmMatches = _db.tbl_film
                .Include(f => f.Director)
                .Include(f => f.Film_Acts)
                    .ThenInclude(fa => fa.Actor)
                        .ThenInclude(a => a.Act_Syncs)
                            .ThenInclude(asyn => asyn.Sync)
                .Where(f =>
                    (f.TitelD != null && f.TitelD.ToLower().Contains(lowerTerm)) ||
                    (f.TitelOG != null && f.TitelOG.ToLower().Contains(lowerTerm)))
                .ToList();

            result.FilmMatches = filmMatches;
            result.FilmCount = filmMatches.Count;

            // Jahr-Suche
            if (int.TryParse(term, out int year)) // ist Eingabe eine Zahl?
            {
                var yearMatches = _db.tbl_film
                .Where(f => f.Jahr.ToString().Contains(term))
                .ToList();

                result.YearMatches = yearMatches;
                result.YearCount = yearMatches.Count;
            }

            // Regisseure
            var dirMatches = _db.tbl_dir
                .Include(d => d.Filme)
                .Where(d => d.Vorname.ToLower().Contains(lowerTerm) ||
                            d.Nachname.ToLower().Contains(lowerTerm))
                .ToList();
            result.DirMatches = dirMatches;
            result.DirCount = dirMatches.Count;

            // Schauspieler
            var actMatches = _db.tbl_act
                .Where(a => a.Vorname.ToLower().Contains(lowerTerm) ||
                            a.Nachname.ToLower().Contains(lowerTerm))
                .ToList();
            result.ActMatches = actMatches;
            result.ActCount = actMatches.Count;

            // Synchronsprecher
            var syncMatches = _db.tbl_sync
                .Where(s => s.Vorname.ToLower().Contains(lowerTerm) ||
                            s.Nachname.ToLower().Contains(lowerTerm))
                .ToList();
            result.SyncMatches = syncMatches;
            result.SyncCount = syncMatches.Count;

            // Gesamtanzahl
            result.TotalCount = result.FilmCount + result.ActCount + result.DirCount + result.SyncCount + result.YearCount;

            return result;
        }

        public class SearchResult
        {
            public int TotalCount { get; set; }
            public int FilmCount { get; set; }
            public int YearCount { get; set; }
            public int DirCount { get; set; }
            public int ActCount { get; set; }
            public int SyncCount { get; set; }

            public List<Film> FilmMatches { get; set; } = new();
            public List<Film> YearMatches { get; set; } = new();
            public List<Dir> DirMatches { get; set; } = new();
            public List<Act> ActMatches { get; set; } = new();
            public List<Sync> SyncMatches { get; set; } = new();
        }

    }
}
