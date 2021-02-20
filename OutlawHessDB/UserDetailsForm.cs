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
        string loadCommand;
        string[] userArray = new string[6];
        int count = 0;

        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;

        public UserDetailsForm(string loadFunction, string[] userArray)
        {
            InitializeComponent();
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            if (loadCommand == "add")
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
                txtUserPassword.Text = userArray[3];
                txtUserDOB.Text = userArray[4];
                txtUserRole.Text = userArray[5];
            }

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
            if(loadCommand == "add")
            {
                if (string.IsNullOrWhiteSpace(txtUserPassword.Text))
                {
                    MessageBox.Show("Please enter a password");
                    return;
                }
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Insert into customer(firstname, lastname, password, role, dob) values (@firstName, @lastName, @password, @dob, @role)";
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
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE customer Set firstname = @firstName, lastname = @lastName, password = @password, dob = @dob, role = @role Where userid = @userid";
                    cmd.Parameters.AddWithValue("firstname", txtUserFirstName.Text);
                    cmd.Parameters.AddWithValue("lastname", txtUserLastName.Text);
                    cmd.Parameters.AddWithValue("password", txtUserPassword.Text);
                    cmd.Parameters.AddWithValue("dob", txtUserDOB.Text);
                    cmd.Parameters.AddWithValue("role", txtUserRole.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                DialogResult = MessageBox.Show("User details have been updated", "User Details", MessageBoxButtons.OK);
                if (DialogResult == DialogResult.OK)
                {
                    Form form = new Management();
                    form.Show();
                    this.Dispose();
                }
            }
        }

        private void btnCancelCustDetails_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
