using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harom_ot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double A_oldal = double.Parse(Aoldal.Text);
            double B_oldal = double.Parse(Boldal.Text);
            double K = 2* B_oldal + 2* A_oldal;
            double T = A_oldal * B_oldal;
            listBox1.Items.Add($"A = {A_oldal}, B = {B_oldal}, K = {K}, T = {T}");
            Aoldal.Text = string.Empty;
            Boldal.Text = string.Empty;
        }
    }
}
