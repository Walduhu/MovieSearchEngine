using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

namespace MSE_ClassLibrary
{
    public class Film : IFilm
    {
        public int FilmID { get; set; } // internal ID
        public string? TitelD { get; set; }
        public string? TitelOG { get; set; }
        public int Jahr { get; set; }

        public int? DirectorID { get; set; } // FK

        // Navigation properties
        public Dir? Director { get; set; }
        public ICollection<Film_Act>? Film_Acts { get; set; } 
        public List<Act_Sync_Film> Act_Sync_Films { get; set; } = new();

        // Interface implementations
        IDir? IFilm.Director => Director;
        ImmutableList<IFilm_Act> IFilm.Film_Acts =>
            Film_Acts?.Select(fa => (IFilm_Act)fa).ToImmutableList()
            ?? ImmutableList<IFilm_Act>.Empty;

    }

}
