namespace MSE_ClassLibrary
{
    public class Sync
    {
        public int SyncID { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

        // Beziehung zu Act_Sync (n:m-Beziehung zwischen Actor und Synchronsprecher)
        public ICollection<Act_Sync>? Act_Syncs { get; set; } = new List<Act_Sync>();
    }
}