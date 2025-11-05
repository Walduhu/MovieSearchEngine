namespace MSE_ClassLibrary
{
    public class Act
    {
        public int ActID { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

        // Nav prop: Beziehung zu Film_Act (n:m-Beziehung zwischen Film und Actor)
        public ICollection<Film_Act>? Film_Acts { get; set; } = new List<Film_Act>();

        // Nav prop: Beziehung zu Act_Sync (n:m-Beziehung zwischen Actor und Synchronsprecher)
        public ICollection<Act_Sync>? Act_Syncs { get; set; } = new List<Act_Sync>();
    }
}