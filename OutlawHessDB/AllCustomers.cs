
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
                dgvCustomer.DataSource = dtCustomer;
                dgvCustomer.AutoResizeColumns();
                dgvCustomer.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            loadCommand = "add";
            Form form = new CustomerDetailsForm(loadCommand, customerArray);
            form.Show();
            this.Dispose();
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            loadCommand = "update";
            if (dgvCustomer.SelectedRows.Count == 1)
            {
                foreach (DataRow row in dtCustomer.Rows)
                {
                    if (dgvCustomer.SelectedCells[0].Value.ToString() == row["custid"].ToString())
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            customerArray[i] = dgvCustomer.SelectedCells[i].Value.ToString();
                        }
                    }
                }
                Form form = new CustomerDetailsForm(loadCommand, customerArray);
                form.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please select a customer row");
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtCustomer.Rows)
            {
                if (dgvCustomer.SelectedCells[0].Value.ToString() == row["custid"].ToString())
                {
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM customer Where custid = @custID";
                        cmd.Parameters.AddWithValue("custID", row["custid"].ToString());
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            this.Refresh();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCustAccounts_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 1)
            {
                foreach (DataRow row in dtCustomer.Rows)
                {
                    if (dgvCustomer.SelectedCells[0].Value.ToString() == row["custid"].ToString())
                    {
                        custID = row["custid"].ToString();
                    }
                }
                Form form = new CustomerAccounts(custID);
                form.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please select a customer row");
            }
        }
    }
}