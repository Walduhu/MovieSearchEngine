namespace WinFormsMovieSearchEngine
{
    partial class FormAddDir
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
            txtVorname = new TextBox();
            txtNachname = new TextBox();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtVorname
            // 
            txtVorname.BackColor = Color.FromArgb(255, 224, 192);
            txtVorname.BorderStyle = BorderStyle.FixedSingle;
            txtVorname.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtVorname.ForeColor = Color.Gray;
            txtVorname.Location = new Point(39, 48);
            txtVorname.Name = "txtVorname";
            txtVorname.Size = new Size(703, 46);
            txtVorname.TabIndex = 1;
            txtVorname.Text = "Vorname...";
            txtVorname.Enter += txtVorname_Enter;
            // 
            // txtNachname
            // 
            txtNachname.BackColor = Color.FromArgb(255, 224, 192);
            txtNachname.BorderStyle = BorderStyle.FixedSingle;
            txtNachname.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNachname.ForeColor = Color.Gray;
            txtNachname.Location = new Point(39, 137);
            txtNachname.Name = "txtNachname";
            txtNachname.Size = new Size(703, 46);
            txtNachname.TabIndex = 2;
            txtNachname.Text = "Nachname...";
            txtNachname.Enter += txtNachname_Enter;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.DodgerBlue;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Franklin Gothic Demi", 13.875F);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(39, 233);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(313, 59);
            btnSave.TabIndex = 3;
            btnSave.Text = "Speichern";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DodgerBlue;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Franklin Gothic Demi", 13.875F);
            btnCancel.ForeColor = Color.Black;
            btnCancel.Location = new Point(429, 233);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(313, 59);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Abbrechen";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormAddDir
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(774, 314);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtNachname);
            Controls.Add(txtVorname);
            Name = "FormAddDir";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eingabe Datensatz Regisseur";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtVorname;
        private TextBox txtNachname;
        private Button btnSave;
        private Button btnCancel;
    }
}