using MSE_ClassLibrary;

namespace WinFormsMovieSearchEngine
{
    public partial class MSEForm : Form
    {
        private SearchService _searchService;
        private readonly MovieDB _db;

        public MSEForm(SearchService searchService, MovieDB db)
        {
            InitializeComponent();
            _searchService = searchService;
            _db = db;
        }

        private void SearchBar_Enter(object sender, EventArgs e)
        {
            if (SearchBar.Text == "Suchbegriff...")
            {
                SearchBar.Text = "";
                SearchBar.ForeColor = Color.Black;
            }
        }

        private void SearchBar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBar.Text))
            {
                SearchBar.Text = "Suchbegriff...";
                SearchBar.ForeColor = Color.Gray;
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            PerformSearchAndDisplayResults();
        }

        private void SearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PerformSearchAndDisplayResults();
                e.SuppressKeyPress = true; // verhindert das "Pling"-Geräusch
            }
        }

        private void NewSearch_Click(object sender, EventArgs e)
        {
            SearchBar.Text = "";
            SearchResults.Items.Clear();
            SearchBar.Focus();
        }


        private void PerformSearchAndDisplayResults()
        {
            string term = SearchBar.Text.Trim();
            if (string.IsNullOrEmpty(term)) return;

            var result = _searchService.PerformSearch(term);

            SearchResults.Items.Clear();
            SearchResults.Items.Add($"Gesamtanzahl Treffer: {result.TotalCount}");

            foreach (var film in result.FilmMatches)
            {
                // Grundinfo
                string line = $"  {film.TitelD} ({film.Jahr})  •  OG: {film.TitelOG}  •  Regie: {film.Director?.Vorname} {film.Director?.Nachname}";

                // Schauspieler im Film ermitteln
                var actorsInFilm = _db.tbl_film_act
                    .Where(fa => fa.Film != null && fa.Film.TitelD == film.TitelD && fa.Film.Jahr == film.Jahr && fa.Act != null)
                    .Select(fa => fa.Act)
                    .ToList();

                if (actorsInFilm.Count > 0)
                {
                    line += "  •  Schauspieler:";

                    foreach (var actor in actorsInFilm)
                    {
                        if (actor == null)
                            continue;

                        // alle Synchronsprecher für diesen Schauspieler in diesem Film
                        var syncsInFilm = _db.tbl_act_sync_film
                            .Where(asf =>
                                asf.Film != null &&
                                asf.Film.TitelD != null &&
                                film.TitelD != null &&
                                asf.Film.TitelD == film.TitelD &&
                                asf.Film.Jahr == film.Jahr &&
                                asf.ActID == actor.ActID)
                            .Select(asf => asf.Sync)
                            .ToList();

                        if (syncsInFilm.Count > 0)
                        {
                            string syncNames = string.Join(", ", syncsInFilm
                                .Where(s => s != null)
                                .Select(s => $"{s!.Vorname ?? string.Empty} {s!.Nachname ?? string.Empty}".Trim()));
                            line += $" {actor.Vorname} {actor.Nachname} (Sprecher: {syncNames})";
                        }
                        else
                        {
                            line += $" {actor.Vorname} {actor.Nachname}";
                        }
                    }
                }

                SearchResults.Items.Add(line);
            }



            SearchResults.Items.Add($"Filme nach Jahr: {result.YearCount}");
            foreach (var y in result.YearMatches)
                SearchResults.Items.Add($"  {y.TitelD} ({y.Jahr})");

            SearchResults.Items.Add($"Regisseure: {result.DirCount}");
            foreach (var dir in result.DirMatches)
            {
                var filmTitles = dir.Filme != null && dir.Filme.Count != 0
                    ? string.Join(", ", dir.Filme.Select(f => f.TitelD))
                    : "keine Filme";

                SearchResults.Items.Add($"  {dir.Vorname} {dir.Nachname} ({filmTitles})");
            }


            SearchResults.Items.Add($"Schauspieler: {result.ActCount}");
            foreach (var a in result.ActMatches)
            {
                var syncs = _db.tbl_act_sync_film
                    .Where(x => x.Act != null && x.Act.Vorname == a.Vorname && x.Act.Nachname == a.Nachname)
                    .Select(x => x.Sync)
                    .Where(s => s != null)
                    .ToList();

                if (syncs.Count != 0)
                {
                    foreach (var s in syncs)
                        SearchResults.Items.Add($"  {a.Vorname} {a.Nachname} (Sprecher: {s!.Vorname ?? string.Empty} {s!.Nachname ?? string.Empty})");
                }
                else
                {
                    SearchResults.Items.Add($"  {a.Vorname} {a.Nachname}");
                }
            }

            SearchResults.Items.Add($"Synchronsprecher: {result.SyncCount}");
            foreach (var s in result.SyncMatches)
            {
                var acts = _db.tbl_act_sync_film
                    .Where(x => x.Sync != null && x.Sync.Vorname == s.Vorname && x.Sync.Nachname == s.Nachname)
                    .Select(x => x.Act)
                    .ToList();

                if (acts.Count != 0)
                {
                    foreach (var a in acts)
                    {
                        if (a != null)
                            SearchResults.Items.Add($"  {s.Vorname} {s.Nachname} (Sprecher von {a.Vorname ?? string.Empty} {a.Nachname ?? string.Empty})");
                    }
                }
                else
                {
                    SearchResults.Items.Add($"  {s.Vorname} {s.Nachname}");
                }
            }

            // wenn keine Treffer, Anfrage zum Anlegen eines neuen Datensatzes
            if (result.TotalCount == 0)
            {
                var response = MessageBox.Show(
                    "Keine passenden Daten gefunden.\nMöchten Sie einen neuen Datensatz anlegen?",
                    "Null Treffer",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (response == DialogResult.Yes)
                {
                    var createForm = new FormDataSetChoice(this.Name); // Konstruktor erhält den Form-Namen
                    createForm.ShowDialog(this);
                }
            }
        }

    }
}
