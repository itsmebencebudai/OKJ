using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace mozi_WFA
{
    public partial class frmFilm : Form
    {
        readonly string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";

        private MySqlConnection mySqlConnection;

        public class ComboBoxItem
        {
            readonly string displayValue;
            readonly string hiddenValue;

            public ComboBoxItem(string d, string h)
            {
                displayValue = d;
                hiddenValue = h;
            }

            public string HiddenValue
            {
                get { return hiddenValue; }
            }

            public override string ToString()
            {
                return displayValue;
            }
        }

        public frmFilm()
        {
            InitializeComponent();
        }

        private void FrmFilm_Load(object sender, EventArgs e)
        {
            FillDirectorComboBox();
        }

        private void FillDirectorComboBox()
        {
            try
            {
                // Rendező ComboBox feltöltése az adatbázisból
                mySqlConnection = new MySqlConnection(connectionString);

                string directorQuery = "SELECT nev,EAZON FROM ember INNER JOIN film ON ember.EAZON = film.RENDEZO GROUP BY 1";
                using (MySqlCommand cmd = new MySqlCommand(directorQuery, mySqlConnection))
                {
                    mySqlConnection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["nev"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a rendezők betöltésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                mySqlConnection.Close();
                //MessageBox.Show("connection closed");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            frmFilmLista frmFilmListaOpen = new frmFilmLista();
            frmFilmListaOpen.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(' '))
            {
                MessageBox.Show("Kérem töltse ki a Címmezőt!");
            }
            else
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                conn.Open();

                string selectedValue = comboBox1.SelectedItem as string;  // Ellenőrizze, hogy az objektum string-e

                if (selectedValue != null)
                {
                    // Használja a kiválasztott string értéket a lekérdezésében
                    string InsertUpdateQuery = $"INSERT INTO `film` (`cím`, `hossz`, `mufaj`, `rendezo`, `gyart_ev`, `szarmazas`) VALUES ('{textBox3.Text}','{numericUpDown1.Value}','{textBox2.Text}','{selectedValue}','{textBox4.Text}','{textBox5.Text}')";

                    try
                    {
                        new MySqlCommand(InsertUpdateQuery, conn).ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nem sikerült a feltöltés! " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string FAZONQuery = $"SELECT FAZON FROM film WHERE cím LIKE '{textBox2.Text}'";
                    MySqlDataReader FAZONQuery_reader = new MySqlCommand(FAZONQuery, conn).ExecuteReader();
                    while (FAZONQuery_reader.Read())
                    {
                        textBox1.Text = $"{FAZONQuery_reader[0]}";
                    }
                }
                else
                {
                    // Kezelje az esetet, amikor a kiválasztott elem nem string típusú
                    MessageBox.Show("Érvénytelen kiválasztás a ComboBox1-ben");
                }

                conn.Close();
            }


        }

        private void Button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            comboBox1.SelectedIndex = 0;
            numericUpDown1.Value = numericUpDown1.Minimum;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            string torol = $"DELETE FROM film WHERE film.FAZON = {textBox1.Text}";
            DialogResult dialogResult = MessageBox.Show("Bizotsan törli?", "Törlés", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    new MySqlCommand(torol, conn).ExecuteNonQuery();
                    MessageBox.Show("Sikeresen törölve");
                }
                catch (Exception)
                {
                    MessageBox.Show("Nem sikerült a törölés");
                }

            }
        }
    }
}
