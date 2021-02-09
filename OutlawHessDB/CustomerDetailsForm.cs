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
    public partial class CustomerDetailsForm : Form
    {
        string loadCommand;
        string[] custArray = new string[9];
        int count = 0;

        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;

        bool managerCheck;

        public CustomerDetailsForm(string loadFunction, string[] customerArray)
        {
            InitializeComponent();
            loadCommand = loadFunction;
            count = 0;
            foreach (string item in customerArray)
            {
                custArray[count] = customerArray[count];
                count++;
            }
        }

        AllCustomers allCustomers;

        private void CustomerDetails_Load(object sender, EventArgs e)
        {
            if (loadCommand == "add")
            {
                txtCustID.Text = "TBA";
                txtCustTitle.Text = null;
                txtCustFirstName.Text = null;
                txtCustLastName.Text = null;
                txtCustDOB.Text = null;
                txtCustNICode.Text = null;
                txtCustEmailAddress.Text = null;
                txtCustPassword.Text = null;
                txtCustAllowance.Text = null;
            }
            else if (loadCommand == "update")
            {
                txtCustID.Text = custArray[0];
                txtCustTitle.Text = custArray[1];
                txtCustFirstName.Text = custArray[2];
                txtCustLastName.Text = custArray[3];
                txtCustDOB.Text = custArray[4];
                txtCustNICode.Text = custArray[5];
                txtCustEmailAddress.Text = custArray[6];
                txtCustPassword.Text = custArray[7];
                txtCustAllowance.Text = custArray[8];
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
            if (loadCommand == "add")
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Insert into customer(title, firstname, lastname, dob, nicode, email, password, allowance) values (@title, @firstName, @lastName, @dob, @niCode, @email, @password, @allowance)";
                    cmd.Parameters.AddWithValue("title", txtCustTitle.Text);
                    cmd.Parameters.AddWithValue("firstName", txtCustFirstName.Text);
                    cmd.Parameters.AddWithValue("lastName", txtCustLastName.Text);
                    cmd.Parameters.AddWithValue("dob", txtCustDOB.Text);
                    cmd.Parameters.AddWithValue("niCode", txtCustNICode.Text);
                    cmd.Parameters.AddWithValue("email", txtCustEmailAddress.Text);
                    cmd.Parameters.AddWithValue("password", txtCustPassword.Text);
                    cmd.Parameters.AddWithValue("allowance", txtCustAllowance.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                DialogResult = MessageBox.Show("Customer details have been added", "Customer Details", MessageBoxButtons.OK);
                if (DialogResult == DialogResult.OK)
                {
                    Form form = new AllCustomers();
                    form.Show();
                    this.Dispose();
                }
            }
            else if (loadCommand == "update")
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE customer Set title = @title, firstname = @firstName, lastname = @lastName, dob = @dob,
                    nicode = @niCode, email = @email, password = @password, allowance = @allowance Where custid = @custID";
                    cmd.Parameters.AddWithValue("title", txtCustTitle.Text);
                    cmd.Parameters.AddWithValue("firstName", txtCustFirstName.Text);
                    cmd.Parameters.AddWithValue("lastName", txtCustLastName.Text);
                    cmd.Parameters.AddWithValue("dob", txtCustDOB.Text);
                    cmd.Parameters.AddWithValue("niCode", txtCustNICode.Text);
                    cmd.Parameters.AddWithValue("email", txtCustEmailAddress.Text);
                    cmd.Parameters.AddWithValue("password", txtCustPassword.Text);
                    cmd.Parameters.AddWithValue("allowance", txtCustAllowance.Text);
                    cmd.Parameters.AddWithValue("custID", txtCustID.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                DialogResult = MessageBox.Show("Customer details have been updated", "Customer Details", MessageBoxButtons.OK);
                if (DialogResult == DialogResult.OK)
                {
                    allCustomers.Show();
                    this.Dispose();
                }
            }
        }
    }
}