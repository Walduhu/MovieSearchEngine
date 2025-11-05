using MSE_ClassLibrary;

namespace WinFormsMovieSearchEngine
{
    public partial class FormAddAct : Form
    {
        private readonly MovieDB _db;
        public FormAddAct()
        {
            InitializeComponent();
            _db = new MovieDB();
            AcceptButton = btnSave;
            ActiveControl = btnCancel;

            var films = _db.tbl_film
                .Select(f => new { f.FilmID, Titel = f.TitelD + " (OG: " + f.TitelOG + ")" })
                .ToList();

            cmbFilm.DataSource = films;
            cmbFilm.DisplayMember = "Titel";
            cmbFilm.ValueMember = "FilmID";

            // kein Standardwert
            cmbFilm.SelectedIndex = -1;
            cmbFilm.Text = "Film wählen...";
            cmbFilm.ForeColor = Color.Gray;

            // wenn User klickt, Standardtext löschen
            cmbFilm.DropDown += (s, e) =>
            {
                if (cmbFilm.ForeColor == Color.Gray)
                {
                    cmbFilm.Text = "";
                    cmbFilm.ForeColor = Color.Black;
                }
            };
        }

        private void txtVorname_Enter(object sender, EventArgs e)
        {
            if (txtVorname.Text == "Vorname...")
            {
                txtVorname.Text = "";
                txtVorname.ForeColor = Color.Black;
            }
        }

        private void txtNachname_Enter(object sender, EventArgs e)
        {
            if (txtNachname.Text == "Nachname...")
            {
                txtNachname.Text = "";
                txtNachname.ForeColor = Color.Black;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVorname.Text) ||
                string.IsNullOrWhiteSpace(txtNachname.Text))
            {
                MessageBox.Show("Bitte beide Felder ausfüllen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbFilm.SelectedValue == null || (int)cmbFilm.SelectedValue == 0)
            {
                MessageBox.Show("Bitte einen Film auswählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedFilm = (int)cmbFilm.SelectedValue;

            var newAct = new Act
            {
                Vorname = txtVorname.Text,
                Nachname = txtNachname.Text
            };

            // Film-Verknüpfung
            newAct.Film_Acts.Add(new Film_Act
            {
                FilmID = selectedFilm
            });

            _db.tbl_act.Add(newAct);
            _db.SaveChanges();

            MessageBox.Show("Schauspieler gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
