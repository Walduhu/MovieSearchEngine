namespace WinFormsMovieSearchEngine
{
    partial class MSEForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSEForm));
            SearchBar = new TextBox();
            Search = new Button();
            NewSearch = new Button();
            TopLabel = new Label();
            SearchResults = new ListBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // SearchBar
            // 
            SearchBar.BackColor = Color.FromArgb(255, 224, 192);
            SearchBar.BorderStyle = BorderStyle.FixedSingle;
            SearchBar.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SearchBar.ForeColor = Color.Gray;
            SearchBar.Location = new Point(34, 124);
            SearchBar.Name = "SearchBar";
            SearchBar.Size = new Size(1828, 46);
            SearchBar.TabIndex = 0;
            SearchBar.Text = "Suchbegriff...";
            SearchBar.MouseClick += SearchBar_Enter;
            SearchBar.Enter += SearchBar_Enter;
            SearchBar.KeyDown += SearchBar_KeyDown;
            SearchBar.Leave += SearchBar_Leave;
            // 
            // Search
            // 
            Search.BackColor = Color.DodgerBlue;
            Search.FlatAppearance.BorderColor = Color.Black;
            Search.FlatStyle = FlatStyle.Flat;
            Search.Font = new Font("Franklin Gothic Demi", 13.875F);
            Search.Location = new Point(226, 209);
            Search.Name = "Search";
            Search.Size = new Size(600, 75);
            Search.TabIndex = 1;
            Search.Text = "🔎 Suche";
            Search.UseVisualStyleBackColor = false;
            Search.Click += Search_Click;
            // 
            // NewSearch
            // 
            NewSearch.BackColor = Color.DodgerBlue;
            NewSearch.FlatAppearance.BorderColor = Color.Black;
            NewSearch.FlatStyle = FlatStyle.Flat;
            NewSearch.Font = new Font("Franklin Gothic Demi", 13.875F);
            NewSearch.Location = new Point(1048, 209);
            NewSearch.Name = "NewSearch";
            NewSearch.Size = new Size(600, 75);
            NewSearch.TabIndex = 2;
            NewSearch.Text = "↻ Erneute Suche";
            NewSearch.UseVisualStyleBackColor = false;
            NewSearch.Click += NewSearch_Click;
            // 
            // TopLabel
            // 
            TopLabel.AutoSize = true;
            TopLabel.Font = new Font("Franklin Gothic Demi", 13.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TopLabel.ForeColor = Color.Black;
            TopLabel.Location = new Point(34, 54);
            TopLabel.Name = "TopLabel";
            TopLabel.Size = new Size(1259, 43);
            TopLabel.TabIndex = 0;
            TopLabel.Text = "Geben Sie einen Film, einen Regisseur, einen Schauspieler oder ein Jahr ein:";
            // 
            // SearchResults
            // 
            SearchResults.BackColor = Color.FromArgb(255, 224, 192);
            SearchResults.BorderStyle = BorderStyle.FixedSingle;
            SearchResults.Font = new Font("Bahnschrift", 12F);
            SearchResults.HorizontalScrollbar = true;
            SearchResults.ItemHeight = 39;
            SearchResults.Location = new Point(34, 326);
            SearchResults.Name = "SearchResults";
            SearchResults.Size = new Size(1828, 626);
            SearchResults.TabIndex = 3;
            SearchResults.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Franklin Gothic Demi", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(1528, 966);
            label1.Name = "label1";
            label1.Size = new Size(334, 34);
            label1.TabIndex = 4;
            label1.Text = "© 2025 Benjamin Schwarz";
            // 
            // MSEForm
            // 
            AutoScaleDimensions = new SizeF(15F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1894, 1009);
            Controls.Add(label1);
            Controls.Add(SearchResults);
            Controls.Add(TopLabel);
            Controls.Add(NewSearch);
            Controls.Add(Search);
            Controls.Add(SearchBar);
            Font = new Font("Cambria", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "MSEForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Movie Search Engine";
            TransparencyKey = Color.White;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchBar;
        private Button Search;
        private Button NewSearch;
        private Label TopLabel;
        private ListBox SearchResults;
        private Label label1;
    }
}
