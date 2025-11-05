namespace WinFormsMovieSearchEngine
{
    public partial class FormDataSetChoice : Form
    {
        public FormDataSetChoice()
        {
            InitializeComponent();
        }

        private void btnAddFilm_Click(object sender, EventArgs e)
        {
            var f = new FormAddFilm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnAddDir_Click(object sender, EventArgs e)
        {
            var d = new FormAddDir();
            if (d.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnAddAct_Click(object sender, EventArgs e)
        {
            var a = new FormAddAct();
            if (a.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnAddSync_Click(object sender, EventArgs e)
        {
            var s = new FormAddSync();
            if (s.ShowDialog() == DialogResult.OK)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
