using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harom_egy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int r = int.Parse(textBox1.Text);
            //textBox2.Text = Convert.ToString(2 * Math.PI * r);
            //textBox3.Text = Convert.ToString(Math.PI * Math.Pow(r,2));
            double k = 2 * r * Math.PI; 
            double t = r * r * Math.PI;
            textBox2.Text = "A kör kerülete: " + k.ToString();
            textBox3.Text = "A kör területe: " + t.ToString();
            MessageBox.Show("A kör kerülete: " + k.ToString());
            MessageBox.Show("A kör területe: " + t.ToString());
        }
    }
}
