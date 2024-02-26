using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Futoverseny
{
    public partial class From2 : Form
    {
        private string[] lines;

        public From2(string[] lines)
        {
            InitializeComponent();
            this.lines = lines;

            // Load sorted lines into the ListBox
            LoadSortedLines();

            // Attach MouseClick event handler to the ListBox
            listBox1.MouseClick += ListBox1_MouseClick;
        }

        private void From2_Load (object sender ,EventArgs e) { }

        private void ListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    // Perform saving operation
                    SaveResultsToFile();
                    MessageBox.Show("Az eredmények sikeresen mentve lettek.", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hiba történt az eredmények mentése során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ListBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Show a message box indicating right-click
                MessageBox.Show("Right mouse button clicked on ListBox.");
            }
        }


        private void LoadSortedLines()
        {
            // Sort lines based on result in descending order
            var sortedLines = lines.OrderByDescending(line => TimeSpan.ParseExact(line.Split(';')[4], @"mm\:ss\.ff", null));

            // Display sorted results in ListBox
            foreach (var line in sortedLines)
            {
                string[] data = line.Split(';');
                listBox1.Items.Add($"{data[1]} - {data[4]}");
            }
        }

        private void SaveResultsToFile()
        {
            var sortedLines = lines.OrderByDescending(line => TimeSpan.ParseExact(line.Split(';')[4], @"mm\:ss\.ff", null));
            File.WriteAllLines("EREDMENYEK.txt", sortedLines);
        }
    }
}
