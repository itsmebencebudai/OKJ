using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
            if (textBox1.Text != "")
            {
                int r = int.Parse(textBox1.Text);
                double k;
                double t;
                if (radioButton1.Checked)
                {
                    k = 2 * r * Math.PI;
                    t = r * r * Math.PI;
                    double f = 4 * Math.PI * Math.Pow(r, 2); //4πr^2
                    double ter = (4.0 / 3.0) * Math.PI * Math.Pow(r, 3);//(4/3)πr^3
                    textBox2.Text = "A kör kerülete: " + k.ToString();
                    textBox3.Text = "A kör területe: " + t.ToString();
                    textBox4.Text = "A kör felszíne: " + f.ToString();
                    textBox5.Text = "A kör térfogata: " + ter.ToString();

                    //MessageBox.Show("A kör kerülete: " + k.ToString());
                    //MessageBox.Show("A kör területe: " + t.ToString());

                }
                else
                {
                    k = 4 * r;
                    t = r * r;
                    textBox2.Text = "A négyzet kerülete: " + k.ToString();
                    textBox3.Text = "A négyzet területe: " + t.ToString();
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "A kör sugara:";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "A négyzet oldalhossza:";
        }
    }
}
