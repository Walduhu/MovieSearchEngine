using System.Collections.Immutable;

namespace MSE_ClassLibrary.Interfaces
{
    public interface IFilm
    {
        string? TitelD { get; }
        string? TitelOG { get; }
        int Jahr { get; }

        IDir? Director { get; }
        ImmutableList<IFilm_Act> Film_Acts { get; }
    }
}
