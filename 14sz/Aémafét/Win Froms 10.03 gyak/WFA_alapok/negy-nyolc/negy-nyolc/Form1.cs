using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negy_nyolc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int evszam = int.Parse(textBox1.Text);
            bool szokoev = (evszam % 4 == 0 && evszam % 100 != 0) || (evszam % 400 == 0);
            label2.Text = Convert.ToString(szokoev);
        }
    }
}
