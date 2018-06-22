using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WordVariationTracker
{
    public partial class MainForm : Form
    {
        private readonly SortedDictionary<string, int> _wordCount = new SortedDictionary<string, int>();
        #region removableWordsList
        private readonly List<string> _removableWords = new List<string>
        {
            "a",
            "an",
            "the",
            "of",
            "with",
            "at",
            "from",
            "into",
            "for",
            "in",
            "on",
            "by",
            "but",
            "to",
            "off",
            "we",
            "you",
            "me",
            "i",
            "he",
            "she",
            "it",
            "they",
            "and",
            "all",
            "our",
            "his",
            "hers",
            "their",
            "my",
            "them",
            "theirs",
            "her",
            "too",
            "this",
            "that",
            "those"

        };
        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void selectFileButton_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog.ShowDialog();
            if (dr != DialogResult.OK) return;
            var list = new List<string>();
            foreach (var file in openFileDialog.FileNames)
            {
                string text;
                using (var reader = new StreamReader(file))
                {
                    text = reader.ReadToEnd().ToLower();
                    reader.Close();
                }

                text = Regex.Replace(text, @"\t|\n|\r", " ");
                list.AddRange(text.Split(" ,!.?:;\"()[]{}*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList());
            }
            ProcessList(list);

            UpdateDisplay();
        }

        private void ProcessList(IEnumerable<string> list)
        {
            foreach (var word in list)
            {               
                var count = 1;
                if (_wordCount.ContainsKey(word))
                    count = _wordCount[word] + 1;
                _wordCount[word] = count;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chart.Hide();
        }

        private void UpdateDisplay()
        {
            var wordList = _wordCount.OrderByDescending(kvp => kvp.Value);
            var topTen = commonWordsCheckBox.Checked
                ? wordList.Where(w => !_removableWords.Contains(w.Key)).Take(10).ToList()
                : wordList.Take(10).ToList();

            displayLabel.Text = @"Top Ten:" + Environment.NewLine;
            chart.Series[0].Points.Clear();
            foreach (var pair in topTen)
            {
                if (!pair.Key.Equals("Other Words"))
                    displayLabel.Text += pair.Key + @": " + pair.Value + Environment.NewLine;
                chart.Series[0].Points.AddXY(pair.Key, pair.Value);
            }
            chart.Legends[0].Enabled = true;
            chart.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart.Series[0]["PieLabelStyle"] = "Disabled";
            chart.Show();

            var topTenCount = topTen.Aggregate((decimal)0, (current, word) => current + word.Value);

            var totalCount = (decimal)_wordCount.Values.Sum();
            var percentage = Math.Round(topTenCount / totalCount * 100, 2);

            percentageLabel.Text = @"Top Ten words make up " + percentage + @"% of all used words";
        }

        private void commonWordsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateDisplay();
        }
    }
}
