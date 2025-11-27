using MSE_ClassLibrary.Interfaces;
using System.Collections.Immutable;

namespace MSE_ClassLibrary
{
    public class Sync : ISync
    {
        public int SyncID { get; set; } // internal ID
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

        // Navigation property
        public List<Act_Sync_Film> Act_Sync_Films { get; set; } = new();

        // Interface implementation
        ImmutableList<IAct_Sync_Film> ISync.Act_Sync_Films =>
            Act_Sync_Films
                .Where(a => a != null)
                .Select(a => (IAct_Sync_Film)a)
                .ToImmutableList();

    }
}