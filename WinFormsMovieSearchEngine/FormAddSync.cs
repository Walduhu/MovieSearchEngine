using MSE_ClassLibrary;
using System.Data;

namespace WinFormsMovieSearchEngine
{
    public partial class FormAddSync : Form
    {
        private readonly MovieDB _db;
        public FormAddSync()
        {
            InitializeComponent();
            _db = new MovieDB();
            AcceptButton = btnSave;
            ActiveControl = btnCancel;

            var acts = _db.tbl_act
                .Select(a => new { a.ActID, Name = a.Vorname + " " + a.Nachname })
                .ToList();

            cmbAct.DataSource = acts;
            cmbAct.DisplayMember = "Name";
            cmbAct.ValueMember = "ActID";

            // kein Standardwert
            cmbAct.SelectedIndex = -1;
            cmbAct.Text = "Für welchen Schauspieler?";
            cmbAct.ForeColor = Color.Gray;

            // wenn User klickt, Standardtext löschen
            cmbAct.DropDown += (s, e) =>
            {
                if (cmbAct.ForeColor == Color.Gray)
                {
                    cmbAct.Text = "";
                    cmbAct.ForeColor = Color.Black;
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

            bool validSelection = false;

            // prüfen ob SelectedValue gesetzt und in Liste vorhanden ist
            if (cmbAct.SelectedValue != null && cmbAct.SelectedValue is int id && id != 0)
                validSelection = true;

            // prüfen ob Text exakt einem ListItem entspricht
            foreach (var item in cmbAct.Items)
            {
                var type = item.GetType();
                var prop = type.GetProperty("Name");
                if (prop != null && prop.GetValue(item)?.ToString() == cmbAct.Text)
                    validSelection = true;
            }

            if (!validSelection)
            {
                MessageBox.Show("Bitte einen Schauspieler aus der Liste wählen!", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAct.Focus();
                return;
            }

            var selectedAct = (int)cmbAct.SelectedValue;

            var newSync = new Sync
            {
                Vorname = txtVorname.Text,
                Nachname = txtNachname.Text
            };

            // Act-Verknüpfung
            newSync.Act_Syncs.Add(new Act_Sync
            {
                ActID = selectedAct
            });

            _db.tbl_sync.Add(newSync);
            _db.SaveChanges();

            MessageBox.Show("Synchronsprecher gespeichert!", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
