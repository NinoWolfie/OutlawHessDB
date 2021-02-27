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
    public partial class CustomerAccounts : Form
    {
        public CustomerAccounts(string custID)
        {
            InitializeComponent();
            custIDCheck = custID;       //sets value of custIDCheck based on passed custID
        }

        //Global Variables and class call
        string custIDCheck;
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daAccounts;
        SQLiteDataAdapter daProducts;
        SQLiteDataAdapter daCustomers;
        DataTable dtAccounts;
        DataTable dtProducts;
        DataTable dtCustomers;

        private void CustomerAccounts_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);        //lines 36 - 122, see lines 33 - 62 of login.cs, extra functions execute the same
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            accountDetails();
            productDetails();
            customerDetails();

            foreach (DataRow rowAccounts in dtAccounts.Rows)        //iterates through each line of the Accounts table
            {
                if(custIDCheck == rowAccounts["custid"].ToString())     //checks custIDCheck is equal to custid in account table
                {
                    foreach (DataRow rowCustomers in dtCustomers.Rows)      //if above statement is true, iterates through customer table
                    {
                        if (custIDCheck == rowCustomers["custid"].ToString())       //checks custIDCheck is equal to custid in customers table 
                        {
                            lblCustAccount.Text = rowCustomers["title"].ToString() + " " + rowCustomers["firstname"].ToString() + " " + rowCustomers["lastname"].ToString();
                            //line 59 shows customer name based on values from the customers table
                            foreach (DataRow rowProducts in dtProducts.Rows)        //iterates through product table
                            {
                                if (rowAccounts["prodid"].ToString() == rowProducts["prodid"].ToString())       //checks to see if prodid in accounts table row is equal to current product table row prodid value
                                {
                                    lbxCustAccounts.Items.Add(rowProducts["prodid"].ToString() + ": " + rowProducts["isaname"].ToString());     //if above is true, adds values to listbox
                                }
                            }
                        }
                    }
                }
            }
        }

        private void accountDetails()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlQuery = @"SELECT * FROM account";

                daAccounts = new SQLiteDataAdapter(sqlQuery, conn);
                dtAccounts = new DataTable();
                daAccounts.Fill(dtAccounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void productDetails()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlQuery = @"SELECT * FROM product";

                daProducts = new SQLiteDataAdapter(sqlQuery, conn);
                dtProducts = new DataTable();
                daProducts.Fill(dtProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void customerDetails()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlQuery = @"SELECT * FROM customer";

                daCustomers = new SQLiteDataAdapter(sqlQuery, conn);
                dtCustomers = new DataTable();
                daCustomers.Fill(dtCustomers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }       //see line 36 for additional details
        }

        private void lbxCustAccounts_Click(object sender, EventArgs e)
        {
            foreach (DataRow rowProducts in dtProducts.Rows)        //iterates through products table
            {
                if(lbxCustAccounts.SelectedItem.ToString() == rowProducts["prodid"].ToString() + ": " + rowProducts["isaname"].ToString())      //checks if listbox item that is selected is equal to 
                                                                                                                                                //product table values 
                {
                    foreach(DataRow rowAccounts in dtAccounts.Rows)     //if above statement is true, iterates through account table
                    {
                        if (rowAccounts["custid"].ToString() == custIDCheck)        //checks custid in accounts table is equal to custIDCheck value
                        {
                            if(rowAccounts["prodid"].ToString() == rowProducts["prodid"].ToString())    //if above is true, checks to see if prodid on current account 
                                                                                                        //table row is equal to prodid on current product table row
                            {
                                txtBalance.Text = rowAccounts["balance"].ToString();        //if above is true, textbox displays balance of current selected account for current customer being looked at
                            }
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();     //disposes this form
        }
    }
}
