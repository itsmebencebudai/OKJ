using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data.EntityFramework;
using MySql.Data.Types;
using System.IO;

namespace autoverseny
{
    public partial class Form1 : Form
    {
        private bool feltoltes = false;

        //drop database
        private readonly string sql_drop_database = "DROP DATABASE IF EXISTS autoverseny";

        //database
        private readonly string sql_create_database = "CREATE DATABASE IF NOT EXISTS autoverseny DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci";
        

        ////csapat
        //private readonly string sql_create_table_csapat = "CREATE TABLE IF NOT EXISTS csapat (" +
        //        "  id int," +
        //        "  nev varchar(255)," +
        //        "  alapitva int," +
        //        "  PRIMARY KEY(id)); ";

        ////versenyzo
        //private readonly string sql_create_table_versenyzo = "CREATE TABLE IF NOT EXISTS versenyzo (" +
        //        "  id int," +
        //        "  nev varchar(255)," +
        //        "  eletkor int," +
        //        "  csapatid int," +
        //        "  PRIMARY KEY(id)," +
        //        "  CONSTRAINT FK_versenyzo_csapat_id FOREIGN KEY(csapatid) REFERENCES csapat(id)); ";

        ////palya
        //private readonly string sql_create_table_palya = "CREATE TABLE IF NOT EXISTS palya (" +
        //        "  id int," +
        //        "  nev varchar(255)," +
        //        "  hossz float," +
        //        "  orszag varchar(255)," +
        //        "  PRIMARY KEY(id)); ";

        ////korido
        //private readonly string sql_create_table_korido = "CREATE TABLE IF NOT EXISTS korido (" +
        //        "  id int," +
        //        "  palyaid int," +
        //        "  versenyzoid int," +
        //        "  korido time DEFAULT NULL," +
        //        "  kor int DEFAULT NULL," +
        //        "  PRIMARY KEY(id)," +
        //        "  CONSTRAINT FK_korido_palya_id FOREIGN KEY(palyaid) REFERENCES palya(id)," +
        //        "  CONSTRAINT FK_korido_versenyzo_id FOREIGN KEY(versenyzoid) REFERENCES versenyzo(id)); ";
        

        public Form1()
        {
            InitializeComponent();
        }

        private void feladatoklista_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;username=root;port=3306;password=");

