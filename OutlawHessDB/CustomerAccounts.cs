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
            custIDCheck = custID;
        }

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

            accountDetails();
            productDetails();
            customerDetails();

            foreach (DataRow rowAccounts in dtAccounts.Rows)
            {
                if(custIDCheck == rowAccounts["custid"].ToString())
                {
                    foreach (DataRow rowCustomers in dtCustomers.Rows)
                    {
                        if (custIDCheck == rowCustomers["custid"].ToString())
                        {
                            lblCustAccount.Text = rowCustomers["title"].ToString() + " " + rowCustomers["firstname"].ToString() + " " + rowCustomers["lastname"].ToString();
                            foreach (DataRow rowProducts in dtProducts.Rows)
                            {
                                if (rowAccounts["prodid"].ToString() == rowProducts["prodid"].ToString())
                                {
                                    lbxCustAccounts.Items.Add(rowProducts["prodid"].ToString() + ": " + rowProducts["isaname"].ToString());
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
            }
        }

        private void lbxCustAccounts_Click(object sender, EventArgs e)
        {
            foreach (DataRow rowProducts in dtProducts.Rows)
            {
                if(lbxCustAccounts.SelectedItem.ToString() == rowProducts["prodid"].ToString() + ": " + rowProducts["isaname"].ToString())
                {
                    foreach(DataRow rowAccounts in dtAccounts.Rows)
                    {
                        if (rowAccounts["custid"].ToString() == custIDCheck)
                        {
                            if(rowAccounts["prodid"].ToString() == rowProducts["prodid"].ToString())
                            {
                                txtBalance.Text = rowAccounts["balance"].ToString();
                            }
                        }
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
