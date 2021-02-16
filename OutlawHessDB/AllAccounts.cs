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
    public partial class AllAccounts : Form
    {
        public AllAccounts()
        {
            InitializeComponent();
        }

        dbConnection dbConnection = new dbConnection();
        MainMenu mainMenu;
        string ex;

        SQLiteConnection conn;
        SQLiteDataAdapter daAccounts;
        SQLiteDataAdapter daProducts;
        SQLiteDataAdapter daTransactions;
        DataTable dtAccounts;
        DataTable dtProducts;
        DataTable dtTransactions;

        double balance = 0;
        double accrued = 0;
        double annualInterestRate = 0;
        double balancePlusAccruedInterest = 0;
        string accountID;
        string customerID;

        private void AllAccounts_Load(object sender, EventArgs e)
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
            showAllAccounts();
            productDetails();
            transactionDetails();
        }

        private void showAllAccounts()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM account";

                daAccounts = new SQLiteDataAdapter(sqlCommand, conn);
                dtAccounts = new DataTable();
                daAccounts.Fill(dtAccounts);
                dgvAccounts.DataSource = dtAccounts;
                dgvAccounts.AutoResizeColumns();
                dgvAccounts.MultiSelect = false;
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

        private void transactionDetails()
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

        private void btnBalAccruedCalc_Click(object sender, EventArgs e)
        {
            foreach(DataRow rowAccounts in dtAccounts.Rows)
            {
                foreach (DataRow rowProducts in dtProducts.Rows)
                {
                    if (rowAccounts["prodid"].ToString() == rowProducts["prodid"].ToString())
                    {
                        accountID = rowAccounts["accid"].ToString();
                        customerID = rowAccounts["custid"].ToString();
                        balance = double.Parse(rowAccounts["balance"].ToString());
                        accrued = double.Parse(rowAccounts["accrued"].ToString());
                        annualInterestRate = double.Parse(rowProducts["intrate"].ToString());
                        accrued = accrued + ((balance * annualInterestRate) / 365);
                        accrued = Math.Round(accrued, 2);
                        using (SQLiteCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = @"UPDATE account Set accrued = @accrued Where accid = @accid AND custid = @custid";
                            cmd.Parameters.AddWithValue("accrued", accrued);
                            cmd.Parameters.AddWithValue("accid", accountID);
                            cmd.Parameters.AddWithValue("custid", customerID);

                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }
            }
            Form form = new AllAccounts();      //refresh() not working, using new form load
            form.Show();
            this.Dispose();
        }

        private void btnAnnualInterest_Click(object sender, EventArgs e)
        {
            foreach(DataRow rowInterest in dtAccounts.Rows)
            {
                balancePlusAccruedInterest = double.Parse(rowInterest["balance"].ToString()) + double.Parse(rowInterest["accrued"].ToString());
                using(SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE account Set balance = @balance Where accid = @accID";
                    cmd.Parameters.AddWithValue("balance", balancePlusAccruedInterest);
                    cmd.Parameters.AddWithValue("accid", rowInterest["accid"].ToString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"Insert into tranx(accid, action, amnt, event) values (@accid, @action, @amnt, @event)";
                    cmd.Parameters.AddWithValue("accid", rowInterest["accid"].ToString());
                    cmd.Parameters.AddWithValue("action", "interest");
                    cmd.Parameters.AddWithValue("amnt", rowInterest["accrued"].ToString());
                    cmd.Parameters.AddWithValue("event", System.DateTime.Now.ToString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UPDATE account Set accrued = @accrued Where accid = @accID";
                    cmd.Parameters.AddWithValue("accrued", "0");
                    cmd.Parameters.AddWithValue("accid", rowInterest["accid"].ToString());

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            Form form = new AllAccounts();      //refresh() not working, using new form load
            form.Show();
            this.Dispose();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
