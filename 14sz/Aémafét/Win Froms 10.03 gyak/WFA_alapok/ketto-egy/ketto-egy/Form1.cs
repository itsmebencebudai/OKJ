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

namespace ketto_egy
{

    public partial class Form1 : Form
    {
        class Orszag
        {
            public string Nev { get; set; }
            public double Terulet { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
        }
        struct Rekord
        {
            public string orszag;
            public int terulet;
        }
        const int MAX = 100;
        Rekord[] v = new Rekord[MAX];
        int n;

        private void button4_Click(object sender, EventArgs e)
        {
            n = 0;
            listBox1.Items.Clear();
            if (textBox1.Text != "")
            { 
                if (File.Exists(textBox1.Text))
                { 
                    StreamReader f = File.OpenText(textBox1.Text); 
                    while (!f.EndOfStream && n < MAX)
                    {
                        v[n].orszag = f.ReadLine();
                        string sor = f.ReadLine();
                        v[n].terulet = int.Parse(sor); 
                        listBox1.Items.Add(v[n].orszag + " területe: " + v[n].terulet.ToString());
                        n++;
                    }
                    f.Close();
                } 
                else 
                { 
                    MessageBox.Show("A megadott nevő fájl nem létezik!");
                }
            }
            else
            { 
                MessageBox.Show("Nem adott meg fájlnevet!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Orszag> orszagok = new List<Orszag>
            {
                new Orszag { Nev = "Magyarország", Terulet = 93.03 },
                new Orszag { Nev = "Ausztria", Terulet = 83.88 },
            };
            double osszegTerulet = 0;
            foreach (Orszag orszag in orszagok)
            {
                osszegTerulet += orszag.Terulet;
            }
            double atlagTerulet = osszegTerulet / orszagok.Count;
            MessageBox.Show($"Az országok területének átlaga: {atlagTerulet:F2}");



        }
    }
}
