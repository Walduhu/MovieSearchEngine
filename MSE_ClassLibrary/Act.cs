using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

namespace MSE_ClassLibrary
{
    public class Act : IAct
    {
        public int ActID { get; set; } // internal ID
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

        public ICollection<Film_Act>? Film_Acts { get; set; }
        public ICollection<Act_Sync>? Act_Syncs { get; set; }

        // Interface implementations
        ImmutableList<IFilm_Act> IAct.Film_Acts =>
            Film_Acts?.Select(fa => (IFilm_Act)fa).ToImmutableList()
            ?? ImmutableList<IFilm_Act>.Empty;

        ImmutableList<IAct_Sync> IAct.Act_Syncs =>
            Act_Syncs?.Select(async => (IAct_Sync)async).ToImmutableList() ?? ImmutableList<IAct_Sync>.Empty;
    }

}