            if (feladatoklista_combobox.SelectedIndex == 0) //1-es 
            {
                eredmeny_listbox.Items.Clear();
                lekerdezes_textbox.Text = sql_create_database;
            }
            else if (feladatoklista_combobox.SelectedIndex == 1) //2-es
            {
                eredmeny_listbox.Items.Clear();

                try
                {
                    string connectionString = "server = localhost; username = root; database = autoverseny; port = 3306; password = ";

                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        connection.Open();
                        try
                        {
                            //tablak.sql
                            string sqlFileContents = File.ReadAllText("tablak.sql");
                            string[] sqlCommands = sqlFileContents.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (string sqlCommand in sqlCommands)
                            {
                                using (MySqlCommand command = new MySqlCommand(sqlCommand, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            MessageBox.Show("SQL kommandok az tablak.sql-ből sikeresen megtörténtek.");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }

                        try
                        {
                            //adatok.sql
                            string sqlFileContents = File.ReadAllText("adatok.sql");
                            string[] sqlCommands = sqlFileContents.Split(new[] { "GO" }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (string sqlCommand in sqlCommands)
                            {
                                using (MySqlCommand command = new MySqlCommand(sqlCommand, connection))
                                {
                                    command.ExecuteNonQuery();
                                }
                            }
                            MessageBox.Show("SQL kommandok az adatok.sql-ből sikeresen megtörténtek.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }

                        connection.Close();
                        feltoltes = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");

                }

                if (feltoltes == true)
                {
                    lekerdezes_textbox.Enabled = false;
                    eredmeny_listbox.Items.Add( "Sikeres a 2-es feladat");
                }
                else
                {
                    lekerdezes_textbox.Enabled = false;
                    eredmeny_listbox.Items.Add("Sikertelen a 2-es feladat");
                }
            }
            else if (feladatoklista_combobox.SelectedIndex==2) //3-as
            {
                eredmeny_listbox.Items.Clear();

                lekerdezes_textbox.Enabled = true;
                conn = new MySqlConnection("server=localhost;username=root;database=autoverseny;port=3306;password=");
                conn.Open();
                string sql_query_1 = "SELECT versenyzo.nev FROM versenyzo ORDER BY versenyzo.eletkor";
                MySqlDataReader query1reader = new MySqlCommand(sql_query_1, conn).ExecuteReader();
                Console.WriteLine("3. feladat: ");
                while (query1reader.Read())
                {
                    eredmeny_listbox.Items.Add(($"\t{query1reader[0]}"));
                }
                query1reader.Close();
                conn.Close();
                lekerdezes_textbox.Text = sql_query_1;
            }
            else if (feladatoklista_combobox.SelectedIndex == 3) //4-es
            {
                eredmeny_listbox.Items.Clear();

                lekerdezes_textbox.Enabled = true;
                conn = new MySqlConnection("server=localhost;username=root;database=autoverseny;port=3306;password=");
                conn.Open();

                string sql_query_2 = "SELECT COUNT(palya.nev) FROM palya";
                MySqlDataReader query2reader = new MySqlCommand(sql_query_2, conn).ExecuteReader();
                Console.WriteLine("4. feladat: ");
                while (query2reader.Read())
                {
                    eredmeny_listbox.Items.Add(($"\t{query2reader[0]}"));
                }
                query2reader.Close();
                conn.Close();
                lekerdezes_textbox.Text = sql_query_2;
            }
            else if (feladatoklista_combobox.SelectedIndex == 4) //5-os
            {
                eredmeny_listbox.Items.Clear();
                lekerdezes_textbox.Enabled = true;

                conn = new MySqlConnection("server=localhost;username=root;database=autoverseny;port=3306;password=");
                conn.Open();
                string sql_query_3 = "SELECT csapat.nev, versenyzo.nev FROM csapat INNER JOIN versenyzo ON csapat.id = versenyzo.csapatid WHERE csapat.nev LIKE '%z%'ORDER BY csapat.nev ASC";
                MySqlDataReader query3reader = new MySqlCommand(sql_query_3, conn).ExecuteReader();
                Console.WriteLine("5. feladat: ");
                while (query3reader.Read())
                {
                    eredmeny_listbox.Items.Add(($"\t{query3reader[0]} - {query3reader[1]}"));
                }
                query3reader.Close();
                conn.Close();
                lekerdezes_textbox.Text = sql_query_3;
            }
            else if (feladatoklista_combobox.SelectedIndex == 5) //6-os
            {
                eredmeny_listbox.Items.Clear();
                lekerdezes_textbox.Enabled = true;

                conn = new MySqlConnection("server=localhost;username=root;database=autoverseny;port=3306;password=");
                conn.Open();
                string sql_query_4 = "SELECT palya.nev, versenyzo.nev, korido.korido FROM versenyzo INNER JOIN korido ON korido.versenyzoid=versenyzo.id INNER JOIN palya ON korido.palyaid=palya.id WHERE palya.orszag LIKE 'Olaszország' ORDER BY korido.korido ASC";
                MySqlDataReader query4reader = new MySqlCommand(sql_query_4, conn).ExecuteReader();
                Console.WriteLine("6. feladat: ");
                while (query4reader.Read())
                {
                    eredmeny_listbox.Items.Add(($"\t{query4reader[0]} - {query4reader[1]} - {query4reader[2]}"));
                }
                query4reader.Close();
                conn.Close();
                lekerdezes_textbox.Text = sql_query_4;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] feladatok =
{
                "1-es feladat",
                "2-es feladat",
                "3-as feladat",
                "4-es feladat",
                "5-ös feladat",
                "6-os feladat"
            };
            feladatoklista_combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            feladatoklista_combobox.Items.AddRange(feladatok);

            //database
            MySqlConnection conn = new MySqlConnection("server=localhost;username=root;port=3306;password=");
            conn.Open();
            new MySqlCommand(sql_drop_database, conn).ExecuteNonQuery();
            new MySqlCommand(sql_create_database, conn).ExecuteNonQuery();
            conn.Close();

            //connection
            conn = new MySqlConnection("server=localhost;username=root;database=autoverseny;port=3306;password=");
            conn.Open();

            ////table csapat
            //new MySqlCommand(sql_create_table_csapat, conn).ExecuteNonQuery();

            ////table palya
            //new MySqlCommand(sql_create_table_palya, conn).ExecuteNonQuery();

            ////table versenyzo 
            //new MySqlCommand(sql_create_table_versenyzo, conn).ExecuteNonQuery();

            ////table korido
            //new MySqlCommand(sql_create_table_korido, conn).ExecuteNonQuery();

            conn.Close();
        }
    }
}