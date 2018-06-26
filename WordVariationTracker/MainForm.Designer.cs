namespace SongLyricVariationTracker
{
    partial class MainForm
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.selectFileButton = new System.Windows.Forms.Button();
            this.textLabel = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.displayLabel = new System.Windows.Forms.Label();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.commonWordsCheckBox = new System.Windows.Forms.CheckBox();
            this.artistTextBox = new System.Windows.Forms.TextBox();
            this.songTextBox = new System.Windows.Forms.TextBox();
            this.artistLabel = new System.Windows.Forms.Label();
            this.songLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.errorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(12, 88);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(75, 23);
            this.selectFileButton.TabIndex = 0;
            this.selectFileButton.Text = "Select Files";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.selectFileButton_Click);
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(13, 43);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(0, 13);
            this.textLabel.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.Filter = "Text (*.txt) |*.txt";
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.Title = "Open Text Files";
            // 
            // displayLabel
            // 
            this.displayLabel.AutoSize = true;
            this.displayLabel.Location = new System.Drawing.Point(9, 115);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(51, 13);
            this.displayLabel.TabIndex = 2;
            this.displayLabel.Text = "Top Ten:";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(199, 12);
            this.chart.Name = "chart";
            this.chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend";
            series1.Name = "Series";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(300, 300);
            this.chart.TabIndex = 3;
            this.chart.Text = "chart";
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(13, 339);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(223, 13);
            this.percentageLabel.TabIndex = 4;
            this.percentageLabel.Text = "Top Ten words make up X% of all used words";
            // 
            // commonWordsCheckBox
            // 
            this.commonWordsCheckBox.AutoSize = true;
            this.commonWordsCheckBox.Location = new System.Drawing.Point(16, 319);
            this.commonWordsCheckBox.Name = "commonWordsCheckBox";
            this.commonWordsCheckBox.Size = new System.Drawing.Size(144, 17);
            this.commonWordsCheckBox.TabIndex = 5;
            this.commonWordsCheckBox.Text = "Remove Common Words";
            this.commonWordsCheckBox.UseVisualStyleBackColor = true;
            this.commonWordsCheckBox.CheckedChanged += new System.EventHandler(this.commonWordsCheckBox_CheckedChanged);
            // 
            // artistTextBox
            // 
            this.artistTextBox.Location = new System.Drawing.Point(60, 12);
            this.artistTextBox.Name = "artistTextBox";
            this.artistTextBox.Size = new System.Drawing.Size(100, 20);
            this.artistTextBox.TabIndex = 6;
            // 
            // songTextBox
            // 
            this.songTextBox.Location = new System.Drawing.Point(60, 33);
            this.songTextBox.Name = "songTextBox";
            this.songTextBox.Size = new System.Drawing.Size(100, 20);
            this.songTextBox.TabIndex = 7;
            // 
            // artistLabel
            // 
            this.artistLabel.AutoSize = true;
            this.artistLabel.Location = new System.Drawing.Point(12, 15);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(30, 13);
            this.artistLabel.TabIndex = 8;
            this.artistLabel.Text = "Artist";
            // 
            // songLabel
            // 
            this.songLabel.AutoSize = true;
            this.songLabel.Location = new System.Drawing.Point(12, 36);
            this.songLabel.Name = "songLabel";
            this.songLabel.Size = new System.Drawing.Size(32, 13);
            this.songLabel.TabIndex = 9;
            this.songLabel.Text = "Song";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 59);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 10;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(93, 64);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(80, 13);
            this.errorLabel.TabIndex = 11;
            this.errorLabel.Text = "Song not found";
            this.errorLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 364);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.songLabel);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.songTextBox);
            this.Controls.Add(this.artistTextBox);
            this.Controls.Add(this.commonWordsCheckBox);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.textLabel);
            this.Controls.Add(this.selectFileButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Song Lyric Variation Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.CheckBox commonWordsCheckBox;
        private System.Windows.Forms.TextBox artistTextBox;
        private System.Windows.Forms.TextBox songTextBox;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.Label songLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label errorLabel;
    }
}