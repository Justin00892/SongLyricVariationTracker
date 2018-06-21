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
            "my",
            "them",
            "theirs"
        };
        #endregion
        public MainForm()
        {
            LyricFinder("Chance the Rapper", "Favorite Song");
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
                var topTen = wordList.Where(w => !_removableWords.Contains(w.Key)).Take(10);

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

                var topTenCount = (decimal) 0;
                foreach (var word in topTen)
                {
                    topTenCount += word.Value;
                }

                var totalCount = (decimal)_wordCount.Values.Sum();
                var percentage = Math.Round(topTenCount / totalCount * 100,2);

                percentageLabel.Text = "Top Ten words make up " +percentage + "% of all used words";
            }
        }

        private List<KeyValuePair<string,int>> ProcessList(IEnumerable<string> list)
        {
            foreach (var word in list)
            {
                
                var count = 1;
                if (_wordCount.ContainsKey(word))
                    count = _wordCount[word] + 1;
                _wordCount[word] = count;

            }

            return _wordCount.OrderByDescending(kvp => kvp.Value).ToList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            chart.Hide();
        }


        private void LyricFinder(string artist, string song) 
        {
            artist = artist.Replace(" ", "%20");
            song = song.Replace(" ", "%20");
            System.Net.WebClient wc = new System.Net.WebClient();
            string url = "http://lyric-api.herokuapp.com/api/find/" + artist + "/" + song;
            string webData = wc.DownloadString(url);
            string thing = webData.Split(':')[1];
            int length = thing.Length-1;
            thing = thing.Substring(1, thing.Length-8);
        }
    }
}
