using MSE_ClassLibrary.Interfaces;

namespace MSE_ClassLibrary
{
    public class Act_Sync : IAct_Sync
    {
        public int ActID { get; set; }
        public int SyncID { get; set; }

        public Act? Actor { get; set; }
        public Sync? Sync { get; set; }

        // Interface implementations
        IAct? IAct_Sync.Actor => Actor;
        ISync? IAct_Sync.SyncSpeaker => Sync;
    }

}
