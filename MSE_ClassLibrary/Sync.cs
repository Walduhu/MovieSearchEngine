using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

namespace MSE_ClassLibrary
{
    public class Sync : ISync
    {
        public int SyncID { get; set; } // internal ID
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

        public ICollection<Act_Sync>? Act_Syncs { get; set; }

        // Interface implementations
        ImmutableList<IAct_Sync> ISync.Act_Syncs =>
            Act_Syncs?.Select(a => (IAct_Sync)a).ToImmutableList()
            ?? ImmutableList<IAct_Sync>.Empty;
    }

}