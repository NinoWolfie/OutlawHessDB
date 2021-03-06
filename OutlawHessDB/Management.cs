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
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        //global veriables and class call
        dbConnection dbConnection = new dbConnection();
        MainMenu mainMenu;
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daUsers;
        DataTable dtUsers;

        string loadCommand;

        public string[] userArray = new string[6];

        private void Management_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);        //lines 35 - 66, see login.cs lines 33 - 62
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }
            showAllUsers();
        }

        private void showAllUsers()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM users";

                daUsers = new SQLiteDataAdapter(sqlCommand, conn);
                dtUsers = new DataTable();
                daUsers.Fill(dtUsers);
                dgvUsers.DataSource = dtUsers;      //line 58 - 60 populates dgvUsers
                dgvUsers.AutoResizeColumns();
                dgvUsers.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   //see line 35 for additional details
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            loadCommand = "add";        //Lines 70 - 73 loads userDetailsForm, passes loadCommand value to be used in the form and closes this form
            Form form = new UserDetailsForm(loadCommand, userArray);
            form.Show();
            this.Dispose();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            loadCommand = "update";     //sets loadCommand value
            if (dgvUsers.SelectedRows.Count == 0)        //validation that there is at least one row selected
            {
                MessageBox.Show("Please select a customer");        //if above statement is true, shows message box and end function execcution. Row is usually autoselected from the beginning but this is just a precaution
                return;
            }
            foreach (DataRow row in dtUsers.Rows)   //runs through each row in users table in database
            {
                if (dgvUsers.SelectedCells[0].Value.ToString() == row["userid"].ToString())     //makes sure the userid of the selected row is equal to the userid of the current row in the foreach loop
                {
                    for (int i = 0; i < 6; i++)     //populates an array to be passed to UserDetailsForm, the number of indexes is equal to the number of columns in the users table
                    {
                        userArray[i] = dgvUsers.SelectedCells[i].Value.ToString();
                    }
                }
            }
            Form form = new UserDetailsForm(loadCommand, userArray);        //lines 94 - 96 opens UserDetailsForm, passes data through, and closes this form
            form.Show();
            this.Dispose();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you wish to delete the selected user?", "Delete?", MessageBoxButtons.YesNo);  //Dialogresult function to allow for check before deleting selected record
            if (DialogResult == DialogResult.Yes)
            {
                foreach (DataRow row in dtUsers.Rows)       //if above statement is true, runs through each row in users table in database
                {
                    if (dgvUsers.SelectedCells[0].Value.ToString() == row["userid"].ToString())     //makes sure the userid of the selected row is equal to the userid of the current row in the foreach loop
                    {
                        using (SQLiteCommand cmd = conn.CreateCommand())        //runs command to delete a user by opening a connection, running the query and closing the connection
                        {
                            cmd.CommandText = @"DELETE FROM users Where userID = @userID";      //sets SQL Query
                            cmd.Parameters.AddWithValue("userID", row["userID"].ToString());        //Defines values form SQL query
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                Form form = new Management();      //refresh() not working, using new form load
                form.Show();
                this.Dispose();
            }
            else     //if the statement is false, return without deleting
            {
                return;
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)      //closes this form if clicked
        {
            this.Dispose();
        }
    }
}
