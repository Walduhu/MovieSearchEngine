using MSE_ClassLibrary;

namespace WinFormsMovieSearchEngine
{
    public partial class FormAddDir : Form
    {
        private readonly MovieDB _db;
        public FormAddDir(string inputDir)
        {
            InitializeComponent();
            _db = new MovieDB();
            AcceptButton = btnSave;
            ActiveControl = btnCancel;
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

            var newDir = new Dir
            {
                Vorname = txtVorname.Text,
                Nachname = txtNachname.Text
            };

            _db.tbl_dir.Add(newDir);
            _db.SaveChanges();

            MessageBox.Show("Regisseur gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
