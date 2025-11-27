using MSE_ClassLibrary.Interfaces;

namespace MSE_ClassLibrary
{
    public class Act_Sync_Film : IAct_Sync_Film
    {
        public int FilmID { get; set; }
        public Film? Film { get; set; }

        public int ActID { get; set; }
        public Act? Act { get; set; }

        public int SyncID { get; set; }
        public Sync? Sync { get; set; }

        // explizite Interface-Implementierungen (readonly views, null forgiving)
        IFilm IAct_Sync_Film.Film => Film!;
        IAct IAct_Sync_Film.Act => Act!;
        ISync IAct_Sync_Film.Sync => Sync!;
    }
}
