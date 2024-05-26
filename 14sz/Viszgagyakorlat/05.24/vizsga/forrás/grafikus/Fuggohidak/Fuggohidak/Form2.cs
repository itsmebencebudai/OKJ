using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuggohidak
{
    public partial class Form2 : Form
    {
        private string connenctionString = "server=localhost;user=root;database=fuggohidak;password=";
        class Fuggohid
        {
            public int helyezes { get; set; }
            public string nev { get; set; }
            public string hely { get; set; }
            public string orszag { get; set; }
            public int hossz { get; set; }
            public int atadas { get; set; }
        }
        public Form2()
        {
            InitializeComponent();
            listBox1.Items.Clear();
            loadList();
            getHidOrszag();

            comboBox1.SelectedIndex = 1;
        }

        private void getHidOrszag()
        {
            MySqlConnection con = new MySqlConnection(connenctionString);
            try
            {
                con.Open();
                string sqlDown = "SELECT `Orszag` FROM `hidak`";
                MySqlCommand downquery = new MySqlCommand(sqlDown, con);
                MySqlDataReader reader = downquery.ExecuteReader();

                while(reader.Read())
                    comboBox1.Items.Add(reader.GetString("Orszag"));

                reader.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show("Error (getHidOrszag): " + error.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

            Form1 form = new Form1();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool checkbox = checkBox1.Checked;

            if (checkbox)
            {
                MySqlConnection con = new MySqlConnection(connenctionString);

                try
                {
                    con.Open();
                    string sqlDown = "SELECT `Hid` FROM `hidak` WHERE Hossz < 1000 AND `Orszag` LIKE @orszag";
                    MySqlCommand downquery = new MySqlCommand(sqlDown, con);
                    downquery.Parameters.AddWithValue("@orszag", "%" + comboBox1.SelectedItem.ToString() + "%");
                    MySqlDataReader reader = downquery.ExecuteReader();

                    listBox1.Items.Clear();
                    while (reader.Read())
                        listBox1.Items.Add(reader.GetString("Hid"));
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error(loadList): ", error.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MySqlConnection con = new MySqlConnection(connenctionString);

                try
                {
                    con.Open();
                    string sqlDown = "SELECT `Hid` FROM `hidak` WHERE `Orszag` LIKE @orszag";
                    MySqlCommand downquery = new MySqlCommand(sqlDown, con);
                    downquery.Parameters.AddWithValue("@orszag", "%" + comboBox1.SelectedItem.ToString() + "%"); MySqlDataReader reader = downquery.ExecuteReader();

                    listBox1.Items.Clear();
                    while (reader.Read())
                        listBox1.Items.Add(reader.GetString("Hid"));
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error(loadList): ", error.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }
        private void loadList()
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
                MessageBox.Show("Error(loadList): ", error.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
