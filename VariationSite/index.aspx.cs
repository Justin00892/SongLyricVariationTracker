using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : Page
{
    private readonly SortedDictionary<string, int> _wordCount = new SortedDictionary<string, int>();
    #region removableWordsList
    private readonly List<string> _removableWords = new List<string>
    {
        "a","an","the","of","with","at","from","into",
        "for","in","on","by","but","to","off","we","you",
        "me","i","he","she","it","they","and","all","our",
        "his","hers","their","my","them","theirs","her",
        "too","this","that","those"
    };
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        var displayTableHeader = new TableHeaderCell {Text = "Top Ten:"};
        var displayTableHeaderRow = new TableHeaderRow();
        displayTableHeaderRow.Cells.Add(displayTableHeader);
        displayTable.Rows.Add(displayTableHeaderRow);
    }

    protected void uploadButton_Click(object sender, EventArgs e)
    {
        var fileUploaded = false;
        foreach (var file in fileUpload.PostedFiles)
        {
            if (Path.GetExtension(file.FileName).ToLower() != ".txt") continue;
            string text;
            using (var reader = new StreamReader(file.InputStream))
            {
                text = reader.ReadToEnd();
            }
            ProcessList(text);
            fileUploaded = true;
        }
        if (fileUploaded)
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

    private void UpdateDisplay()
    {
        var wordList = _wordCount.OrderByDescending(kvp => kvp.Value);
        var topTen = commonWordsCheckbox.Checked
            ? wordList.Where(w => !_removableWords.Contains(w.Key)).Take(10).ToList()
            : wordList.Take(10).ToList();

        foreach (var pair in topTen)
        {
            var cell = new TableCell {Text = pair.Key + ": " + pair.Value};
            var row = new TableRow();
            row.Cells.Add(cell);
            displayTable.Rows.Add(row);
        }

        var topTenCount = topTen.Aggregate((decimal)0, (current, word) => current + word.Value);
        var totalCount = (decimal)_wordCount.Values.Sum();
        var percentage = Math.Round(topTenCount / totalCount * 100, 2);

        percentageLabel.Text = @"Top Ten words make up " + percentage + @"% of all used words";
    }
}