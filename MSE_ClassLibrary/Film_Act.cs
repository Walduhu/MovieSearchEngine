using MSE_ClassLibrary.Interfaces;

namespace MSE_ClassLibrary
{
    public class Film_Act : IFilm_Act
    {
        public int FilmID { get; set; }
        public int ActID { get; set; }

        public Film? Film { get; set; }
        public Act? Actor { get; set; }

        // Interface implementations
        IFilm? IFilm_Act.Film => Film;
        IAct? IFilm_Act.Actor => Actor;
    }

}
