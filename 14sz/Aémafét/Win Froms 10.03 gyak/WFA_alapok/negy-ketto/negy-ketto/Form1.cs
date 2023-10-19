using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negy_ketto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ah = int.Parse(textBox1.Text);
            int fh = int.Parse(textBox2.Text);
            int szam = int.Parse(textBox3.Text);
            if (ah <= fh)
            {
                if (szam >= ah && szam <= fh)
                {
                    label4.Text = "Benne van az intervallumban.";
                }
                else
                {
                    label4.Text = "Nincsen benne az intervallumban";
                }
            }
            else
            {
                label4.Text = "Ez nem intervallum!";
            }

        }
    }
}
