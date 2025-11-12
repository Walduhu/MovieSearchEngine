using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

namespace MSE_ClassLibrary
{
    public class Dir : IDir
    {
        public int DirID { get; set; } // internal ID
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

        public ICollection<Film>? Filme { get; set; }

        // Interface implementations
        ImmutableList<IFilm> IDir.Filme =>
            Filme?.Select(f => (IFilm)f).ToImmutableList()
            ?? ImmutableList<IFilm>.Empty;
    }

}