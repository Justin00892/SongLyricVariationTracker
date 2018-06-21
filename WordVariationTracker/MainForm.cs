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
        private readonly List<string> _removableWords = new List<string>()
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
            "I",
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
            "my"
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
            foreach (var file in openFileDialog.FileNames)
            {
                var text = "";
                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        text = reader.ReadToEnd().ToLower();
                    }
                    reader.Close();
                }

                text = Regex.Replace(text, @"\t|\n|\r", " ");
                var list = text.Split(" ,!.?:;\"()[]{}*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var wordList = ProcessList(list);
                var topTen = wordList.GetRange(0, 10);
                wordList.RemoveRange(0,10);
                var count = 0;
                foreach (var word in wordList)
                {
                    count += word.Value;
                }
                topTen.Add(new KeyValuePair<string, int>("Other Words",count));

                displayLabel.Text = "Top Ten:\n";
                chart.Series[0].Points.Clear();
                foreach (var pair in topTen)
                {
                    if(!pair.Key.Equals("Other Words"))
                        displayLabel.Text += pair.Key + @": " + pair.Value + "\n";
                    chart.Series[0].Points.AddXY(pair.Key, pair.Value);
                }
                chart.Legends[0].Enabled = true;
                chart.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart.Series[0]["PieLabelStyle"] = "Disabled";
                chart.Show();
                    
                
            }
        }

        private List<KeyValuePair<string,int>> ProcessList(IEnumerable<string> list)
        {
            foreach (var word in list)
            {
                
                var count = 1;
                if (_wordCount.ContainsKey(word) && !_removableWords.Contains(word))
                    count = _wordCount[word] + 1;
                _wordCount[word] = count;
            }

            return _wordCount.OrderByDescending(kvp => kvp.Value).ToList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chart.Hide();
        }
    }
}
