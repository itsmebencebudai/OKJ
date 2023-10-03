using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ketto_negy
{
    public partial class Form_Gyakorlas : Form
    {
        public Form_Gyakorlas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Form beállítás";
            //label1.Text = "Tulajdonságok gyakorlása";
            this.Text = "Tulajdonságok gyakorlása";
            this.BackColor = Color.CornflowerBlue;
            this.label1.BackColor = Color.Firebrick;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Text = "Címke beállítás";
            this.button1.Enabled = false;
            this.label1.AutoSize = false;
            this.label1.Size = new Size(100, 50);
            this.label1.Location = new Point(10,10);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //this.label1.Location = new Point((this.ClientSize.Width - label1.Width) / 2, (this.ClientSize.Height - label1.Height) / 2);
            this.label1.TextAlign = ContentAlignment.MiddleCenter;
            this.label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size + 2);
            this.label1.Size = new Size(this.label1.Size.Width + 10, this.label1.Size.Height + 10);
        }
    }
}
