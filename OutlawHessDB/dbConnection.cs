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
        public static string source = @"Data Source = ..\bandits.db";       //sets location of database file in project folder

        //variables
        public bool connStatus;     //used to confirm connection visually in forms
        public string exception;        //used to pass error message to forms if needed

        public void dbconnStatus(SQLiteConnection conn)
        {
            exception = null;       //clears exception

            try       //try catch to create and check connection to database and sets connection status
            {
                conn = new SQLiteConnection();
                conn.ConnectionString = dbConnection.source;
                conn.Open();

                if (conn.State == System.Data.ConnectionState.Open)
                    connStatus = true;

            }
            catch (Exception ex)        //catch will set exception value to error that has occured if an error occurs
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
                connStatus = false;
                exception = ex.ToString();
            }
        }
    }
}
