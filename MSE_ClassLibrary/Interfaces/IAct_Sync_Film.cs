namespace MSE_ClassLibrary.Interfaces
{
    public interface IAct_Sync_Film
    {
        IFilm Film { get; }
        IAct Act { get; }
        ISync Sync { get; }
    }
}
