using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negy_hat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) < 0 || int.Parse(textBox1.Text) > 50)
            {
                MessageBox.Show("Nem megfelekő a pont");
            }
            int pont = int.Parse(textBox1.Text);
            if (pont >= 0 && pont <= 10)
            {
                label8.Text = "Elégtelen";
            }
            else if (pont <= 20)
            {
                label8.Text = "Elégséges";
            }
            else if (pont <= 30)
            {
                label8.Text = "Közepes";
            }
            else if (pont <= 40)
            {
                label8.Text = "Jó";
            }
            else if (pont <= 50)
            {
                label8.Text = "Kitűnő";
            }
        }
    }
}
