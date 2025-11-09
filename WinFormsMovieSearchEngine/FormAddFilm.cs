using MSE_ClassLibrary;

namespace WinFormsMovieSearchEngine
{
    public partial class FormAddFilm : Form
    {
        private readonly MovieDB _db;
        public FormAddFilm()
        {
            InitializeComponent();
            _db = new MovieDB();
            AcceptButton = btnSave;
            ActiveControl = btnCancel;

            var directors = _db.tbl_dir
                .Select(d => new { d.DirID, Name = d.Vorname + " " + d.Nachname })
                .ToList();

            cmbDir.DataSource = directors;
            cmbDir.DisplayMember = "Name";
            cmbDir.ValueMember = "DirID";

            // kein Standardwert
            cmbDir.SelectedIndex = -1;
            cmbDir.Text = "Regisseur eingeben oder wählen...";
            cmbDir.ForeColor = Color.Gray;

            // Standardtext bei Auswahl oder Eingabe schwarz machen

            cmbDir.Enter += (s, e) =>
            {
                if (cmbDir.ForeColor == Color.Gray)
                {
                    cmbDir.Text = "";
                    cmbDir.ForeColor = Color.Black;
                }
            };

            cmbDir.DropDown += (s, e) =>
            {
                if (cmbDir.ForeColor == Color.Gray)
                {
                    cmbDir.Text = "";
                    cmbDir.ForeColor = Color.Black;
                }
            };

            cmbDir.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(cmbDir.Text))
                {
                    cmbDir.Text = "Regisseur eingeben oder wählen...";
                    cmbDir.ForeColor = Color.Gray;
                }
            };


        }

        private void txtTitelD_Enter(object sender, EventArgs e)
        {
            if (txtTitelD.Text == "Deutscher Titel...")
            {
                txtTitelD.Text = "";
                txtTitelD.ForeColor = Color.Black;
            }
        }

        private void txtTitelOG_Enter(object sender, EventArgs e)
        {
            if (txtTitelOG.Text == "Originaltitel...")
            {
                txtTitelOG.Text = "";
                txtTitelOG.ForeColor = Color.Black;
            }
        }

        private void txtJahr_Enter(object sender, EventArgs e)
        {
            if (txtJahr.Text == "Erscheinungsjahr...")
            {
                txtJahr.Text = "";
                txtJahr.ForeColor = Color.Black;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitelD.Text) ||
                string.IsNullOrWhiteSpace(txtTitelOG.Text) ||
                string.IsNullOrWhiteSpace(txtJahr.Text))
            {
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int? directorId = null;

            // prüfen ob etwas ausgewählt wurde
            if (cmbDir.SelectedValue != null && cmbDir.SelectedValue is int id && id > 0)
            {
                directorId = id;
            }
            else
            {
                // User hat Text eingegeben
                string inputDir = cmbDir.Text.Trim();

                if (string.IsNullOrWhiteSpace(inputDir) || inputDir == "Regisseur eingeben oder aus Liste wählen...")
                {
                    MessageBox.Show("Bitte einen Regisseur eingeben oder auswählen!", "Fehler",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // prüfen ob Eingabe bereits existiert
                var existing = _db.tbl_dir
                    .FirstOrDefault(d => (d.Vorname + " " + d.Nachname) == inputDir);

                if (existing != null)
                {
                    directorId = existing.DirID;
                }
                else
                {
                    // Benutzer fragen, ob neuer Regisseur angelegt werden soll
                    var result = MessageBox.Show(
                        $"Regisseur '{inputDir}' existiert nicht.\nJetzt anlegen?",
                        "Neuer Regisseur",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.No)
                    {
                        MessageBox.Show("Speichern abgebrochen.", "Hinweis");
                        return;
                    }

                    // neues Eingabeformular öffnen
                    new FormAddDir(inputDir).ShowDialog();

                    // neuen Regisseur erneut aus DB holen
                    var added = _db.tbl_dir
                        .FirstOrDefault(d => (d.Vorname + " " + d.Nachname) == inputDir);

                    if (added == null)
                    {
                        MessageBox.Show("Regisseur konnte nicht angelegt werden.");
                        return;
                    }

                    directorId = added.DirID;

                    // ComboBox aktualisieren
                    ReloadDirectors();
                    cmbDir.SelectedValue = directorId;
                }
            }

            var newFilm = new Film
            {
                TitelD = txtTitelD.Text,
                TitelOG = txtTitelOG.Text,
                Jahr = int.Parse(txtJahr.Text),
                DirID = directorId.Value
            };

            _db.tbl_film.Add(newFilm);
            _db.SaveChanges();

            MessageBox.Show("Film gespeichert!", "Erfolg");
            Close();
        }
        private void ReloadDirectors()
        {
            var directors = _db.tbl_dir
                .Select(d => new { d.DirID, Name = d.Vorname + " " + d.Nachname })
                .ToList();

            cmbDir.DataSource = directors;
            cmbDir.DisplayMember = "Name";
            cmbDir.ValueMember = "DirID";
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
