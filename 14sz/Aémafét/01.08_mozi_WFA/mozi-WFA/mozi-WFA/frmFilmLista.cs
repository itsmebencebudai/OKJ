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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace mozi_WFA
{
    public partial class frmFilmLista : Form
    {
        readonly string connectionString = "server=localhost;user=root;database=mozimusor;port=3306;password=";

        private MySqlConnection mySqlConnection;
        private MySqlDataReader mySqlDataReader;
        private DataTable dataTable;

        public frmFilmLista()
        {
            InitializeComponent();

            dataTable = new DataTable();
            mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            string sqlQuery = $"SELECT cím,hossz,mufaj,rendezo,gyart_ev,szarmazas FROM film INNER JOIN ember ON film.RENDEZO=ember.EAZON";
            mySqlDataReader = new MySqlCommand(sqlQuery, mySqlConnection).ExecuteReader();
            dataTable.Load(mySqlDataReader);
            dataGridView1.DataSource = dataTable;

            mySqlConnection.Close();
        }

        private void frmFilmLista_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            dataTable = new DataTable();
            mySqlConnection = new MySqlConnection(connectionString);

            mySqlConnection.Open();

            string sqlQuery = $"SELECT cím,hossz,mufaj,rendezo,gyart_ev,szarmazas FROM film INNER JOIN ember ON film.RENDEZO=ember.EAZON WHERE cím LIKE '%{textBox1.Text}%'";
            mySqlDataReader = new MySqlCommand(sqlQuery, mySqlConnection).ExecuteReader();
            dataTable.Load(mySqlDataReader);
            dataGridView1.DataSource = dataTable;

            mySqlConnection.Close();
        }
    }
}
