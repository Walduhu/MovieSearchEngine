namespace MSE_ClassLibrary
{
    public class Dir
    {
        public int DirID { get; set; }
        public string? Vorname { get; set; }
        public string? Nachname { get; set; }

        public ICollection<Film>? Filme { get; set; } = new List<Film>(); // Navigation property

    }
}