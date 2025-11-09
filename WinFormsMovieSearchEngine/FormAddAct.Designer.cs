namespace WinFormsMovieSearchEngine
{
    partial class FormAddAct
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
            txtNachname = new TextBox();
            txtVorname = new TextBox();
            cmbFilm = new ComboBox();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DodgerBlue;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Franklin Gothic Demi", 13.875F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(425, 321);
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
            btnSave.Location = new Point(36, 321);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(313, 59);
            btnSave.TabIndex = 5;
            btnSave.Text = "Speichern";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // txtNachname
            // 
            txtNachname.BackColor = Color.FromArgb(255, 224, 192);
            txtNachname.BorderStyle = BorderStyle.FixedSingle;
            txtNachname.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNachname.ForeColor = Color.Gray;
            txtNachname.Location = new Point(36, 130);
            txtNachname.Name = "txtNachname";
            txtNachname.Size = new Size(703, 46);
            txtNachname.TabIndex = 2;
            txtNachname.Text = "Nachname...";
            txtNachname.Enter += txtNachname_Enter;
            // 
            // txtVorname
            // 
            txtVorname.BackColor = Color.FromArgb(255, 224, 192);
            txtVorname.BorderStyle = BorderStyle.FixedSingle;
            txtVorname.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVorname.ForeColor = Color.Gray;
            txtVorname.Location = new Point(36, 41);
            txtVorname.Name = "txtVorname";
            txtVorname.Size = new Size(703, 46);
            txtVorname.TabIndex = 1;
            txtVorname.Text = "Vorname...";
            txtVorname.Enter += txtVorname_Enter;
            // 
            // cmbFilm
            // 
            cmbFilm.BackColor = Color.FromArgb(255, 224, 192);
            cmbFilm.Font = new Font("Bahnschrift", 12F);
            cmbFilm.FormattingEnabled = true;
            cmbFilm.Location = new Point(36, 224);
            cmbFilm.Name = "cmbFilm";
            cmbFilm.Size = new Size(702, 47);
            cmbFilm.TabIndex = 3;
            // 
            // FormAddAct
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(774, 404);
            Controls.Add(cmbFilm);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNachname);
            Controls.Add(txtVorname);
            Name = "FormAddAct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eingabe Datensatz Schauspieler";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancel;
        private Button btnSave;
        private TextBox txtNachname;
        private TextBox txtVorname;
        private ComboBox cmbFilm;
    }
}