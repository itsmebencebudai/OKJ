using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace adatbovites
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            // 4 perc
            string orszagText = textBox1.Text;
            string teruletText = numericUpDown1.Text;
            string fovarosText = textBox4.Text;
            string fovarosLakossagText = textBoxFovarosLakossag.Text;
            string nepessegText = textBoxOrszagLakossag.Text;

            if (!int.TryParse(fovarosLakossagText, out int fovarosLakossag) || !int.TryParse(nepessegText, out int orszagLakossag))
            {
                MessageBox.Show("Kérjük, csak számokat adjon meg a lakossági adatoknál!");
                return;
            }

            if (fovarosLakossag > orszagLakossag)
            {
                MessageBox.Show("A főváros lakossága nem lehet több a népességnél!");
                return;
            }

            string ujadatFilePath = "ujadat.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(ujadatFilePath, true))
                {
                    sw.WriteLine($"{orszagText};{teruletText};{nepessegText};{fovarosText};{fovarosLakossag}");
                }

                MessageBox.Show("A mentés sikeres!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a mentés során: {ex.Message}");
            }
        }
    }
}
