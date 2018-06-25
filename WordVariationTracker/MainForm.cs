using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Net;

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
            foreach (var file in openFileDialog.FileNames)
            {
                string text;
                using (var reader = new StreamReader(file))
                {
                    text = reader.ReadToEnd();
                    reader.Close();
                }
                ProcessList(text);
            }
            UpdateDisplay();
        }

        private void ProcessList(string text)
        {
            text = text.ToLower();
            text = Regex.Replace(text, @"\t|\n|\r|\\n|\\t|\\r|\\", " ");
            var list = text.Split(" ,!.?:;\"()[]{}*".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

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

        private void LyricFinder(string artist, string song)
        {
            var list = new List<string>();
            artist = artist.Replace(" ", "%20");
            song = song.Replace(" ", "%20");
            var wc = new WebClient();
            var url = "http://lyric-api.herokuapp.com/api/find/" + artist + "/" + song;
            try
            {
                var webData = wc.DownloadString(url);
                var thing = webData.Split(':')[1];
                thing = thing.Replace(" - ", " ");
                ProcessList(thing);
                UpdateDisplay();
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                errorLabel.Visible = true;
            }         
        }

        private void UpdateDisplay()
        {
            errorLabel.Visible = false;
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

        private void searchButton_Click(object sender, EventArgs e)
        {
            var artist = artistTextBox.Text;
            var song = songTextBox.Text;
            LyricFinder(artist,song);
        }
    }
}
