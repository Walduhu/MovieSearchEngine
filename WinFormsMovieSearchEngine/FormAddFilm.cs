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
            cmbDir.Text = "Regisseur wählen...";
            cmbDir.ForeColor = Color.Gray;

            // wenn User klickt, Standardtext löschen
            cmbDir.DropDown += (s, e) =>
            {
                if (cmbDir.ForeColor == Color.Gray)
                {
                    cmbDir.Text = "";
                    cmbDir.ForeColor = Color.Black;
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
                MessageBox.Show("Bitte alle Felder ausfüllen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool validSelection = false;

            // prüfen ob SelectedValue gesetzt und in Liste vorhanden ist
            if (cmbDir.SelectedValue != null && cmbDir.SelectedValue is int id && id != 0)
                validSelection = true;

            // prüfen ob Text exakt einem ListItem entspricht
            foreach (var item in cmbDir.Items)
            {
                var type = item.GetType();
                var prop = type.GetProperty("Name");
                if (prop != null && prop.GetValue(item)?.ToString() == cmbDir.Text)
                    validSelection = true;
            }

            if (!validSelection)
            {
                MessageBox.Show("Bitte einen Regisseur aus der Liste wählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDir.Focus();
                return;
            }

            var newFilm = new Film
            {
                TitelD = txtTitelD.Text,
                TitelOG = txtTitelOG.Text,
                Jahr = int.Parse(txtJahr.Text),
                DirID = (int)cmbDir.SelectedValue
            };

            _db.tbl_film.Add(newFilm);
            _db.SaveChanges();

            MessageBox.Show("Film gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
