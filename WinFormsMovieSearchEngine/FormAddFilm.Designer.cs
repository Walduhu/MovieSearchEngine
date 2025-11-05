namespace WinFormsMovieSearchEngine
{
    partial class FormAddFilm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnCancel = new Button();
            btnSave = new Button();
            txtTitelOG = new TextBox();
            txtTitelD = new TextBox();
            txtJahr = new TextBox();
            cmbDir = new ComboBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DodgerBlue;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Franklin Gothic Demi", 13.875F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(428, 407);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(313, 59);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Franklin Gothic Demi", 13.875F);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(39, 407);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(313, 59);
            btnSave.TabIndex = 5;
            btnSave.Text = "Speichern";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtTitelOG
            // 
            txtTitelOG.BackColor = Color.FromArgb(255, 224, 192);
            txtTitelOG.BorderStyle = BorderStyle.FixedSingle;
            txtTitelOG.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitelOG.ForeColor = Color.Gray;
            txtTitelOG.Location = new Point(38, 128);
            txtTitelOG.Name = "txtTitelOG";
            txtTitelOG.Size = new Size(703, 46);
            txtTitelOG.TabIndex = 2;
            txtTitelOG.Text = "Originaltitel...";
            txtTitelOG.Enter += txtTitelOG_Enter;
            // 
            // txtTitelD
            // 
            txtTitelD.BackColor = Color.FromArgb(255, 224, 192);
            txtTitelD.BorderStyle = BorderStyle.FixedSingle;
            txtTitelD.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitelD.ForeColor = Color.Gray;
            txtTitelD.Location = new Point(38, 39);
            txtTitelD.Name = "txtTitelD";
            txtTitelD.Size = new Size(703, 46);
            txtTitelD.TabIndex = 1;
            txtTitelD.Text = "Deutscher Titel...";
            txtTitelD.Enter += txtTitelD_Enter;
            // 
            // txtJahr
            // 
            txtJahr.BackColor = Color.FromArgb(255, 224, 192);
            txtJahr.BorderStyle = BorderStyle.FixedSingle;
            txtJahr.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtJahr.ForeColor = Color.Gray;
            txtJahr.Location = new Point(38, 219);
            txtJahr.Name = "txtJahr";
            txtJahr.Size = new Size(703, 46);
            txtJahr.TabIndex = 3;
            txtJahr.Text = "Erscheinungsjahr...";
            txtJahr.Enter += txtJahr_Enter;
            // 
            // cmbDir
            // 
            cmbDir.BackColor = Color.FromArgb(255, 224, 192);
            cmbDir.Font = new Font("Bahnschrift", 12F);
            cmbDir.FormattingEnabled = true;
            cmbDir.Location = new Point(39, 311);
            cmbDir.Name = "cmbDir";
            cmbDir.Size = new Size(702, 47);
            cmbDir.TabIndex = 4;
            // 
            // FormAddFilm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(774, 490);
            Controls.Add(cmbDir);
            Controls.Add(txtJahr);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtTitelOG);
            Controls.Add(txtTitelD);
            Name = "FormAddFilm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eingabe Datensatz Film";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private TextBox txtTitelOG;
        private TextBox txtTitelD;
        private TextBox txtJahr;
        private ComboBox cmbDir;
    }
}