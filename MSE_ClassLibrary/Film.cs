namespace MSE_ClassLibrary
{
    public class Film
    {
        public int FilmID { get; set; }
        public string? TitelD { get; set; }
        public string? TitelOG { get; set; }
        public int Jahr { get; set; }
        public int DirID { get; set; } // Foreign key
        public Dir? Director { get; set; } // Navigation property

        public ICollection<Film_Act>? Film_Acts { get; set; }
    }
}