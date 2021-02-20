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

        //global variables
        int userID = 0;
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daLogin;
        DataTable dtLogin;
        bool manager;

        private void Login_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);    //runs function to check and establish a connection to the database being used
            if(dbConnection.connStatus == true)     //if statement that checks the connection status and sets the status image based on the status
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if(dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);    //message show if false, message is connection error
            }

            loginDetails();     //runs function
        }

        private void loginDetails()
        {
            try      //try/catch statement to pull data from the connected database, error displayed if failure occurs
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
            if (string.IsNullOrWhiteSpace(txtEmployeeNumber.Text) == false)     //lines 65-67, validation of the textbox for employee name and password
            {
                if(string.IsNullOrWhiteSpace(txtPassword.Text) == false)
                {
                    foreach (DataRow row in dtLogin.Rows)       //runs through each row of the selected table
                    {
                        if (row["userID"].ToString() == txtEmployeeNumber.Text)     //lines 71-74, checks the employee number, stores that, then checks the password relating to that id
                        {
                            userID = int.Parse(txtEmployeeNumber.Text);
                            if (row["password"].ToString() == txtPassword.Text)
                            {
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

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
