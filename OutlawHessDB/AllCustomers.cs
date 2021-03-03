
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
    public partial class AllCustomers : Form
    {
        public AllCustomers()
        {
            InitializeComponent();
        }

        //global variables
        dbConnection dbConnection = new dbConnection();
        MainMenu mainMenu;
        string ex;

        SQLiteConnection conn;
        SQLiteDataAdapter daCustomer;
        DataTable dtCustomer;

        string loadCommand;

        public string[] customerArray = new string[9];
        string custID;

        private void Form1_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);        //lines 38 - 69, see login.cs lines 33 - 62
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }
            showAllCustomers();
        }

        private void showAllCustomers()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM customer";

                daCustomer = new SQLiteDataAdapter(sqlCommand, conn);
                dtCustomer = new DataTable();
                daCustomer.Fill(dtCustomer);
                dgvCustomer.DataSource = dtCustomer;        //lines 61 - 63 populates and sets properties of dgvCustomer
                dgvCustomer.AutoResizeColumns();
                dgvCustomer.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   //see line 38 for additional details
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            loadCommand = "add";        //Lines 70 - 73 loads CustomerDetailsForm, passes loadCommand value to be used in the form and closes this form
            Form form = new CustomerDetailsForm(loadCommand, customerArray);
            form.Show();
            this.Dispose();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            loadCommand = "update";     //sets loadCommand value
            if (dgvCustomer.SelectedRows.Count == 0)        //validation that there is at least one row selected
            {
                MessageBox.Show("Please select a customer");        //if above statement is true, shows message box and end function execcution. Row is usually autoselected from the beginning but this is just a precaution
                return;
            }
            foreach (DataRow row in dtCustomer.Rows)        //runs through each row in table
            {
                if (dgvCustomer.SelectedCells[0].Value.ToString() == row["custid"].ToString())      //makes sure the custid of the selected row is equal to the custid of the current row in the foreach loop
                {
                    for (int i = 0; i < 9; i++)     //populates an array to be passed to customerDetailsForm, the number of indexes is equal to the number of columns in the customer table
                    {
                        customerArray[i] = dgvCustomer.SelectedCells[i].Value.ToString();
                    }
                }
            }
            Form form = new CustomerDetailsForm(loadCommand, customerArray);        //lines 97 - 99 loads new form, passes data through to the form and closes this form
            form.Show();
            this.Dispose();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 0)        //validation that there is at least one row selected
            {
                MessageBox.Show("Please select a customer");        //if above statement is true, shows message box and end function execcution. Row is usually autoselected from the beginning but this is just a precaution
                return;
            }
            DialogResult = MessageBox.Show("Are you sure you wish to delete the selected customer?", "Delete?", MessageBoxButtons.YesNo);  //Dialogresult function to allow for check before deleting selected record
            if(DialogResult == DialogResult.Yes)
            {
                foreach (DataRow row in dtCustomer.Rows)        //if statement above is true, loops through each row of table
                {
                    if (dgvCustomer.SelectedCells[0].Value.ToString() == row["custid"].ToString())      //check to see if selected dgvCustomer userid is the same as the table userid
                    {
                        using (SQLiteCommand cmd = conn.CreateCommand())        //if above is true, sets SQL query based on custid of table row in loop, opens connection, runs the query, closes the connection
                        {
                            cmd.CommandText = @"DELETE FROM customer Where custid = @custID";
                            cmd.Parameters.AddWithValue("custID", row["custid"].ToString());
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
                Form form = new AllCustomers();      //refresh() not working, using new form load
                form.Show();
                this.Dispose();
            }
            else     //if the statement is false, return without deleting
            {
                return;
            }
        }

        private void btnCustAccounts_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtCustomer.Rows)        //runs loop for each row in table
            {
                if (dgvCustomer.SelectedCells[0].Value.ToString() == row["custid"].ToString())      //checks if custid of selected row of dgvCustomer is equal to row custid
                {
                    custID = row["custid"].ToString();      //if true, sets custID to custid of row
                }
            }
            Form form = new CustomerAccounts(custID);       //lines 135 - 137, opens new CustomerAccounts form, passes custID through to new form and disposes this form
            form.Show();
            this.Dispose();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)      //closes this form if clicked
        {
            this.Dispose();
        }
    }
}