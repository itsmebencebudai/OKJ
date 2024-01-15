using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace mozi_WPF
{
    /// <summary>
    /// Interaction logic for frmFilm.xaml
    /// </summary>
    public partial class frmFilm : Window
    {
        private readonly string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";
        private MySqlConnection mySqlConnection;
        public frmFilm()
        {
            Uri iconUri = new("images/mozi.ico", UriKind.RelativeOrAbsolute);
            this.Icon = BitmapFrame.Create(iconUri);

            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
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
                using MySqlCommand cmd = new(directorQuery, mySqlConnection);
                mySqlConnection.Open();

                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["nev"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a rendezők betöltésekor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        private void UresUrlap_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            comboBox1.SelectedIndex = -1;
            numericUpDown1.Text = "2000";
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn = new(connectionString);
            conn.Open();

            string delete = $"DELETE FROM film WHERE film.cím LIKE '{textBox2.Text}'";

            MessageBoxResult dialogResult = MessageBox.Show("Biztosan törli?", "Törlés", MessageBoxButton.YesNo);

            if (dialogResult == MessageBoxResult.Yes)
            {
                try
                {
                    new MySqlCommand(delete, conn).ExecuteNonQuery();
                    MessageBox.Show("Sikeresen törölve");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nem sikerült a törlés! " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void MentButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Kérem töltse ki a Címmezőt!");
            }
            else
            {
                MySqlConnection conn = new(connectionString);
                conn.Open();

                string EAZONvalue = textBox1.Text;

                if (!string.IsNullOrEmpty(EAZONvalue))
                {
                    string InsertUpdateQuery = $"INSERT INTO `film` (`cím`, `hossz`, `mufaj`, `rendezo`, `gyart_ev`, `szarmazas`) VALUES ('{textBox2.Text}','{numericUpDown1.Text}','{textBox3.Text}','{EAZONvalue}','{textBox5.Text}','{textBox4.Text}')";

                    try
                    {
                        new MySqlCommand(InsertUpdateQuery, conn).ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nem sikerült a feltöltés! " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    string FAZONLekérdezés = $"SELECT FAZON FROM film WHERE cím LIKE @cím";
                    using MySqlCommand cmd = new(FAZONLekérdezés, conn);
                    cmd.Parameters.AddWithValue("@cím", (textBox2.Text).ToString());

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
                else
                {
                    MessageBox.Show("Érvénytelen kiválasztás a Rendezo választásakor");
                }

                conn.Close();
            }
        }
        private void KeresButton_Click(object sender, RoutedEventArgs e)
        {
            frmFilmLista frmFilmListaOpen = new((textBox2.Text).ToString());
            frmFilmListaOpen.Show();
        }
        private void ComboBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MySqlConnection conn = new(connectionString);

            try
            {
                conn.Open();
                if (comboBox1.SelectedItem != null)
                {
                    string selectedDirector = comboBox1.SelectedItem.ToString();
                    string rendezoQuery = "SELECT EAZON FROM ember WHERE nev LIKE @selectedDirector";

                    using (MySqlCommand command = new MySqlCommand(rendezoQuery, conn))
                    {
                        command.Parameters.AddWithValue("@selectedDirector", selectedDirector);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBox1.Text = reader["EAZON"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a rendező azonosítójának lehívásakor! " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
