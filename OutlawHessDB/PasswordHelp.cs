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

        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn; 
        SQLiteDataAdapter daPasswordHelp;
        DataTable dtPasswordHelp;

        private void PasswordHelp_Load(object sender, EventArgs e)
        {
            txtFirstName.Text = null;
            txtLastName.Text = null;
            txtDOB.Text = null;
            lblDetails.Text = null;
            lblDetails.Visible = false;
            txtNewPassword.Visible = false;
            btnConfirmPassword.Visible = false;
            lblNewPassword.Visible = false;
            btnConfirmPassword.Enabled = false;

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
            }
        }

        private void btnPasswordResetSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtEmployeeID.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtDOB.Text))
            {
                lblDetails.Text = "Please fill out all the boxes with the correct details";
            }
            else
            {
                foreach (DataRow row in dtPasswordHelp.Rows)
                {
                    if (row["userID"].ToString() == txtEmployeeID.Text && row["firstname"].ToString() == txtFirstName.Text && row["lastname"].ToString() == txtLastName.Text && row["dob"].ToString() == txtDOB.Text)
                    {
                        lblDetails.Text = "Your details are correct";
                        txtNewPassword.Visible = true;
                        btnConfirmPassword.Visible = true;
                        lblNewPassword.Visible = true;
                        btnConfirmPassword.Enabled = true;
                    }
                    else
                    {
                        lblDetails.Text = "Your details are incorrect, try again or contact your supervisor";
                        txtFirstName.Text = null;
                        txtLastName.Text = null;
                        txtDOB.Text = null;
                    }
                }
            }

            lblDetails.Visible = true;
        }

        private void btnConfirmPassword_Click(object sender, EventArgs e)
        {
            using(SQLiteCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"UPDATE users Set password = @newPassword Where userID = @employeeID";
                cmd.Parameters.AddWithValue("newPassword", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("employeeID", txtEmployeeID.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            DialogResult = MessageBox.Show("Your password has been updated", "Password Updated", MessageBoxButtons.OK);
            if(DialogResult == DialogResult.OK)
            {
                Form form = new Login();
                form.Show();
                this.Dispose();
            }
        }
    }
}
