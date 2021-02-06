using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace OutlawHessDB
{
    public partial class MainMenu : Form
    {
        Login login = new Login();
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daLogin;
        DataTable dtLogin;

        public MainMenu(int userIDCheck)
        {
            InitializeComponent();
            userID = userIDCheck;
            lblUserID.Text = "User logged in: " + userID;
        }

        int userID = 0;
        bool manager;

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            loginDetails();

            foreach(DataRow row in dtLogin.Rows)
            {
                if (row["isloggedin"].ToString() == "yes")
                {
                    if (row["role"].ToString() == "manager")
                    {
                        btnManageStaff.Visible = true;
                        btnManageStaff.Enabled = true;
                    }
                    else
                    {
                        btnManageStaff.Visible = false;
                        btnManageStaff.Enabled = false;
                    }
                }
            }            
        }

        private void loginDetails()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlQuery = @"SELECT * FROM users";

                daLogin = new SQLiteDataAdapter(sqlQuery, conn);
                dtLogin = new DataTable();
                daLogin.Fill(dtLogin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Form NewForm = new AllCustomers();
            NewForm.Show();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE users Set isloggedin = @isloggedin Where userId = @userID";
                cmd.Parameters.AddWithValue("isloggedin", "no");
                cmd.Parameters.AddWithValue("userID", userID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Application.Exit();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            using (SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE users Set isloggedin = @isloggedin Where userId = @userID";
                cmd.Parameters.AddWithValue("isloggedin", "no");
                cmd.Parameters.AddWithValue("userID", userID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            Form form = new Login();
            form.Show();
            this.Dispose();
        }
    }
}

