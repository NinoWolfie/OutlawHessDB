using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace OutlawHessDB
{
    class dbConnection
    {
        public static string source = @"Data Source = ..\bandits.db";

        public bool connStatus;
        public string exception;

        public void dbconnStatus(SQLiteConnection conn)
        {
            exception = null;

            try
            {
                conn = new SQLiteConnection();
                conn.ConnectionString = dbConnection.source;
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    connStatus = true;

            }
            catch (Exception ex)
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                connStatus = false;
                exception = ex.ToString();
            }
        }
    }
}
