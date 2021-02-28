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
    public partial class UserDetailsForm : Form
    {
        //Global Variables
        string loadCommand;
        string[] userArray = new string[6];
        int count = 0;
        string userPassword;
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;

        public UserDetailsForm(string loadFunction, string[] userArrayPulled) //pulls data from management.cs
        {
            InitializeComponent();
            loadCommand = loadFunction;
            userArray = userArrayPulled;
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            if (loadCommand == "add")       //lines 34 - 51 set the value of the textbox boxes 
            {
                txtUserID.Text = "TBA";
                txtUserFirstName.Text = null;
                txtUserLastName.Text = null;
                txtUserPassword.Text = null;
                txtUserDOB.Text = null;
                txtUserRole.Text = null;
            }
            else if (loadCommand == "update")
            {
                txtUserID.Text = userArray[0];
                txtUserFirstName.Text = userArray[1];
                txtUserLastName.Text = userArray[2];
                txtUserPassword.Text = null;        //leaves blank for security
                userPassword = userArray[3].ToString();     //stores current password as variable to be used if needed
                txtUserDOB.Text = userArray[4];
                txtUserRole.Text = userArray[5];
            }

            dbConnection.dbconnStatus(conn);        //lines 54 - 72, see lines 33 - 62 of login.cs. Try catch statement only validates the connection, does not pull data from database
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            try
            {
                conn = new SQLiteConnection(dbConnection.source);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSubmitCustDetails_Click(object sender, EventArgs e)
        {
            if(loadCommand == "add")        //if statement to check the string value of loadCommand
            {
                if (string.IsNullOrWhiteSpace(txtUserFirstName.Text) || string.IsNullOrWhiteSpace(txtUserFirstName.Text) || string.IsNullOrWhiteSpace(txtUserPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtUserDOB.Text) || string.IsNullOrWhiteSpace(txtUserRole.Text))        //if above statement is true, if statement checks all fields are completed
                {
                    MessageBox.Show("Please complete all fields");      //message box shows if above is true and ends task
                    return;
                }
                using (SQLiteCommand cmd = conn.CreateCommand())    //lines 85 - 105 passes data to the database, shows a message box, shows management form, and closes this form
                {
                    cmd.CommandText = @"Insert into users(firstname, lastname, password, dob, role) values (@firstName, @lastName, @password, @dob, @role)";
                    cmd.Parameters.AddWithValue("firstname", txtUserFirstName.Text);
                    cmd.Parameters.AddWithValue("lastname", txtUserLastName.Text);
                    cmd.Parameters.AddWithValue("password", txtUserPassword.Text);
                    cmd.Parameters.AddWithValue("dob", txtUserDOB.Text);
                    cmd.Parameters.AddWithValue("role", txtUserRole.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                DialogResult = MessageBox.Show("User details have been added", "User Details", MessageBoxButtons.OK);
                if (DialogResult == DialogResult.OK)
                {
                    Form form = new Management();
                    form.Show();
                    this.Dispose();
                }
            }
            else if(loadCommand == "update")
            {
                if (string.IsNullOrWhiteSpace(txtUserFirstName.Text) || string.IsNullOrWhiteSpace(txtUserFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtUserDOB.Text) || string.IsNullOrWhiteSpace(txtUserRole.Text))        //if statement checks all fields are completed except password field
                {
                    MessageBox.Show("Please complete all fields");      //message box shows if above is true and ends task
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtUserPassword.Text))    //if this statement is true, sets stored password from database to password field if password is not being updated
                {
                    txtUserPassword.Text = userPassword;
                }
                using (SQLiteCommand cmd = conn.CreateCommand())    //Lines 118 - 138 passes data to database for updating details, shows a message box, shows management form, and closes this form
                {
                    cmd.CommandText = @"UPDATE users Set firstname = @firstName, lastname = @lastName, password = @password, dob = @dob, role = @role Where userid = @userid";
                    cmd.Parameters.AddWithValue("firstname", txtUserFirstName.Text);
                    cmd.Parameters.AddWithValue("lastname", txtUserLastName.Text);
                    cmd.Parameters.AddWithValue("password", txtUserPassword.Text);
                    cmd.Parameters.AddWithValue("dob", txtUserDOB.Text);
                    cmd.Parameters.AddWithValue("role", txtUserRole.Text);
                    cmd.Parameters.AddWithValue("userid", txtUserID.Text);

                    conn.Open();        //opens Connection to database
                    cmd.ExecuteNonQuery();      //executes query
                    conn.Close();       //closes connection to database
                }

                DialogResult = MessageBox.Show("User details have been updated", "User Details", MessageBoxButtons.OK);     //dialogResult shows message box, opens new Management Form and disposes of this form
                if (DialogResult == DialogResult.OK)
                {
                    Form form = new Management();
                    form.Show();
                    this.Dispose();
                }
            }
        }

        private void btnCancelCustDetails_Click(object sender, EventArgs e)     //closes the form if clicked
        {
            this.Dispose();
        }
    }
}
