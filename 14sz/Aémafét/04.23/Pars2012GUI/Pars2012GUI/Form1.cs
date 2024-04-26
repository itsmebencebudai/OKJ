using static Pars2012GUI.Form1;

namespace Pars2012GUI
{
    public partial class Form1 : Form
    {

        public class Versenyzok
        {
            public string Név { get; set; }
            public char Csoport { get; set; }
            public string NemzetEsKod { get; set; }
            public string Sorozat { get; set; }
            public double[] Dobasok { get; private set; }

            public Versenyzok(string line)
            {
                string[] strings = line.Split(';');

                Név = strings[0];
                Csoport = char.Parse(strings[1]);
                NemzetEsKod = strings[2];
                Sorozat = $"{strings[3]}; {strings[4]}; {strings[5]}";
                Dobasok = new double[3];
                for (int i = 0; i < Dobasok.Length; i++)
                {
                    if (strings[i + 3] == "X")
                        Dobasok[i] = -1.0;
                    else if (strings[i + 3] == "-")
                        Dobasok[i] = -2.0;
                    else
                        Dobasok[i] = Convert.ToDouble(strings[i + 3]);
                }
            }

            public double Eredmeny
            {
                get
                {
                    double maximum = Dobasok[0];
                    foreach (var i in Dobasok.Skip(1))
                        if (i > maximum)
                            maximum = i;
                    return maximum;
                }
            }

            public string Nemzet
            {
                get
                {
                    string[] splited = NemzetEsKod.Split(' ');
                    return String.Join(" ", splited.Take(splited.Length - 1));
                }
            }
            public string Kod
            {
                get
                {
                    string[] splited = NemzetEsKod.Split(' ');
                    string kod = splited.Last().Replace("(", "").Replace(")", "");
                    return kod;
                }
            }

        }
        public static List<Versenyzok> versenyzok = new List<Versenyzok>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool foundParsKrisztian = false;
            StreamReader sr = new StreamReader("Selejtezo2012.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                versenyzok.Add(new Versenyzok(line));
            }
            foreach (var versenyzo in versenyzok)
            {
                comboBox1.Items.Add(versenyzo.Név);
                if (versenyzo.Név.Equals("Pars Krisztián"))
                    comboBox1.SelectedItem = "Pars Krisztián";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Versenyzok selectedVersenyzo = versenyzok.Find(Versenyzo => Versenyzo.Név == comboBox1.SelectedItem.ToString());

            label2.Text = "Csoport: "+ selectedVersenyzo.Csoport.ToString();
            label3.Text = "Nemzet: "+selectedVersenyzo.Nemzet.ToString();
            label4.Text = "Nemzet kód: "+selectedVersenyzo.Kod.ToString();
            label5.Text = "Sorozat: "+selectedVersenyzo.Sorozat.ToString();
            label6.Text = "Eredmeny: "+selectedVersenyzo.Eredmeny.ToString();
            label7.Text = "Zászló:";

            pictureBox1.Image = Image.FromFile($"../../../Images/{selectedVersenyzo.Kod}.png");
        }
    }
}
