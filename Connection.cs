using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace UploadFile
{
    public class Connection
    {
        public static void Npgsql()
        {
            using (NpgsqlConnection con = new NpgsqlConnection())

            {
                string query = @"insert into public.Students(Name,Fees)values('Gautam',200.0)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                con.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Record Inserted");
                }

            }
        }
        public class dbSqliteConnection
        {
            public static string dbAddress = @"Data Source=" + "C:/Dr/....;New=False;Compress=True;Read Only=False";
            public static string ConnectionStatus;
            public static void Sqlite()
            {
                using (SqliteConnection conn = new SQLiteConnection(dbAddress))
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        try
                        {
                            conn.Open();
                            ConnectionStatus = "SQLite Connection successful";
                        }
                        catch (Exception)
                        {
                            ConnectionStatus = "SQLite Connection failed";
                        }
                    }
                    else
                    {
                        ConnectionStatus = "SQLite Connection successful";
                    }
                }

            }
        }

        public static void Firebase()
        {
            IFirebaseClient client;
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "",
                BasePath = ""
            };
        private object serial;
    }
    }
}
