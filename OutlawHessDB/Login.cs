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

        //global variables and class call
        int userID = 0;
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daLogin;
        DataTable dtLogin;
        bool manager;
        bool isLoggedIn;

        private void Login_Load(object sender, EventArgs e)     //lines 33 - 62 are used multiple times through the application. Those other uses will be referred back to here -
        {                                                           // - with specific differences commented on the specific function, da and dt variables will reflect the function and will not be mentioned 
            dbConnection.dbconnStatus(conn);    //runs function to check and establish a connection to the database being used in dbconnection.cs
            if(dbConnection.connStatus == true)     //if statement that checks the connection status and sets the status image based on the status
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if(dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);    //message show if false, message is connection error
            }

            loginDetails();     //runs function, this will be named differently or be multiple of similar based on the needs of the form
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
            if (string.IsNullOrWhiteSpace(txtEmployeeNumber.Text) == false)     //lines 66-68, validation of the textbox for employee name and password
            {
                if(string.IsNullOrWhiteSpace(txtPassword.Text) == false)
                {
                    foreach (DataRow row in dtLogin.Rows)       //runs through each row of the selected table
                    {
                        if (row["userID"].ToString() == txtEmployeeNumber.Text)     //lines 73-75, checks the employee number, stores that, then checks the password relating to that id
                        {
                            userID = int.Parse(txtEmployeeNumber.Text);
                            if (row["password"].ToString() == txtPassword.Text)
                            {
                                Form NewForm = new MainMenu(userID);        //if both userid and password are correct, lines 77 - 83 opens main menu, hides login and clears textboxes and breaks for each loop
                                NewForm.Show();
                                this.Hide();
                                txtEmployeeNumber.Text = null;
                                txtPassword.Text = null;
                                isLoggedIn = true;
                                break;
                            }
                            else
                            {
                                MessageBox.Show("Password incorrect");     //if incorrect password incorrect, shows message box and clears textboxes
                                txtEmployeeNumber.Text = null;
                                txtPassword.Text = null;
                            }
                        }
                    }
                    if (isLoggedIn == false)
                    {
                        MessageBox.Show("User does not exits");     //if userid does not exist, shows message box and clears textboxes
                        txtEmployeeNumber.Text = null;
                        txtPassword.Text = null;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a password");     //if password is left blank, message box is shown and function is ended
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter your employee number");       //if employee number is left blank, message box is shown and function is ended
                return;
            }
        }

        private void btnPasswordHelp_Click(object sender, EventArgs e)
        {
            Form NewForm = new PasswordHelp();      //when password help button is clicked, opens new form and hides login form
            NewForm.Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();     //due to some windows staying open when form close button is clicked, added this to each page that seems to fail to close the 
                                    //application as intended when close button is used
        }
    }
}
