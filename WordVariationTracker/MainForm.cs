using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordVariationTracker
{
    public partial class MainForm : Form
    {
        private SortedDictionary<string, int> _wordCount = new SortedDictionary<string, int>();
        public MainForm()
        {
            InitializeComponent();
            InitializeOpenFileDialog();
        }

        private void InitializeOpenFileDialog()
        {
            openFileDialog.Filter =
                "Text (*.txt) |*.txt";

            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Open Text Files";
        }
        private void selectFileButton_Click(object sender, EventArgs e)
        {
            var dr = openFileDialog.ShowDialog();
            if (dr != DialogResult.OK) return;
            foreach (var file in openFileDialog.FileNames)
            {
                using (var reader = new StreamReader(file))
                {
                    while (!reader.EndOfStream)
                    {
                        var text = reader.ReadToEnd().ToLower();
                        var list = text.Split(" ,!.?:;'\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        ProcessList(list);
                        displayLabel.Text = "Word Count:\n";
                        foreach (var pair in _wordCount)
                        {
                            displayLabel.Text += pair.Key + ": " + pair.Value + "\n";
                        }
                    }
                }
            }
        }

        private void ProcessList(string[] list)
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

        }
    }
}
