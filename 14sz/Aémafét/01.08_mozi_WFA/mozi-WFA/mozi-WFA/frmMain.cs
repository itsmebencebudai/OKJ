using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace mozi_WFA
{
    public partial class frmMain : Form
    {
        private MySqlConnection mySqlConnection;
        private MySqlDataAdapter mySqlDataAdapter;
        private MySqlDataReader mySqlDataReader;
        private DataTable dataTable;

        public frmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            MessageBox.Show("mozi.sql végrehajtása!");
            RunMoziSqlFile();
            InitializeDatabaseConnection();
            LoadDataToDataGridView();

            string time = "Idő: " + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + ".";
            ido_label.Text = time;
        }

        private void RunMoziSqlFile()
        {
            try
            {
                string sqlFilePath = "mozi.sql";

                // SQL script beolvasása fájlból
                string sqlScript = System.IO.File.ReadAllText(sqlFilePath);

                string connectionString = "server=localhost;user=root;database=;port=3306;password=";

                // SQL parancs végrehajtása az adatbázis kapcsolaton keresztül
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(sqlScript, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    connection.Close();
                }


                MessageBox.Show("Sikeres a mozi.sql végrehajtása!");
            }
            catch (Exception ex)
            {
                // Kezeld a végrehajtás közben felmerülő kivételeket
                MessageBox.Show("Hiba a mozi.sql végrehajtása során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeDatabaseConnection()
        {
            // Adatbázis kapcsolat inicializálása
            string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";
            mySqlConnection = new MySqlConnection(connectionString);

            // MySQL lekérdezés inicializálása (példa)
            string sqlQuery = "SELECT nev, kerulet, típus FROM mozi ORDER BY nev ASC";
            mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, mySqlConnection);

            // DataTable inicializálása
            dataTable = new DataTable();
        }

        private void LoadDataToDataGridView()
        {
            try
            {
                // Adatok betöltése a DataTable-be
                mySqlDataAdapter.Fill(dataTable);

                // ComboBox feltöltése a mozi típusokkal
                FillMovieTypesComboBox();

                // DataTable hozzárendelése a DataGridView-hoz
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adatok betöltésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillMovieTypesComboBox()
        {
            try
            {
                // Típus ComboBox feltöltése az adatbázisból
                string typeQuery = "SELECT DISTINCT típus FROM mozi";
                using (MySqlCommand cmd = new MySqlCommand(typeQuery, mySqlConnection))
                {
                    mySqlConnection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["típus"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a mozi típusok betöltésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kapcsolat lezárása a program bezárásakor
            if (mySqlConnection.State == ConnectionState.Open)
            {
                mySqlConnection.Close();
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tipus = comboBox1.Text.ToString();

            dataTable = new DataTable();
            string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";
            mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            string sqlQuery = $"SELECT nev,kerulet,típus FROM mozi WHERE típus LIKE '{tipus}' ORDER BY 1 ASC";
            mySqlDataReader = new MySqlCommand(sqlQuery, mySqlConnection).ExecuteReader();
            dataTable.Load(mySqlDataReader);
            dataGridView1.DataSource = dataTable;

            mySqlConnection.Close();
        }

        private void SzerkesztToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFilm frmFilmOpen = new frmFilm();
            frmFilmOpen.Show();
        }

        private void KeresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFilmLista frmFilmListaOpen = new frmFilmLista();
            frmFilmListaOpen.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(button1, 0, button1.Height);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Biztosan kiakar lépni?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
