namespace WordVariationTracker
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series();
            selectFileButton = new System.Windows.Forms.Button();
            textLabel = new System.Windows.Forms.Label();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            displayLabel = new System.Windows.Forms.Label();
            chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            percentageLabel = new System.Windows.Forms.Label();
            commonWordsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(chart)).BeginInit();
            SuspendLayout();
            // 
            // selectFileButton
            // 
            selectFileButton.Location = new System.Drawing.Point(12, 12);
            selectFileButton.Name = "selectFileButton";
            selectFileButton.Size = new System.Drawing.Size(75, 23);
            selectFileButton.TabIndex = 0;
            selectFileButton.Text = "Select Files";
            selectFileButton.UseVisualStyleBackColor = true;
            selectFileButton.Click += new System.EventHandler(selectFileButton_Click);
            // 
            // textLabel
            // 
            textLabel.AutoSize = true;
            textLabel.Location = new System.Drawing.Point(13, 43);
            textLabel.Name = "textLabel";
            textLabel.Size = new System.Drawing.Size(0, 13);
            textLabel.TabIndex = 1;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.Filter = "Text (*.txt) |*.txt";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Open Text Files";
            // 
            // displayLabel
            // 
            displayLabel.AutoSize = true;
            displayLabel.Location = new System.Drawing.Point(12, 61);
            displayLabel.Name = "displayLabel";
            displayLabel.Size = new System.Drawing.Size(51, 13);
            displayLabel.TabIndex = 2;
            displayLabel.Text = "Top Ten:";
            // 
            // chart
            // 
            chartArea.Name = "ChartArea";
            chart.ChartAreas.Add(chartArea);
            legend.Name = "Legend";
            chart.Legends.Add(legend);
            chart.Location = new System.Drawing.Point(199, 12);
            chart.Name = "chart";
            chart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series.ChartArea = "ChartArea";
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series.Legend = "Legend";
            series.Name = "Series";
            chart.Series.Add(series);
            chart.Size = new System.Drawing.Size(300, 300);
            chart.TabIndex = 3;
            chart.Text = "chart";
            // 
            // percentageLabel
            // 
            percentageLabel.AutoSize = true;
            percentageLabel.Location = new System.Drawing.Point(13, 339);
            percentageLabel.Name = "percentageLabel";
            percentageLabel.Size = new System.Drawing.Size(223, 13);
            percentageLabel.TabIndex = 4;
            percentageLabel.Text = "Top Ten words make up X% of all used words";
            // 
            // commonWordsCheckBox
            // 
            commonWordsCheckBox.AutoSize = true;
            commonWordsCheckBox.Location = new System.Drawing.Point(12, 41);
            commonWordsCheckBox.Name = "commonWordsCheckBox";
            commonWordsCheckBox.Size = new System.Drawing.Size(144, 17);
            commonWordsCheckBox.TabIndex = 5;
            commonWordsCheckBox.Text = "Remove Common Words";
            commonWordsCheckBox.UseVisualStyleBackColor = true;
            commonWordsCheckBox.CheckedChanged += new System.EventHandler(commonWordsCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(511, 364);
            Controls.Add(commonWordsCheckBox);
            Controls.Add(percentageLabel);
            Controls.Add(chart);
            Controls.Add(displayLabel);
            Controls.Add(textLabel);
            Controls.Add(selectFileButton);
            Name = "MainForm";
            Text = "Word Variation Tracker";
            Load += new System.EventHandler(MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(chart)).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label displayLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.CheckBox commonWordsCheckBox;
    }
}