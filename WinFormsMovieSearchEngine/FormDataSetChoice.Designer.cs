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
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Franklin Gothic Demi", 13.875F);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(59, 99);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(328, 37);
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
            TopLabel.Location = new Point(59, 19);
            TopLabel.Margin = new Padding(2, 0, 2, 0);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(328, 30);
            TopLabel.TabIndex = 1;
            TopLabel.Text = "Was möchten Sie hinzufügen?";
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Franklin Gothic Demi", 13.875F);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(59, 157);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(328, 37);
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
            button3.Location = new Point(59, 217);
            button3.Margin = new Padding(2);
            button3.Name = "button3";
            button3.Size = new Size(328, 37);
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
            button4.Location = new Point(59, 276);
            button4.Margin = new Padding(2);
            button4.Name = "button4";
            button4.Size = new Size(328, 37);
            button4.TabIndex = 4;
            button4.Text = "🗣️ Synchronsprecher";
            button4.UseVisualStyleBackColor = false;
            button4.Click += btnAddSync_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Demi", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(14, 49);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(414, 30);
            label1.TabIndex = 5;
            label1.Text = "(Tipp: Zuerst einen Regisseur anlegen)";
            // 
            // FormDataSetChoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(452, 333);
            Controls.Add(label1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(TopLabel);
            Controls.Add(button1);
            Margin = new Padding(2);
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
        private Label label1;
    }
}