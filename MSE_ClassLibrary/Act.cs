using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

namespace MSE_ClassLibrary
{
    public class Act : IAct
    {
        public int ActID { get; set; } // EF primary key
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }


        // navigation properties (interne Join-Tabellen)
        public List<Film_Act> Film_Acts { get; set; } = new();
        public List<Act_Sync_Film> Act_Sync_Films { get; set; } = new();

        // interface properties
        ImmutableList<IFilm> IAct.Filme =>
            Film_Acts
                .Where(fa => fa.Film != null)
                .Select(fa => (IFilm)fa.Film!)
                .ToImmutableList();
        ImmutableList<ISync> IAct.Syncs => 
            Act_Sync_Films
                .Where(asf => asf.Sync != null)
                .Select(asf => (ISync)asf.Sync!)
                .ToImmutableList();

        // Film-Methoden
        public void AddFilm(IFilm film)
        {
            if (film is not Film konkreterFilm)
                throw new ArgumentException("Film muss vom Typ 'Film' sein", nameof(film));

            // doppelte Einträge verhindern
            if (!Film_Acts.Any(fa => fa.FilmID == konkreterFilm.FilmID))
            {
                Film_Acts.Add(new Film_Act
                {
                    Film = konkreterFilm,
                    FilmID = konkreterFilm.FilmID,
                    Act = this,
                    ActID = ActID
                });
            }
        }
        public void RemoveFilm(IFilm film)
        {
            if (film is not Film konkreterFilm) 
                return;

            var filmActMapping = Film_Acts.FirstOrDefault(fa => fa.FilmID == konkreterFilm.FilmID);
            if (filmActMapping != null)
                Film_Acts.Remove(filmActMapping);
        }


        // Sync-Methoden
        public void AddSync(ISync sync)
        {
            if (sync is not Sync konkreterSync)
                throw new ArgumentException("Synchronsprecher muss vom Typ 'Sync' sein", nameof(sync));

            if (!Act_Sync_Films.Any(a => a.SyncID == konkreterSync.SyncID))
            {
                Act_Sync_Films.Add(new Act_Sync_Film
                {
                    Act = this,
                    ActID = ActID,
                    Sync = konkreterSync,
                    SyncID = konkreterSync.SyncID
                });
            }
        }
        public void RemoveSync(ISync sync)
        {
            if (sync is not Sync konkreterSync)
                return;

            var actSyncMapping = Act_Sync_Films.FirstOrDefault(a => a.SyncID == konkreterSync.SyncID);
            if (actSyncMapping != null)
                Act_Sync_Films.Remove(actSyncMapping);
        }

    }

}