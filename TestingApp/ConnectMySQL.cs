using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace TestingApp
{
        public class ConnectMySQL
        {
            private string databaseName = "getlistapp";
            public string DatabaseName
            {
                get { return databaseName; }
                set { databaseName = value; }
            }
            public string Password { get; set; }
            private MySqlConnection connection = null;
            public MySqlConnection Connection
            {
                get { return connection; }
            }
            private static ConnectMySQL _instance = null;
            public static ConnectMySQL Instance()
            {
                //if (_instance == null)
                _instance = new ConnectMySQL();
                return _instance;
            }
            public bool IsConnect()
            {
                if (Connection == null)
                {
                    if (String.IsNullOrEmpty(databaseName))
                        return false;
                    StringBuilder sb = new StringBuilder();
                    //string connstring = string.Format("Server=localhost; database={0}; UID=root; password=", databaseName);
                    string connstring = string.Format("Server=localhost; database={0}; UID=root; password=123456; SslMode = none;Allow User Variables=True;Character Set=UTF8", databaseName);
                    //string connstring = string.Format("Server=" + ip_DBServer + "; database={0}; UID=" + usser_DBServer + "; password=" + pass_DBServer + "; SslMode = none;Allow User Variables=True;Character Set=UTF8", databaseName);
                    //string connstring = string.Format("Server=192.168.3.156; database={0}; UID=uspc; password=uspc; SslMode = none;Allow User Variables=True;Character Set=UTF8", databaseName);
                    // string connectionString = "User Id=root;Host=localhost;Database=doan2011;Persist Security Info=True;Character Set=UTF8"
                    connection = new MySqlConnection(connstring);
                    connection.Open();
                }
                return true;
            }
            public void Close()
            {
                connection.Close();
                connection.Dispose();
            }
        }
 }

