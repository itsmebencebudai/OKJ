using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negy_harom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int jegy = int.Parse(textBox1.Text);
            switch (jegy)
            {
                case 1: label2.Text = "Elégtelen"; break;
                case 2: label2.Text = "Elégséges"; break;
                case 3: label2.Text = "Közepes"; break;
                case 4: label2.Text = "Jó"; break;
                case 5: label2.Text = "Jeles"; break;
                default: label2.Text = "Nem osztályzat!";break;            
            }
        }
    }
}
