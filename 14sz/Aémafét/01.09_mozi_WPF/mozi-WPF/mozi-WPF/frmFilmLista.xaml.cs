using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace mozi_WPF
{
    /// <summary>
    /// Interaction logic for frmFilmLista.xaml
    /// </summary>
    public partial class frmFilmLista : Window
    {
        private readonly string kapcsolatString = "server=localhost;user=root;database=mozimusor;port=3306;password=";
        private readonly MySqlConnection mysqlKapcsolat;
        private readonly DataTable adatTabla;
        public frmFilmLista(string cimFrmFilmbol)
        {
            if (textBox1 != null)
            {
                textBox1.Text = cimFrmFilmbol;
            }

            InitializeComponent();
            adatTabla = new DataTable();
            mysqlKapcsolat = new MySqlConnection(kapcsolatString);

            mysqlKapcsolat.Open();
            RefreshData_LoadFromMain(cimFrmFilmbol);
            RefreshData();
            mysqlKapcsolat.Close();
        }
        private void RefreshData()
        {
            string sqlLekerdezes = $"SELECT cím, hossz, mufaj, rendezo, gyart_ev, szarmazas FROM film INNER JOIN ember ON film.RENDEZO=ember.EAZON";
            MySqlCommand sqlCommand = new(sqlLekerdezes, mysqlKapcsolat);
            MySqlDataAdapter adapter = new(sqlCommand);
            adatTabla.Clear();
            adapter.Fill(adatTabla);
            dataGridView1.ItemsSource = adatTabla.DefaultView;
        }
        private void RefreshData_LoadFromMain(string filmcím)
        {
            string sqlLekerdezes = $"SELECT cím, hossz, mufaj, rendezo, gyart_ev, szarmazas FROM film INNER JOIN ember ON film.RENDEZO=ember.EAZON WHERE cím LIKE '{filmcím}'";
            MySqlCommand sqlCommand = new(sqlLekerdezes, mysqlKapcsolat);
            MySqlDataAdapter adapter = new(sqlCommand);
            adatTabla.Clear();
            adapter.Fill(adatTabla);
            dataGridView1.ItemsSource = adatTabla.DefaultView;
        }
        private void TextBox1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            mysqlKapcsolat.Open();

            string sqlLekerdezes = $"SELECT cím, hossz, mufaj, rendezo, gyart_ev, szarmazas FROM film INNER JOIN ember ON film.RENDEZO=ember.EAZON WHERE cím LIKE '%{textBox1.Text}%'";
            MySqlCommand sqlCommand = new(sqlLekerdezes, mysqlKapcsolat);
            MySqlDataAdapter adapter = new(sqlCommand);
            adatTabla.Clear();
            adapter.Fill(adatTabla);
            dataGridView1.ItemsSource = adatTabla.DefaultView;

            mysqlKapcsolat.Close();
        }
    }
}
