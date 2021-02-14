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
    public partial class CustomerTransactionFrom : Form
    {
        public CustomerTransactionFrom()
        {
            InitializeComponent();
        }

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

            showCustomers();
            showProducts();
            showAccounts();
            showTransactions();

            foreach(DataRow custRow in dtCustomers.Rows)
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
            }
        }
    }
}
