using MSE_ClassLibrary;
using SQLitePCL;

namespace WinFormsMovieSearchEngine
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Batteries.Init();

            using var db = new MovieDB();   // DB-Kontext erstellen
            db.Database.EnsureCreated();    // erstellt DB neu    
            MovieDB.SeedData(db);

            var searchService = new SearchService(db);

            ApplicationConfiguration.Initialize();
            Application.Run(new MSEForm(searchService, db));
        }
    }
}