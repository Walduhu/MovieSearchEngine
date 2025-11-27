using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

public interface IAct
{
    string? Vorname { get; }
    string? Nachname { get; }

    ImmutableList<IFilm> Filme { get; }
    ImmutableList<ISync> Syncs { get; }

    void AddFilm(IFilm film);
    void RemoveFilm(IFilm film);

    void AddSync(ISync sync);
    void RemoveSync(ISync sync);
}

