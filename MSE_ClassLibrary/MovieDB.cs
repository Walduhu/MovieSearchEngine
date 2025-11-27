using Microsoft.EntityFrameworkCore;

namespace MSE_ClassLibrary
{
    public class MovieDB : DbContext
    {
        public MovieDB()
        {
        }
        public MovieDB(DbContextOptions<MovieDB> options) : base(options)
        {
        }

        public DbSet<Film> tbl_film { get; set; }
        public DbSet<Dir> tbl_dir { get; set; }
        public DbSet<Act> tbl_act { get; set; }
        public DbSet<Sync> tbl_sync { get; set; }
        public DbSet<Film_Act> tbl_film_act { get; set; }
        public DbSet<Act_Sync_Film> tbl_act_sync_film { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=movies.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>()
                .HasOne(f => f.Director)
                .WithMany(d => d.Filme)
                .HasForeignKey(f => f.DirectorID);

            modelBuilder.Entity<Film_Act>()
                .HasKey(fa => new { fa.FilmID, fa.ActID });

            modelBuilder.Entity<Film_Act>()
                .HasOne(fa => fa.Film)
                .WithMany(f => f.Film_Acts)
                .HasForeignKey(fa => fa.FilmID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Film_Act>()
                .HasOne(fa => fa.Act)
                .WithMany(a => a.Film_Acts)
                .HasForeignKey(fa => fa.ActID)
                .OnDelete(DeleteBehavior.Cascade);

            // zsmgesetzter Primärschlüssel
            modelBuilder.Entity<Act_Sync_Film>()
                .HasKey(asf => new { asf.FilmID, asf.ActID, asf.SyncID });

            // Beziehungen ohne Rücknavigation (keine Collections in den Zielklassen)
            // mit Löschkaskade bei Löschung eines Films, Schauspielers oder Synchronsprechers
            modelBuilder.Entity<Act_Sync_Film>()
                .HasOne(f => f.Film)
                .WithMany()       
                .HasForeignKey(f => f.FilmID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Act_Sync_Film>()
                .HasOne(a => a.Act)
                .WithMany()
                .HasForeignKey(a => a.ActID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Act_Sync_Film>()
                .HasOne(s => s.Sync)
                .WithMany()
                .HasForeignKey(s => s.SyncID)
                .OnDelete(DeleteBehavior.Cascade);
        }


        public static void SeedData(MovieDB db)
        {
            // prüfen, ob schon Daten existieren
            if (db.tbl_film.Any())
                return; // DB ist schon befüllt, also nichts tun

            // Testdaten hinzufügen

            var cam = new Dir { Vorname = "James", Nachname = "Cameron" };
            var nolan = new Dir { Vorname = "Christopher", Nachname = "Nolan" };
            var zilba = new Dir { Vorname = "Gints", Nachname = "Zilbalodis" };
            db.tbl_dir.AddRange(cam, nolan, zilba);
            db.SaveChanges(); // IDs werden generiert

            db.tbl_film.AddRange(
                new Film { TitelD = "Terminator 2 – Tag der Abrechnung", TitelOG = "Terminator 2: Judgment Day", Jahr = 1991, Director = cam },
                new Film { TitelD = "Inception", TitelOG = "Inception", Jahr = 2010, Director = nolan },
                new Film { TitelD = "Interstellar", TitelOG = "Interstellar", Jahr = 2014, Director = nolan },
                new Film { TitelD = "Oppenheimer", TitelOG = "Oppenheimer", Jahr = 2023, Director = nolan },
                new Film { TitelD = "Flow", TitelOG = "Straume", Jahr = 2024, Director = zilba }
            );

            var arnie = new Act { Vorname = "Arnold", Nachname = "Schwarzenegger" };
            var leo = new Act { Vorname = "Leonardo", Nachname = "DiCaprio" };
            var matt = new Act { Vorname = "Matthew", Nachname = "McConaughey" };
            var cil = new Act { Vorname = "Cillian", Nachname = "Murphy" };
            db.tbl_act.AddRange(arnie, leo, matt, cil);

            var tom = new Sync { Vorname = "Thomas", Nachname = "Danneberg" };
            var ger = new Sync { Vorname = "Gerrit", Nachname = "Schmidt-Foß" };
            var ben = new Sync { Vorname = "Benjamin", Nachname = "Völz" };
            var nor = new Sync { Vorname = "Norman", Nachname = "Matt" };
            db.tbl_sync.AddRange(tom, ger, ben, nor);

            db.SaveChanges(); // Schauspieler und Synchronsprecher werden persistiert

            // Beziehungen herstellen

            db.tbl_film_act.AddRange(
                new Film_Act { FilmID = db.tbl_film.First(f => f.TitelD == "Terminator 2 – Tag der Abrechnung").FilmID, ActID = arnie.ActID },
                new Film_Act { FilmID = db.tbl_film.First(f => f.TitelD == "Inception").FilmID, ActID = leo.ActID },
                new Film_Act { FilmID = db.tbl_film.First(f => f.TitelD == "Interstellar").FilmID, ActID = matt.ActID },
                new Film_Act { FilmID = db.tbl_film.First(f => f.TitelD == "Oppenheimer").FilmID, ActID = cil.ActID }
            );

            db.tbl_act_sync_film.AddRange(
                new Act_Sync_Film { ActID = arnie.ActID, SyncID = tom.SyncID, FilmID = db.tbl_film.First(f => f.TitelD == "Terminator 2 – Tag der Abrechnung").FilmID },
                new Act_Sync_Film { ActID = leo.ActID, SyncID = ger.SyncID, FilmID = db.tbl_film.First(f => f.TitelD == "Inception").FilmID },
                new Act_Sync_Film { ActID = matt.ActID, SyncID = ben.SyncID, FilmID = db.tbl_film.First(f => f.TitelD == "Interstellar").FilmID },
                new Act_Sync_Film { ActID = cil.ActID, SyncID = nor.SyncID, FilmID = db.tbl_film.First(f => f.TitelD == "Oppenheimer").FilmID }
            );

            db.SaveChanges();
        }
    }
}