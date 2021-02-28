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
    public partial class PasswordHelp : Form
    {
        public PasswordHelp()
        {
            InitializeComponent();
        }

        //global variables
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn; 
        SQLiteDataAdapter daPasswordHelp;
        DataTable dtPasswordHelp;

        private void PasswordHelp_Load(object sender, EventArgs e)
        {
            //lines 31 - 40 set the starting state of the respective controls
            txtEmployeeID = null;
            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtDOB.Text = null;
            lblDetails.Text = null;
            lblDetails.Visible = false;
            txtNewPassword.Visible = false;
            btnConfirmPassword.Visible = false;
            lblNewPassword.Visible = false;
            btnConfirmPassword.Enabled = false;

            dbConnection.dbconnStatus(conn);        //Lines 42 - 71, see login.cs lines 33 - 62
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
        }

        private void loginDetails()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlQuery = @"SELECT * FROM users";

                daPasswordHelp = new SQLiteDataAdapter(sqlQuery, conn);
                dtPasswordHelp = new DataTable();
                daPasswordHelp.Fill(dtPasswordHelp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   //see line 42 for additional details
        }

        private void btnPasswordResetSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtEmployeeID.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtDOB.Text))
            {
                lblDetails.Text = "Please fill out all the boxes with the correct details";     //if above statement is true on any account, message box appears
            }
            else
            {
                foreach (DataRow row in dtPasswordHelp.Rows)        //if the statement is found to be false on all counts, foreach statement loops through datatable
                {
                    if (row["userID"].ToString() == txtEmployeeID.Text && row["firstname"].ToString() == txtFirstName.Text && row["lastname"].ToString() == txtLastName.Text && row["dob"].ToString() == txtDOB.Text)
                    {
                        lblDetails.Text = "Your details are correct";       //if line 83 statement is true, displays text in label and shows several hidden items and enables a button and breaks loop
                        txtNewPassword.Visible = true;
                        btnConfirmPassword.Visible = true;
                        lblNewPassword.Visible = true;
                        btnConfirmPassword.Enabled = true;
                        break;
                    }
                    else
                    {
                        lblDetails.Text = "Your details are incorrect, try again or contact your supervisor";   //if line 83 statement false label displays text and text boxes clear
                        txtEmployeeID.Text = null;
                        txtFirstName.Text = null;
                        txtLastName.Text = null;
                        txtDOB.Text = null;
                    }
                }
            }

            lblDetails.Visible = true;      //shows the label once an outcome has been reached
        }

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            using(SQLiteCommand cmd = conn.CreateCommand())     //When button click event occurs, sets variables for SQL command and runs the SQL code to update the specific database table
            {
                cmd.CommandText = @"UPDATE users Set password = @newPassword Where userID = @employeeID";
                cmd.Parameters.AddWithValue("newPassword", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("employeeID", txtEmployeeID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            DialogResult = MessageBox.Show("Your password has been updated", "Password Updated", MessageBoxButtons.OK);     //when SQL command has been run, message box appears confirming this
            if(DialogResult == DialogResult.OK)     //clicking dialog button shows login form and disposes this form
            {
                Form form = new Login();
                form.Show();
                this.Dispose();
            }
        }
    }
}
