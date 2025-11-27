using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

public interface IDir
{
    string? Vorname { get; }
    string? Nachname { get; }

    ImmutableList<IFilm> Filme { get; }
}

