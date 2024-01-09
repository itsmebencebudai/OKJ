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
        private readonly string kapcsolatString = "server=localhost;user=root;database=mozimusor;port=3306;password=";

        private MySqlConnection mysqlKapcsolat;
        private MySqlDataReader mysqlAdatOlvaso;
        private DataTable adatTabla;

        public frmFilmLista(string cimFrmFilmbol)
        {
            InitializeComponent();

            this.textBox1.Text = cimFrmFilmbol;

            adatTabla = new DataTable();
            mysqlKapcsolat = new MySqlConnection(kapcsolatString);

            mysqlKapcsolat.Open();

            string sqlLekerdezes = $"SELECT cím, hossz, mufaj, rendezo, gyart_ev, szarmazas FROM film INNER JOIN ember ON film.RENDEZO=ember.EAZON";
            mysqlAdatOlvaso = new MySqlCommand(sqlLekerdezes, mysqlKapcsolat).ExecuteReader();
            adatTabla.Load(mysqlAdatOlvaso);
            dataGridView1.DataSource = adatTabla;

            mysqlKapcsolat.Close();
        }

        private void FrmFilmLista_Load(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            adatTabla = new DataTable();
            mysqlKapcsolat = new MySqlConnection(kapcsolatString);

            mysqlKapcsolat.Open();

            string sqlLekerdezes = $"SELECT cím, hossz, mufaj, rendezo, gyart_ev, szarmazas FROM film INNER JOIN ember ON film.RENDEZO=ember.EAZON WHERE cím LIKE '%{textBox1.Text}%'";
            mysqlAdatOlvaso = new MySqlCommand(sqlLekerdezes, mysqlKapcsolat).ExecuteReader();
            adatTabla.Load(mysqlAdatOlvaso);
            dataGridView1.DataSource = adatTabla;

            mysqlKapcsolat.Close();
        }
    }
}
