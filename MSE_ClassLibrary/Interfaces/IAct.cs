using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

public interface IAct
{
    string? Vorname { get; }
    string? Nachname { get; }

    ImmutableList<IFilm_Act> Film_Acts { get; }
    ImmutableList<IAct_Sync> Act_Syncs { get; }
}

