using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fuggohidak
{
    public partial class Form1 : Form
    {
        private string connenctionString = "server=localhost;user=root;database=fuggohidak;password=";
        private static List<Fuggohid> fuggohidList = new List<Fuggohid>();
        class Fuggohid
        {
            public int helyezes { get; set; }
            public string nev { get; set; }
            public string hely { get; set; }
            public string orszag { get; set; }
            public int hossz { get; set; }
            public int atadas { get; set; }
        }
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            fuggohidList.Clear();
            getHidData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(connenctionString);

            try
            {
                con.Open();
                string sqlDown = "SELECT `Hid` FROM `hidak`";
                MySqlCommand downquery = new MySqlCommand(sqlDown, con);
                MySqlDataReader reader = downquery.ExecuteReader();

                listBox1.Items.Clear();
                while (reader.Read())
                    listBox1.Items.Add(reader.GetString("Hid"));
            }
            catch (Exception error)
            {
                MessageBox.Show("Error(Form1_Load): ", error.Message);
            }
            finally
            {
                con.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {

                if (form is Form1)
                {
                    form.Close();
                    break;
                }
                if (form is Form2)
                {
                    form.Close();
                    break;
                }
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedHid = (string)listBox1.SelectedItem;
                Fuggohid selectedFuggohid = fuggohidList.FirstOrDefault(a => a.nev.Equals(selectedHid));
                if (selectedFuggohid != null)
                {
                    textBox1.Text = selectedFuggohid.hely.ToString();
                    textBox2.Text = selectedFuggohid.orszag.ToString();
                    textBox3.Text = selectedFuggohid.hossz.ToString();
                    textBox4.Text = selectedFuggohid.atadas.ToString();
                }
            }
            catch (Exception er)
            {
                MessageBox.Show("Error(listBox1_SelectedIndexChanged): ", er.Message);
            }
        }
        private void getHidData()
        {
            MySqlConnection con = new MySqlConnection(connenctionString);
            try
            {
                con.Open();
                string sqlDown = "SELECT `Helyezes`,`Hid`,`Hely`,`Orszag`,`Hossz`,`Ev` FROM `hidak`";
                MySqlCommand downquery = new MySqlCommand(sqlDown, con);
                MySqlDataReader reader = downquery.ExecuteReader();
                while (reader.Read())
                {
                    string helyezes = reader.GetInt32("Helyezes").ToString();
                    string hid = reader.GetString("Hid");
                    string hely = reader.GetString("Hely");
                    string orszag = reader.GetString("Orszag");
                    string hossz = reader.GetInt32("Hossz").ToString();
                    string ev = reader.GetInt32("Ev").ToString();
                    fuggohidList.Add(new Fuggohid
                    {
                        helyezes = int.Parse(helyezes),
                        nev = hid,
                        hely = hely,
                        orszag = orszag,
                        hossz = int.Parse(hossz),
                        atadas = int.Parse(ev)
                    });
                }
                reader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error (getHidData): " + error.Message);
            }
            finally
            {
                con.Close();
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            int asd = fuggohidList.Count(a => a.atadas < 2000);
            textBox5.Text = asd.ToString();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            int asd = fuggohidList.Count(a => a.atadas >= 2000);
            textBox5.Text = asd.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
    }
}
