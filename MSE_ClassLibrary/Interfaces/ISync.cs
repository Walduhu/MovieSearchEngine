using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

public interface ISync
{
    string? Vorname { get; }
    string? Nachname { get; }

    ImmutableList<IAct_Sync> Act_Syncs { get; }
}

