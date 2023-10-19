using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace negy_ot
{
    public partial class Form1 : Form
    {
        const int MAX = 100; 
        int[] szamok = new int[MAX]; 
        int n;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int paratlanszamok_db = 0;
            int szam; 
            do 
            { 
                string s = Interaction.InputBox("Kérem a következő számot:", "Adatbevitel", "0", 100, 100); 
                szam = int.Parse(s); 
                if (szam != 0) 
                { 
                    if (szam % 2 == 0) 
                    { 
                        listBox1.Items.Add(s); 
                    } 
                    else 
                    {
                        listBox2.Items.Add(s);
                        paratlanszamok_db++;
                    }
                } 
            }
            while (szam != 0);
            textBox1.Text = Convert.ToString(paratlanszamok_db + " db");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int paratlanszamok_db = 0;
            n = 0; string fnev = "szamok.txt"; 
            if (File.Exists(fnev)) 
            {
                StreamReader f = File.OpenText(fnev); 
                while (!f.EndOfStream && n < MAX) 
                {
                    string sor = f.ReadLine(); 
                    szamok[n] = int.Parse(sor);
                    if (szamok[n] % 2 == 0)
                    {
                        listBox1.Items.Add(sor); 
                    } else 
                    {
                        listBox2.Items.Add(sor);
                        paratlanszamok_db++;
                    }
                    n++; 
                } 
                f.Close(); 
                button2.Enabled = true; 
            } else 
            {
                MessageBox.Show("A megadott fájl nem létezik.");
            }
            textBox1.Text = Convert.ToString(paratlanszamok_db+" db");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fnev = "paros.txt"; 
            StreamWriter f = File.CreateText(fnev); 
            for (int i = 0; i < n; i++)
            {
                if (szamok[i] % 2 == 0)
                {
                    f.WriteLine(szamok[i]);
                }
            }
            f.Close();
            MessageBox.Show("A páros számokat fájlba írtam.");
        }
    }
}
