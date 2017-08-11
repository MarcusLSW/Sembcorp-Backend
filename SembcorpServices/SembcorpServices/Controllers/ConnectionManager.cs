using System.IO;

namespace SembcorpServices.Controllers
{
    public class ConnectionManager
    {
        private static string PropFile = Directory.GetCurrentDirectory() + "ConnectionManager.resx";
        private static string Host = "127.0.0.1";
        private static string Name = "test";
        private static string Password = "";
        //private static string Port = "3306";
        private static string User = "root";

        public static MySql.Data.MySqlClient.MySqlConnection GetConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string connString = "server=" + Host + ";uid=" + User + ";pwd=" + Password + ";database=" + Name;


            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = connString;
            conn.Open();

            return conn;
        }
    }
}