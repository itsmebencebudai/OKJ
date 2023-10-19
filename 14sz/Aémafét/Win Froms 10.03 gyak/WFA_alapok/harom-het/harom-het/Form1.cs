using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harom_het
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Math.Sqrt(a * a + b * b)
            double a = double.Parse( textBox1.Text);
            double b = double.Parse( textBox2.Text);
            textBox3.Text = Convert.ToString (Math.Sqrt(a * a + b * b));

        }
    }
}
