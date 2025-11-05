namespace WinFormsMovieSearchEngine
{
    partial class FormAddSync
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
            cmbAct = new ComboBox();
            btnCancel = new Button();
            btnSave = new Button();
            txtNachname = new TextBox();
            txtVorname = new TextBox();
            SuspendLayout();
            // 
            // cmbAct
            // 
            cmbAct.BackColor = Color.FromArgb(255, 224, 192);
            cmbAct.Font = new Font("Bahnschrift", 12F);
            cmbAct.FormattingEnabled = true;
            cmbAct.Location = new Point(36, 229);
            cmbAct.Name = "cmbAct";
            cmbAct.Size = new Size(702, 47);
            cmbAct.TabIndex = 3;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DodgerBlue;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Franklin Gothic Demi", 13.875F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(426, 321);
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
            txtNachname.Location = new Point(36, 135);
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
            txtVorname.Location = new Point(36, 46);
            txtVorname.Name = "txtVorname";
            txtVorname.Size = new Size(703, 46);
            txtVorname.TabIndex = 1;
            txtVorname.Text = "Vorname...";
            txtVorname.Enter += txtVorname_Enter;
            // 
            // FormAddSync
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(774, 404);
            Controls.Add(cmbAct);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNachname);
            Controls.Add(txtVorname);
            Name = "FormAddSync";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eingabe Datensatz Synchronsprecher";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbAct;
        private Button btnCancel;
        private Button btnSave;
        private TextBox txtNachname;
        private TextBox txtVorname;
    }
}