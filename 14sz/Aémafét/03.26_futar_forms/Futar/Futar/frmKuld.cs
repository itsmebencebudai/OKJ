using MySql.Data.MySqlClient;
using System.Text;

namespace Futar
{
    public partial class frmKuld : Form
    {
        public frmKuld()
        {
            InitializeComponent();
        }

        private void frmKuld_Load(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            textBox3.ReadOnly = true;
            textBox3.Text = DateTime.Now.ToString();
            button3.Enabled = false;

            LoadKitol();
            LoadKinek();
            LoadFutar();
        }

        private void LoadKitol()
        {
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";
            string database = "futar";

            string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            string mySqlCommand = "SELECT küldemény.kitől " +
                                  "FROM küldemény";
            MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

            try
            {
                connection.Open();
                using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader.GetString("kitől"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
        private void LoadKinek()
        {
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";
            string database = "futar";

            string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            string mySqlCommand = "SELECT küldemény.kinek " +
                                  "FROM küldemény";
            MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

            try
            {
                connection.Open();
                using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader.GetString("kinek"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadFutar()
        {
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";
            string database = "futar";

            string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            string mySqlCommand = "SELECT futár.f_név " +
                                  "FROM futár";
            MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

            try
            {
                connection.Open();
                using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBox3.Items.Add(reader.GetString("f_név"));
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmKuldLista frmKuldLista = new frmKuldLista();
            frmKuldLista.ShowDialog();
        }


        class Futarok
        {
            public string? Name;
            public string? ID;
        }

        private List<Futarok> list = new List<Futarok>();
        private void button2_Click(object sender, EventArgs e)
        {
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";
            string database = "futar";

            string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string mySqlCommand = "INSERT INTO küldemény (azonosító,kelt, időpont, kitől, kinek, f_szám) VALUES (@azonosító ,@kelt, @időpont, @kitől, @kinek, @f_szám)";
                MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

                sqlCommand.Parameters.AddWithValue("@azonosító", GetLastAzonosító());
                sqlCommand.Parameters.AddWithValue("@kelt", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@időpont", DateTime.Now);
                if (comboBox1.SelectedItem != null && !string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
                {
                    sqlCommand.Parameters.AddWithValue("@kitől", comboBox1.SelectedItem.ToString());
                }
                if (comboBox2.SelectedItem != null && !string.IsNullOrWhiteSpace(comboBox2.SelectedItem.ToString()))
                {
                    sqlCommand.Parameters.AddWithValue("@kinek", comboBox2.SelectedItem.ToString());
                }
                if (comboBox3.SelectedItem != null && !string.IsNullOrWhiteSpace(comboBox3.SelectedItem.ToString()))
                {
                    sqlCommand.Parameters.AddWithValue("@f_szám", GetFutarID(comboBox3.SelectedItem.ToString()));
                }

                if (textBox1.Text == string.Empty ||
                    textBox2.Text == string.Empty ||
                    textBox3.Text == string.Empty ||
                    comboBox1.SelectedItem == null ||
                    comboBox2.SelectedItem == null ||
                    comboBox3.SelectedItem == null)
                {
                    try
                    {
                        connection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        MessageBox.Show($"{rowsAffected} row(s) inserted successfully.");
                        textBox2.Text = DateTime.Now.ToString();
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("MySQL Error: " + ex.Message);
                    }
                }
            }
        }

        private bool IsValidDateTime(string input)
        {
            string[] formats = { "yyyy-MM-dd HH:mm:ss" };
            return DateTime.TryParseExact(input, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboBox1.SelectedItem.ToString());
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string GetFutarID(string name)
        {
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";
            string database = "futar";

            string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            string mySqlCommand = "SELECT * FROM `futár`";
            MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

            try
            {
                connection.Open();
                using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Futarok { Name = reader.GetString("f_név"), ID = reader.GetString("f_szám") });
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MySQL Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
                //ShowFutarList();
            }

            foreach (Futarok futar in list)
            {
                if (futar.Name == name)
                {
                    //MessageBox.Show(futar.ID);
                    return futar.ID;
                }
            }

            MessageBox.Show("Futar name not found: " + name);
            return null;
        }

        private void ShowFutarList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Futarok futar in list)
            {
                sb.AppendLine($"Name: {futar.Name}, ID: {futar.ID}");
            }
            MessageBox.Show(sb.ToString(), "Futar List");
        }

        private int GetLastAzonosító()
        {
            int lastAzonosító = -1;
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";
            string database = "futar";

            string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string mySqlCommand = "SELECT MAX(azonosító) FROM küldemény";
                MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

                try
                {
                    connection.Open();
                    object result = sqlCommand.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        lastAzonosító = Convert.ToInt32(result);
                        textBox1.Text = lastAzonosító.ToString();
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message);
                }
            }

            return lastAzonosító + 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Biztosan törölni szeretné a rekordot?", "Megerősítés", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                string server = "localhost";
                string port = "3306";
                string username = "root";
                string password = "";
                string database = "futar";

                string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    string mySqlCommand = "DELETE FROM küldemény WHERE kelt = @kelt AND időpont = @időpont";
                    MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

                    sqlCommand.Parameters.AddWithValue("@kelt", DateTime.Now);
                    sqlCommand.Parameters.AddWithValue("@időpont", textBox3.Text);

                    if (comboBox1.SelectedItem != null && !string.IsNullOrWhiteSpace(comboBox1.SelectedItem.ToString()))
                    {
                        sqlCommand.Parameters.AddWithValue("@kitől", comboBox1.SelectedItem.ToString());
                    }
                    if (comboBox2.SelectedItem != null && !string.IsNullOrWhiteSpace(comboBox2.SelectedItem.ToString()))
                    {
                        sqlCommand.Parameters.AddWithValue("@kinek", comboBox2.SelectedItem.ToString());
                    }

                    try
                    {
                        connection.Open();
                        int rowsAffected = sqlCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show($"{rowsAffected} rekord sikeresen törölve.");
                        }
                        else
                        {
                            MessageBox.Show($"Nem sikerült törölni.");
                        }

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("MySQL Hiba: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                button3.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
            }
        }
    }
}
