using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;

namespace _2_csharp_mysql
{
    class CentrumConsole
    {
        const string dbName = "centrum";
        const string conStr = $"server=localhost;user=root;database={dbName};port=3306;password=";
        static MySqlConnection con = new MySqlConnection(conStr);
        static void Main(string[] args)
        {
            string[] queries =
            {
                "SELECT id, kezdet, veg, dij FROM kezeles",
                "SELECT nev, kerulet FROM gazda WHERE kerulet = 17 OR kerulet = 10 ORDER BY kerulet, nev",
                "SELECT kezelestipus.jelleg, COUNT(kezeles.kezelestipusId) FROM kezeles INNER JOIN kez,elestipus ON kezeles.kezelestipusId = kezelestipus.id GROUP BY    kezeles.kezelestipusId ORDER BY kezelestipus.jelleg",
                "SELECT kezelestipus.jelleg, COUNT(kezeles.kezelestipusId) FROM kezeles INNER JOIN kezelestipus ON kezeles.kezelestipusId = kezelestipus.id GROUP BY    kezeles.kezelestipusId ORDER BY kezelestipus.jelleg",
                "SELECT kezelestipus.jelleg, COUNT(kezeles.kezelestipusId) FROM kezeles INNER JOIN kezelestipus ON kezeles.kezelestipusId = kezelestipus.id GROUP BY    kezeles.kezelestipusId ORDER BY kezelestipus.jelleg"

            };
            DatabaseCreation();
            ImportTablesAndData("tablak.sql", "adatok.sql");
            con.Open();
            MySqlCommand feladat3 = new MySqlCommand(queries[0], con);
            MySqlDataReader reader = feladat3.ExecuteReader();
            ColorPrint("3.feladat");
            while (reader.Read())
            {
                Console.WriteLine($"KezelésID : {reader[0]} - KezelésKezdet: {reader[1]} - KezelésVég: {reader[2]} - KezelésDíj: {reader[3]}");
            }
            reader.Close();

            ColorPrint("4.feladat");
            MySqlCommand feladat4 = new MySqlCommand(queries[1], con);
            reader = feladat4.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"GazdaNév: {reader[0]} - GazdaKerület: {reader[1]}" +
                    $"");
            }
            reader.Close();

        }
        private static void DatabaseCreation()
        {
            const string checkerSql = $"SELECT COUNT(SCHEMA_NAME) FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME= '{dbName}';";
            const string dropSql = $"DROP DATABASE {dbName};";
            const string creationSql = $"CREATE DATABASE {dbName} DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;";
            bool needCreation = false;
            MySqlCommand cmd = new MySqlCommand(checkerSql, con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader[0].ToString() == "0")
                {
                    needCreation = true;
                }
            }
            reader.Close();
            if (needCreation)
            {
                Debug.WriteLine("Adatbázis nem létezik...");
                MySqlCommand cmd2 = new MySqlCommand(creationSql, con);
                cmd2.ExecuteNonQuery();
                Debug.WriteLine("Adatbázis létrehozva...");
            }
            else
            {
                Debug.WriteLine("Van ilyen adatbázis, törlöm...");
                MySqlCommand drop = new MySqlCommand(dropSql, con);
                MySqlCommand cmd2 = new MySqlCommand(creationSql, con);
                drop.ExecuteNonQuery();
                Debug.WriteLine("Törölöve...");
                cmd2.ExecuteNonQuery();
                Debug.WriteLine("Újra létrehozva...");
            }
            con.Close();
        }
        private static void ImportTablesAndData(string _fTables, string _fData)
        {
            string tables = File.ReadAllText(_fTables);
            string data = File.ReadAllText(_fData);

            MySqlCommand tableLoader = new MySqlCommand(tables, con);
            MySqlCommand dataLoader = new MySqlCommand(data, con);

            con.Open();
            tableLoader.ExecuteNonQuery();
            dataLoader.ExecuteNonQuery();
            con.Close();
        }
        private static void ColorPrint(string _out)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(_out);
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
