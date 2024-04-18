using MySql.Data.MySqlClient;

namespace utvonalterv
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;port=3306;database=gepjarmuutvonal;user=root;password=;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                trys
                {
                    connection.Open();

                    string query = "INSERT INTO `vizsga_gepjarmu`(`rendszam`, `marka`, `tipus`, `tulaj_neve`, `fogyasztas`) " +
                                   "VALUES (@rendszam, @marka, @tipus, @tulaj_neve, @fogyasztas)";

                    MySqlCommand command = new MySqlCommand(query, connection);

                    command.Parameters.AddWithValue("@rendszam", textBox1.Text);
                    command.Parameters.AddWithValue("@marka", textBox2.Text);
                    command.Parameters.AddWithValue("@tipus", textBox3.Text);
                    command.Parameters.AddWithValue("@tulaj_neve", textBox4.Text);
                    command.Parameters.AddWithValue("@fogyasztas", int.Parse(textBox5.Text));

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    Form2 form2 = new Form2();
                    form2.Close();
                    connection.Close();
                }

            }
        }
    }
}
