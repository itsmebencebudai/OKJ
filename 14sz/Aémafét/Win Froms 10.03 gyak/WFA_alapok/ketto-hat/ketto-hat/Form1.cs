using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ketto_hat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.BackColor = Color.Green;
            label1.BackColor = Color.Red;
            label2.BackColor = Color.White;
            label3.BackColor = Color.Gold;
            label4.BackColor = Color.Blue;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Color color = this.BackColor;
            this.BackColor = label1.BackColor;
            label1.BackColor = color;
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Color color = this.BackColor;
            this.BackColor = label2.BackColor;
            label2.BackColor = color;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Color color = this.BackColor;
            this.BackColor = label3.BackColor;
            label3.BackColor = color;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Color color = this.BackColor;
            this.BackColor = label4.BackColor;
            label4.BackColor = color;
        }
    }
}
