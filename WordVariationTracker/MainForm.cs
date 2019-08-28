using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Genius;
using Genius.Models;
using Newtonsoft.Json;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace SongLyricVariationTracker
{
    public partial class MainForm : Form
    {
        private readonly SortedDictionary<string, int> _wordCount = new SortedDictionary<string, int>();
        #region removableWordsList
        private readonly List<string> _removableWords = new List<string>
        {
            "a","an","the","of","with","at","from","into",
            "for","in","on","by","but","to","off","we","you",
            "me","i","he","she","it","they","and","all","our",
            "his","hers","their","my","them","theirs","her",
            "too","this","that","those","i'm","i'll","we're",
            "you'll","your","you're","these","him"
        };
        #endregion

        private string _token = "AFxmKN0ghb_XwmDYl9WIuzDj5H4jIWy1IglGInW6wQS3_wKyzSp-7tBc5Ic_2nkQ";

        public MainForm()
        {
            InitializeComponent();            
        }

        private void ProcessList(string text)
        {
            text = text.ToLower();
            text = Regex.Replace(text, @"\t|\n|\r|\\n|\\t|\\r|\\|\[.*\]", " ");
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
                //if (!pair.Key.Equals("Other Words"))
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
            searchButton.Enabled = false;
            //LyricFinder(artistName,song);           
            LyricFinder2(artist,song);           
        }

        private async void LyricFinder2(string artistName, string songName)
        {
            progressBar.Visible = true;
            //Search for artistName
            artistName = artistName.Replace(" ", "%20");
            songName = songName.Replace(" ", "%20");

            try
            {
                var geniusClient = new GeniusClient(_token);
                var search = await geniusClient.SearchClient.Search(TextFormat.Dom, artistName + "%20" + songName);
                if (search.Response.Count == 0) return;
                var result = JsonConvert.DeserializeObject<Result>(search.Response[0].Result.ToString());

                if (string.IsNullOrEmpty(songName))
                {
                    var songs = new List<Song>();
                    HttpResponse<List<Song>> response;
                    var page = 1;
                    do
                    {
                        response = await geniusClient.ArtistsClient.GetSongsByArtist(TextFormat.Dom,
                            result.primary_artist.id + "", "", "20", page + "");
                        songs.AddRange(response.Response);
                        page++;
                    } while (response.Response.Any());

                    progressBar.Maximum = songs.Count;
                    foreach (var song in songs)
                    {
                        var lyrics = await Task.Factory.StartNew(() => GetLyrics(song.ApiPath));
                        progressBar.PerformStep();
                        ProcessList(lyrics);
                        UpdateDisplay();
                    }
                }
                else
                {
                    var lyrics = await Task.Factory.StartNew(() => GetLyrics(result.api_path));
                    ProcessList(lyrics);
                    UpdateDisplay();
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                errorLabel.Visible = true;
            }
            finally
            {
                progressBar.Visible = false;
                searchButton.Enabled = true;
            }
        }

        private string GetLyrics(string path)
        {
            var url = "https://genius.com" + path;
            var lyrics = "";
            using (var client = new WebClient())
            {
                var htmlString = client.DownloadString(url);
                var html = new HtmlDocument();
                html.LoadHtml(htmlString);
                var lyricsHtml = html.DocumentNode.SelectSingleNode("//body").Descendants()
                    .FirstOrDefault(d => d.HasClass("lyrics"))?.SelectSingleNode("//p");
                if (lyricsHtml != null) lyrics = lyricsHtml.InnerText;
            }
            return lyrics;
        }
    }
}
