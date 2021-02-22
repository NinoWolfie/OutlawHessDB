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
        //Global Variables and class call
        Login login = new Login();
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daLogin;
        DataTable dtLogin;
        int userID = 0;

        public MainMenu(int userIDCheck)
        {
            InitializeComponent();
            userID = userIDCheck;           //Pulls userID from login.cs and diplays it
            lblUserID.Text = "User logged in: " + userID;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);        //Lines 34 - 45 & 64 - 79, see login.cs lines 33 - 62
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            loginDetailsMainMenu();

            foreach(DataRow row in dtLogin.Rows)      //set to break if either statement is true  
            {
                if (row["role"].ToString() == "manager" && row["userid"].ToString() == userID.ToString())
                {
                    btnManageStaff.Visible = true;      //if above statement is true, sets btnManageStaff to visible and enabled
                    btnManageStaff.Enabled = true;
                    break;
                }
                else if (row["role"].ToString() != "manager" && row["userid"].ToString() == userID.ToString())
                {
                    btnManageStaff.Visible = false;     //if else if statement is false, sets btnManageStaff to not visible or enabled
                    btnManageStaff.Enabled = false;
                    break;
                }
            }            
        }

        private void loginDetailsMainMenu()
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

        private void btnCustomers_Click(object sender, EventArgs e)     //lines 81 - 109 use buttons to open specific forms
        {
            Form NewForm = new AllCustomers();
            NewForm.Show();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            Form NewForm = new Products();
            NewForm.Show();
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            Form form = new AllAccounts();
            form.Show();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            Form form = new Transactions();
            form.Show();
        }

        private void btnManageStaff_Click(object sender, EventArgs e)
        {
            Form form = new Management();
            form.Show();
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();     //closes application
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form form = new Login();    //closes this form and opens login form
            form.Show();
            this.Dispose();
        }
    }
}

