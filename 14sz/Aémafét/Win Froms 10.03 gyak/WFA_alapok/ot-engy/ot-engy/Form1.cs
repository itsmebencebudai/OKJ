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

namespace ot_engy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        struct Gyumolcs
        {
            public string Nev;
            public double Mennyiseg;
            public double Ar;
        }
        static Gyumolcs[] BeolvasGyumolcsok(string fajlPath)
        {
            string[] sorok = File.ReadAllLines(fajlPath);
            Gyumolcs[] gyumolcsok = new Gyumolcs[sorok.Length / 3];

            for (int i = 0; i < sorok.Length; i += 3)
            {
                gyumolcsok[i / 3] = new Gyumolcs
                {
                    Nev = sorok[i],
                    Mennyiseg = double.Parse(sorok[i + 1]),
                    Ar = double.Parse(sorok[i + 2])
                };
            }

            return gyumolcsok;
        }
        static double SzamolKeszletErteke(Gyumolcs[] gyumolcsok)
        {
            double osszErtek = 0;

            foreach (Gyumolcs gyumolcs in gyumolcsok)
            {
                osszErtek += gyumolcs.Mennyiseg * gyumolcs.Ar;
            }

            return osszErtek;
        }
        private void btnSzamol_Click(object sender, EventArgs e)
        {

                string fajlPath = txtFajlPath.Text;

                // Gyümölcsök beolvasása a fájlból
                Gyumolcs[] gyumolcsok = BeolvasGyumolcsok(fajlPath);

                // Készlet összértékének kiszámítása
                double osszErtek = SzamolKeszletErteke(gyumolcsok);

                // Összérték megjelenítése a Label-en
                lblEredmeny.Text = $"A készlet összértéke: {osszErtek:F2} Ft";

        }
    }
}
