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
    public partial class CustomerTransactionForm : Form
    {
        public CustomerTransactionForm()
        {
            InitializeComponent();
        }

        //Global Variables and class call
        dbConnection dbConnection = new dbConnection();
        MainMenu mainMenu;
        string ex;

        SQLiteConnection conn;
        SQLiteDataAdapter daAccounts;
        SQLiteDataAdapter daProducts;
        SQLiteDataAdapter daCustomer;
        SQLiteDataAdapter daTransactions;
        DataTable dtAccounts;
        DataTable dtProducts;
        DataTable dtCustomers;
        DataTable dtTransactions;

        private void CustomerTransactionFrom_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);        //lines 38 - 126, see lines 33 - 62 in login.cs
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            showCustomers();
            showProducts();
            showAccounts();
            showTransactions();

            foreach(DataRow custRow in dtCustomers.Rows)        //iterates through each row in customer table and adds listbox item based on values in line 56
            {
                lbxCustomer.Items.Add(custRow["custid"].ToString() + ": " + custRow["title"].ToString() + " " + custRow["firstname"].ToString() + " " + custRow["lastname"]);
            }
        }

        private void showCustomers()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM customer";

                daCustomer = new SQLiteDataAdapter(sqlCommand, conn);
                dtCustomers = new DataTable();
                daCustomer.Fill(dtCustomers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showProducts()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM product";

                daProducts = new SQLiteDataAdapter(sqlCommand, conn);
                dtProducts = new DataTable();
                daProducts.Fill(dtProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showAccounts()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM account";

                daAccounts = new SQLiteDataAdapter(sqlCommand, conn);
                dtAccounts = new DataTable();
                daAccounts.Fill(dtAccounts);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void showTransactions()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM tranx";

                daTransactions = new SQLiteDataAdapter(sqlCommand, conn);
                dtTransactions = new DataTable();
                daTransactions.Fill(dtTransactions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   //see line 38 for additional details
        }

        private void lbxCustomer_Click(object sender, EventArgs e)
        {
            lbxAccounts.Items.Clear();  //clears accounts listbox
            foreach (DataRow rowCustomer in dtCustomers.Rows)   //iterates through customer table
            {
                if (lbxCustomer.SelectedItem.ToString() == rowCustomer["custid"].ToString() + ": " + rowCustomer["title"].ToString() + " " + rowCustomer["firstname"].ToString() + " " + rowCustomer["lastname"])
                    //line 133, checks if customer listbox value equals concatenated customer table values of current row
                {
                    foreach (DataRow rowAccount in dtAccounts.Rows)     //iterates through accounts table
                    {
                        if(rowCustomer["custid"].ToString() == rowAccount["custid"].ToString())     //checks to see if current row in customer table custid equals current row in account table custid
                        {
                            foreach(DataRow rowProduct in dtProducts.Rows)      //iterates through product table
                            {
                                if(rowProduct["prodid"].ToString() == rowAccount["prodid"].ToString())      //checks to see if current row in product table prodid equals current row in account table prodid
                                {
                                    lbxAccounts.Items.Add("Account ID: " + rowAccount["accid"].ToString() + " - " + rowProduct["isaname"].ToString());      //if above is true, adds listbox item based
                                                                                                                                                            //on account and product table values
                                }
                            }
                        }
                    }
                }
            }
        }

        private void lbxAccounts_Click(object sender, EventArgs e)
        {
            lbxTransactions.Items.Clear();      //clears transactions listbox
            foreach (DataRow rowProduct in dtProducts.Rows)     //iterates through product table
            {
                foreach (DataRow rowAccount in dtAccounts.Rows)     //iterates through account table
                {
                    if(lbxAccounts.SelectedItem.ToString() == "Account ID: " + rowAccount["accid"].ToString() + " - " + rowProduct["isaname"].ToString())   //checks if item selected in account listbox is equal
                                                                                                                                                            //to details from account and product tables
                    {
                        foreach (DataRow rowTransaction in dtTransactions.Rows)     //if above is true, iterates through transaction table
                        {
                            if (rowAccount["accid"].ToString() == rowTransaction["accid"].ToString())       //check to see if accid of current row in account table is equal to accid of current row
                                                                                                            //in transaction table
                            {
                                lbxTransactions.Items.Add(rowTransaction["action"].ToString() + ": " + rowTransaction["event"].ToString() + " - Amount: £" + rowTransaction["amnt"].ToString());
                                //line 169 adds item to listbox based on transaction table values
                            }
                        }
                    }
                }
            }
        }

        private void btnCustTransactions_Click(object sender, EventArgs e)
        {
            this.Dispose();     //disposes this form
        }

        private void btnMainMenu_Click(object sender, EventArgs e)      //disposes this form and active transaction form when main menu button is clicked
        {
            this.Dispose();
            Transactions.ActiveForm.Dispose();
        }
    }
}
