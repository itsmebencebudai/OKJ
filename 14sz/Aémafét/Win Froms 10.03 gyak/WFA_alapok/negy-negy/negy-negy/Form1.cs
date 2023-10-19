using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace negy_negy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Left = 0; 
            this.Top = 0;

            int kepszel = Screen.PrimaryScreen.Bounds.Width - this.Width; 
            int kepmag = Screen.PrimaryScreen.Bounds.Height - this.Height;

            for (this.Left = 0; this.Left < kepszel; this.Left++) { }

            while (this.Top < kepmag) { this.Top++; }

            for (this.Left = kepszel; this.Left > 0; this.Left--) { } 
            while (this.Top > 0) { this.Top--; }
        }
    }
}
