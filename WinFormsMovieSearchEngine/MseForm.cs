using MSE_ClassLibrary;

namespace WinFormsMovieSearchEngine
{
    public partial class MseForm : Form
    {
        private SearchService _searchService;
        private readonly MovieDB _db;

        public MseForm(SearchService searchService, MovieDB db)
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
                string line = $" {film.TitelD} ({film.Jahr}) | Regie: {film.Director?.Vorname} {film.Director?.Nachname}";

                var actors = film.Film_Acts.Select(fa => fa.Actor).ToList();
                if (actors.Count != 0)
                {
                    line += ", Schauspieler:";
                    foreach (var actor in actors)
                    {
                        var syncs = actor.Act_Syncs.Select(s => s.Sync);
                        string syncNames = string.Join(", ", syncs.Select(s => $"{s.Vorname} {s.Nachname}"));
                        line += $" {actor.Vorname} {actor.Nachname}";
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
                var syncs = _db.tbl_act_sync
                    .Where(x => x.ActID == a.ActID)
                    .Select(x => x.Sync)
                    .ToList();

                if (syncs.Count != 0)
                {
                    foreach (var s in syncs)
                        SearchResults.Items.Add($"  {a.Vorname} {a.Nachname} (Sprecher: {s.Vorname} {s.Nachname})");
                }
                else
                {
                    SearchResults.Items.Add($"  {a.Vorname} {a.Nachname}");
                }
            }

            SearchResults.Items.Add($"Synchronsprecher: {result.SyncCount}");
            foreach (var s in result.SyncMatches)
            {
                var acts = _db.tbl_act_sync
                    .Where(x => x.SyncID == s.SyncID)
                    .Select(x => x.Actor)
                    .ToList();

                if (acts.Count != 0)
                {
                    foreach (var a in acts)
                        SearchResults.Items.Add($"  {s.Vorname} {s.Nachname} (Sprecher von {a.Vorname} {a.Nachname})");
                }
                else
                {
                    SearchResults.Items.Add($"  {s.Vorname} {s.Nachname}");
                }
            }

        }

    }
}
