using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Futar
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            comboBox1.Items.Add("január");
            comboBox1.Items.Add("február");
            comboBox1.Items.Add("március");
            comboBox1.Items.Add("április");
            comboBox1.Items.Add("május");
            comboBox1.Items.Add("június");
            comboBox1.Items.Add("július");
            comboBox1.Items.Add("agusztus");
            comboBox1.Items.Add("szeptember");
            comboBox1.Items.Add("október");
            comboBox1.Items.Add("november");
            comboBox1.Items.Add("december");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RunSqlScript();

            label_datum.Text = DateTime.Now.Year + "." + DateTime.Now.Month + "." + DateTime.Now.Day;

            switch (DateTime.Now.Month)
            {
                case 1: comboBox1.SelectedIndex = 0; break;
                case 2: comboBox1.SelectedIndex = 1; break;
                case 3: comboBox1.SelectedIndex = 2; break;
                case 4: comboBox1.SelectedIndex = 3; break;
                case 5: comboBox1.SelectedIndex = 4; break;
                case 6: comboBox1.SelectedIndex = 5; break;
                case 7: comboBox1.SelectedIndex = 6; break;
                case 8: comboBox1.SelectedIndex = 7; break;
                case 9: comboBox1.SelectedIndex = 8; break;
                case 10: comboBox1.SelectedIndex = 9; break;
                case 11: comboBox1.SelectedIndex = 10; break;
                case 12: comboBox1.SelectedIndex = 11; break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button2, 0, button2.Height);
        }

        private void szerkesztésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKuld frmKuld = new frmKuld();
            frmKuld.ShowDialog();
        }

        private void keresésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKuldLista frmKuldLista = new frmKuldLista();
            frmKuldLista.ShowDialog();
        }
        private void RunSqlScript()
        {
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";

            string connectionString = $"server={server};port={port};user={username};password={password};";

            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                MessageBox.Show("Connecting to MySQL...");
                connection.Open();

                string databaseName = "futar";
                string dropDatabaseQuery = $"DROP DATABASE IF EXISTS {databaseName};";
                MySqlCommand dropDatabaseCommand = new MySqlCommand(dropDatabaseQuery, connection);
                dropDatabaseCommand.ExecuteNonQuery();

                string createDatabaseQuery = $"CREATE DATABASE IF NOT EXISTS {databaseName};";
                MySqlCommand createDatabaseCommand = new MySqlCommand(createDatabaseQuery, connection);
                createDatabaseCommand.ExecuteNonQuery();

                string useDatabaseQuery = $"USE {databaseName};";
                MySqlCommand useDatabaseCommand = new MySqlCommand(useDatabaseQuery, connection);
                useDatabaseCommand.ExecuteNonQuery();

                string scriptFilePath = "futar_accdb.sql";
                string script = File.ReadAllText(scriptFilePath);

                MySqlCommand command = new MySqlCommand(script, connection);
                command.ExecuteNonQuery();

                string mySqlCommand = $"" +
                    $"SELECT küldemény.azonosító, DATE_FORMAT(küldemény.időpont, '%Y-%m') AS formatted_date, küldemény.kinek, futár.f_név " +
                    $"FROM küldemény " +
                    $"INNER JOIN futár ON futár.f_szám = küldemény.f_szám " +
                    $"WHERE DATE_FORMAT(küldemény.időpont, '%Y-%m') = '{DateTime.Now.ToString("yyyy-MM")}';";
                MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

                DataTable dataTable = new DataTable();

                try
                {
                    using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            dataTable.Load(reader);
                            dataGridView1.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No data found for the current date.");
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("MySQL Error: " + ex.Message);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string server = "localhost";
            string port = "3306";
            string username = "root";
            string password = "";
            string database = "futar";

            string connectionString = $"server={server};port={port};user={username};password={password};database={database}";

            MySqlConnection connection = new MySqlConnection(connectionString);
            string selectedDate = $"{DateTime.Now.Year}-0{comboBox1.SelectedIndex + 1}";
            string mySqlCommand = "SELECT küldemény.azonosító as 'Azonosító', DATE_FORMAT(küldemény.időpont, '%Y-%m') AS 'Dátum', küldemény.kinek as 'Címzett', futár.f_név as 'Futár' " +
                                    "FROM küldemény " +
                                    "INNER JOIN futár ON futár.f_szám = küldemény.f_szám " +
                                    $"WHERE DATE_FORMAT(küldemény.időpont, '%Y-%m') = '{selectedDate}'";
            MySqlCommand sqlCommand = new MySqlCommand(mySqlCommand, connection);

            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();
                using (MySqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show($"No data found for the selected month. {selectedDate}");
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
    }
}
