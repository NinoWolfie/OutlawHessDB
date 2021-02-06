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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        int userID = 0;
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daLogin;
        DataTable dtLogin;
        bool manager;

        private void Login_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);
            if(dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if(dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            loginDetails();
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeNumber.Text) == false)
            {
                if(string.IsNullOrWhiteSpace(txtPassword.Text) == false)
                {
                    foreach (DataRow row in dtLogin.Rows)
                    {
                        if (row["userID"].ToString() == txtEmployeeNumber.Text)
                        {
                            userID = int.Parse(txtEmployeeNumber.Text);
                            if (row["password"].ToString() == txtPassword.Text)
                            {
                                if(row["role"].ToString() == "manager")
                                {
                                    manager = true;
                                }
                                else
                                {
                                    manager = false;
                                }
                                using (SQLiteCommand cmd = conn.CreateCommand())
                                {
                                    cmd.CommandText = @"UPDATE users Set isloggedin = @isloggedin Where userId = @userID";
                                    cmd.Parameters.AddWithValue("isloggedin", "Yes");
                                    cmd.Parameters.AddWithValue("userID", txtEmployeeNumber.Text);

                                    conn.Open();
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                Form NewForm = new MainMenu(userID);
                                NewForm.Show();
                                this.Hide();
                                txtEmployeeNumber.Text = null;
                                txtPassword.Text = null;
                            }
                            else
                            {
                                MessageBox.Show("login incorrect");
                            }
                        }
                        else
                        {
                            MessageBox.Show("user does not exits");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a password");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter your employee number");
                return;
            }
        }

        private void btnPasswordHelp_Click(object sender, EventArgs e)
        {
            Form NewForm = new PasswordHelp();
            NewForm.Show();
            this.Hide();
        }
    }
}
