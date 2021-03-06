﻿using System;
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
        //global variables and class call
        string loadCommand;
        string[] custArray = new string[9];
        int count = 0;
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        AllCustomers allCustomers = new AllCustomers();      //allows AllCustomers to be called when closing the form

        public CustomerDetailsForm(string loadFunction, string[] customerArray)
        {
            InitializeComponent();
            loadCommand = loadFunction;     //on form initialisation, sets loadCommand equal to loadFunction, resets count to 0
            count = 0;
            foreach (string item in customerArray)      //populates custArray based on customerArray for use in form. Count increase each iteration to match array index that is to be read
            {
                custArray[count] = customerArray[count];
                count++;
            }
        }

        private void CustomerDetails_Load(object sender, EventArgs e)       //sets values of textboxes based on pulled loadCommand
        {
            if (loadCommand == "add")
            {
                txtCustID.Text = "TBA";
                txtCustTitle.Text = null;
                txtCustFirstName.Text = null;
                txtCustLastName.Text = null;
                mtxtCustDOB.Text = null;
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
                mtxtCustDOB.Text = custArray[4];
                txtCustNICode.Text = custArray[5];
                txtCustEmailAddress.Text = custArray[6];
                txtCustPassword.Text = custArray[7];
                txtCustAllowance.Text = custArray[8];
            }

            dbConnection.dbconnStatus(conn);        //lines 64 - 82, see lines 33 - 62 of login.cs. Try catch statement only validates the connection, does not pull data from database
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
            if (string.IsNullOrWhiteSpace(txtCustTitle.Text) || string.IsNullOrWhiteSpace(txtCustFirstName.Text) || string.IsNullOrWhiteSpace(txtCustLastName.Text) || string.IsNullOrWhiteSpace(mtxtCustDOB.Text) ||
                string.IsNullOrWhiteSpace(txtCustNICode.Text) || string.IsNullOrWhiteSpace(txtCustEmailAddress.Text) || string.IsNullOrWhiteSpace(txtCustPassword.Text) || string.IsNullOrWhiteSpace(txtCustAllowance.Text))
                //lines 87 - 88 validates that there is data in the textboxes
            {
                MessageBox.Show("Please fill all the fields with correct information");
                return;
            }
            if(DateTime.TryParse(mtxtCustDOB.Text, out DateTime format) != true)    //validates the masked textbox data is in the correct data format and is an acceptable data
            {
                MessageBox.Show("Please enter a date in the correct format (DD/MM/YYYY)");
                return;
            }
            if(int.TryParse(txtCustAllowance.Text, out int result) == false)        //validates the allowance field in a number
            {
                MessageBox.Show("Please only use numbers in the 'Allowance' field");
                return;
            }
            if (loadCommand == "add")
            {
                using (SQLiteCommand cmd = conn.CreateCommand())        //if line 104 is true, runs command to add a customer by opening a connection, running the query and closing the connection
                {
                    cmd.CommandText = @"Insert into customer(title, firstname, lastname, dob, nicode, email, password, allowance) values (@title, @firstName, @lastName, @dob, @niCode, @email, @password, @allowance)";
                    cmd.Parameters.AddWithValue("title", txtCustTitle.Text);
                    cmd.Parameters.AddWithValue("firstName", txtCustFirstName.Text);
                    cmd.Parameters.AddWithValue("lastName", txtCustLastName.Text);
                    cmd.Parameters.AddWithValue("dob", mtxtCustDOB.Text);
                    cmd.Parameters.AddWithValue("niCode", txtCustNICode.Text);
                    cmd.Parameters.AddWithValue("email", txtCustEmailAddress.Text);
                    cmd.Parameters.AddWithValue("password", txtCustPassword.Text);
                    cmd.Parameters.AddWithValue("allowance", txtCustAllowance.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                DialogResult = MessageBox.Show("Customer details have been added", "Customer Details", MessageBoxButtons.OK);       //opens message and then, on DialogResult, shows allCustomer form and disposes this form
                if (DialogResult == DialogResult.OK)
                {
                    allCustomers.Show();
                    this.Dispose();
                }
            }
            else if (loadCommand == "update")
            {
                using (SQLiteCommand cmd = conn.CreateCommand())        //if line 130 is true, runs command to updates a customer by opening a connection, running the query and closing the connection
                {
                    cmd.CommandText = @"UPDATE customer Set title = @title, firstname = @firstName, lastname = @lastName, dob = @dob,
                    nicode = @niCode, email = @email, password = @password, allowance = @allowance Where custid = @custID";
                    cmd.Parameters.AddWithValue("title", txtCustTitle.Text);
                    cmd.Parameters.AddWithValue("firstName", txtCustFirstName.Text);
                    cmd.Parameters.AddWithValue("lastName", txtCustLastName.Text);
                    cmd.Parameters.AddWithValue("dob", mtxtCustDOB.Text);
                    cmd.Parameters.AddWithValue("niCode", txtCustNICode.Text);
                    cmd.Parameters.AddWithValue("email", txtCustEmailAddress.Text);
                    cmd.Parameters.AddWithValue("password", txtCustPassword.Text);
                    cmd.Parameters.AddWithValue("allowance", txtCustAllowance.Text);
                    cmd.Parameters.AddWithValue("custID", txtCustID.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

                DialogResult = MessageBox.Show("Customer details have been updated", "Customer Details", MessageBoxButtons.OK);     //opens message and then, on DialogResult, shows allCustomer form and disposes this form
                if (DialogResult == DialogResult.OK)
                {
                    allCustomers.Show();
                    this.Dispose();
                }
            }
        }

        private void btnCancelCustDetails_Click(object sender, EventArgs e)
        {
            this.Dispose();     //disposes this form
        }
    }
}