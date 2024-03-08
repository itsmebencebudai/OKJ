namespace Futoverseny
{
    public partial class Form1 : Form
    {
        private string[] lines = Array.Empty<string>();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {}

        private void label1_Click(object sender, EventArgs e)
        {
            string debugPath = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(debugPath, "futok.txt");

            try
            {
                lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(';');
                    string name = data[1];
                    listBox1.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a fájl olvasása során: {ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < lines.Length)
            {
                string[] data = lines[selectedIndex].Split(';');
                textBox2.Text = data[0];
                textBox3.Text = data[3];
                textBox4.Text = data[4];
                textBox5.Text = data[2];
            }
        }

        private void eredménylistaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            From2 from2 = new From2(lines);
            from2.Show();
        }
    }
}
