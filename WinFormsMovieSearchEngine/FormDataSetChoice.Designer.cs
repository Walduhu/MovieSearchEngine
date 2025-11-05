namespace WinFormsMovieSearchEngine
{
    partial class FormDataSetChoice
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
            button1 = new Button();
            TopLabel = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Franklin Gothic Demi", 13.875F);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(85, 119);
            button1.Name = "button1";
            button1.Size = new Size(397, 59);
            button1.TabIndex = 0;
            button1.Text = "🎬 Film";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnAddFilm_Click;
            // 
            // TopLabel
            // 
            TopLabel.AutoSize = true;
            TopLabel.Font = new Font("Franklin Gothic Demi", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TopLabel.ForeColor = Color.Black;
            TopLabel.Location = new Point(32, 39);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(507, 43);
            TopLabel.TabIndex = 1;
            TopLabel.Text = "Was möchten Sie hinzufügen?";
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Franklin Gothic Demi", 13.875F);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(85, 221);
            button2.Name = "button2";
            button2.Size = new Size(397, 59);
            button2.TabIndex = 2;
            button2.Text = "🎥 Regisseur";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnAddDir_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.DodgerBlue;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Franklin Gothic Demi", 13.875F);
            button3.ForeColor = Color.Black;
            button3.Location = new Point(85, 323);
            button3.Name = "button3";
            button3.Size = new Size(397, 59);
            button3.TabIndex = 3;
            button3.Text = "🎭 Schauspieler";
            button3.UseVisualStyleBackColor = false;
            button3.Click += btnAddAct_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.DodgerBlue;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Franklin Gothic Demi", 13.875F);
            button4.ForeColor = Color.Black;
            button4.Location = new Point(85, 429);
            button4.Name = "button4";
            button4.Size = new Size(397, 59);
            button4.TabIndex = 4;
            button4.Text = "🗣️ Synchronsprecher";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnAddSync_Click;
            // 
            // FormDataSetChoice
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(574, 529);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(TopLabel);
            Controls.Add(button1);
            Name = "FormDataSetChoice";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Auswahl Datensatz";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label TopLabel;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}