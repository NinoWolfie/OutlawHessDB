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
    public partial class Transactions : Form
    {
        public Transactions()
        {
            InitializeComponent();
        }

        //global variables and class call
        dbConnection dbConnection = new dbConnection();
        MainMenu mainMenu;
        string ex;

        SQLiteConnection conn;
        SQLiteDataAdapter daTransactions;
        DataTable dtTransactions;

        private void Transactions_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);        //lines 32 - 64, see login.cs lines 33 - 62
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            showTransactions();
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
                dgvTransactions.DataSource = dtTransactions;        //lines 56 - 58 populates dgvTransactions
                dgvTransactions.AutoResizeColumns();
                dgvTransactions.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   //see line 32 for additional details
        }

        private void btnCustTransactions_Click(object sender, EventArgs e)      //clicking this opens CustomerTransactionFrom and shows it
        {
            Form form = new CustomerTransactionFrom();
            form.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();     //disposes this form
        }
    }
}
