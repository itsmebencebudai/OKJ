using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace harom_hat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ax^2 + bx + c = 0
            int a = int.Parse(textBox1.Text);
            int b = int.Parse(textBox3.Text);
            int c = int.Parse(textBox4.Text);
            double x1, x2;
            double discriminant = b * b - 4 * a * c;
            x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            textBox2.Text = Convert.ToString( x1);
            textBox5.Text = Convert.ToString( x2);
        }
    }
}
