using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroClubController
{
    public class DBManager
    {
        private static DBManager dbManager;
        private MySqlConnection con;
        private const String host = "prog3-labs-1inf30.cmuvappclf8y.us-east-1.rds.amazonaws.com";
        private const String port = "3306";
        private const String db = "laboratorio4";
        private const String username = "admin";
        private const String password = "20211023";
		
		private DBManager() { }

        public MySqlConnection Connection
        {
            get
            {
                if (con == null)
                {
                    string cadenaConexion = $"server={host};database={db};user={username};password={password};port={port}";
                    con = new MySqlConnection(cadenaConexion);
                }
                con.Open();
                return con;
            }
        }

        public static DBManager Instance {
            get { 
                if (dbManager == null)
                    dbManager = new DBManager();
                return dbManager; 
            }
        }
    }
}
