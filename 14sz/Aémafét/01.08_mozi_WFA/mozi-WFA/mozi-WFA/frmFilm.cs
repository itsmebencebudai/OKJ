using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace mozi_WFA
{
    public partial class frmFilm : Form
    {
        private readonly string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";

        private MySqlConnection mySqlConnection;

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
            frmFilmLista frmFilmListaOpen = new frmFilmLista(textBox1.Text);
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

                string EAZONvalue = textBox2.Text;

                if (EAZONvalue != null)
                {
                    // Használja a kiválasztott string értéket a lekérdezésében
                    string InsertUpdateQuery = $"INSERT INTO `film` (`cím`, `hossz`, `mufaj`, `rendezo`, `gyart_ev`, `szarmazas`) VALUES ('{textBox1.Text}','{numericUpDown1.Value}','{textBox3.Text}','{EAZONvalue}','{textBox4.Text}','{textBox5.Text}')";

                    try
                    {
                        new MySqlCommand(InsertUpdateQuery, conn).ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nem sikerült a feltöltés! " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    string FAZONLekérdezés = $"SELECT FAZON FROM film WHERE cím LIKE @cím";
                    using (MySqlCommand cmd = new MySqlCommand(FAZONLekérdezés, conn))
                    {
                        cmd.Parameters.AddWithValue("@cím", textBox1.Text);

                        try
                        {
                            object eredmény = cmd.ExecuteScalar();

                            if (eredmény != null)
                            {
                                string FAZONÉrték = eredmény.ToString();
                                MessageBox.Show($"Film sikeresen feltöltve. FAZON: {FAZONÉrték}");
                            }
                            else
                            {
                                MessageBox.Show("Film nem található az adatbázisban.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Hiba a Film feltöltésekor: {ex.Message}");
                        }
                        finally
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Érvénytelen kiválasztás a Rendezo választásakor");
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
            string delete = $"DELETE FROM film WHERE film.cím LIKE '{textBox1.Text}'";
            DialogResult dialogResult = MessageBox.Show("Bizotsan törli?", "Törlés", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    new MySqlCommand(delete, conn).ExecuteNonQuery();
                    MessageBox.Show("Sikeresen törölve");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nem sikerült a törölés! " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                string selectedDirector = comboBox1.SelectedItem.ToString();
                string rendezoQuery = "SELECT EAZON FROM ember WHERE nev LIKE @selectedDirector";

                using (MySqlCommand command = new MySqlCommand(rendezoQuery, conn))
                {
                    command.Parameters.AddWithValue("@selectedDirector", selectedDirector);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox2.Text = reader["EAZON"].ToString();
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a rendezo azonosítójának lehívásakor! " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
