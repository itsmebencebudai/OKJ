using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harom_harom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s = Convert.ToString(textBox1.Text);
            listBox1.Items.Add(s);
            textBox1.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
