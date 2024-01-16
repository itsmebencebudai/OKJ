using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;


namespace mozi_WPF
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        private MySqlConnection mySqlConnection;
        private MySqlDataAdapter mySqlDataAdapter;
        private DataTable dataTable;

        public frmMain()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RunMoziSqlFile();
            InitializeDatabaseConnection();
            LoadDataToDataGrid();

            string time = "Idő: " + DateTime.Now.Year.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Day.ToString() + ".";
            idoLabel.Text = time;
        }
        private void LoadDataToDataGrid()
        {
            try
            {
                mySqlDataAdapter.Fill(dataTable);
                FillMovieTypesComboBox();
                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az adatok betöltésekor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            try
            {
                string tipus = comboBox.SelectedItem?.ToString();

                dataTable = new DataTable();
                string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";
                mySqlConnection = new MySqlConnection(connectionString);

                mySqlConnection.Open();

                string sqlQuery = $"SELECT nev,kerulet,típus FROM mozi WHERE típus LIKE '{tipus}' ORDER BY 1 ASC";
                using (MySqlDataReader reader = new MySqlCommand(sqlQuery, mySqlConnection).ExecuteReader())
                {
                    dataTable.Load(reader);
                }

                dataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a ComboBox kiválasztásakor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void FillMovieTypesComboBox()
        {
            try
            {
                string typeQuery = "SELECT DISTINCT típus FROM mozi";
                using MySqlCommand cmd = new(typeQuery, mySqlConnection);
                mySqlConnection.Open();
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader["típus"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a mozi típusok betöltésekor: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }
        private void InitializeDatabaseConnection()
        {
            string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";
            mySqlConnection = new MySqlConnection(connectionString);

            string sqlQuery = "SELECT nev, kerulet, típus FROM mozi ORDER BY nev ASC";
            mySqlDataAdapter = new MySqlDataAdapter(sqlQuery, mySqlConnection);

            dataTable = new DataTable();
        }
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Biztosan kiakar lépni?", "Kilépés", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }
        private static void RunMoziSqlFile()
        {
            try
            {
                MessageBox.Show("mozi.sql végrehajtása elkezdődött!");

                string sqlFilePath = "mozi.sql";

                // SQL script beolvasása fájlból
                string sqlScript = System.IO.File.ReadAllText(sqlFilePath);

                string connectionString = "server=localhost;user=root;database=;port=3306;password=";

                // SQL parancs végrehajtása az adatbázis kapcsolaton keresztül
                using (MySqlConnection connection = new(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new(sqlScript, connection))
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
                MessageBox.Show("Hiba a mozi.sql végrehajtása során: " + ex.Message, "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            // Menü láthatóságának váltása
            menu.Visibility = (menu.Visibility == Visibility.Visible) ? Visibility.Hidden : Visibility.Visible;
        }

        private void SzekesztMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // frmFilm megnyitása "Szekeszt" menüelem kattintásakor
            frmFilm frmFilmOpen = new();
            frmFilmOpen.Show();
        }

        private void KeresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // frmFilmLista megnyitása "Keres" menüelem kattintásakor
            string NoCím = " ";
            frmFilmLista frmFilmListaOpen = new(NoCím);
            frmFilmListaOpen.Show();
        }
    }
}
