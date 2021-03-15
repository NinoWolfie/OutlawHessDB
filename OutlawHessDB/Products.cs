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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        //Global Variables and class call
        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daProduct;
        DataTable dtProduct;

        private void Products_Load(object sender, EventArgs e)
        {
            dbConnection.dbconnStatus(conn);    //lines 30 - 64, see lines 33 - 62 in login.cs
            if (dbConnection.connStatus == true)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.grn;
            }
            else if (dbConnection.connStatus == false)
            {
                tssImageConnStatus.BackgroundImage = Properties.Resources.red;
                MessageBox.Show(ex);
            }

            productDetails();

            foreach(DataRow row in dtProduct.Rows)
            {
                lbxProducts.Items.Add(row["prodid"].ToString() + ": " + row["isaname"].ToString());     //adds string item to listbox
            }
        }

        private void productDetails()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlQuery = @"SELECT * FROM product";

                daProduct = new SQLiteDataAdapter(sqlQuery, conn);
                dtProduct = new DataTable();
                daProduct.Fill(dtProduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }   //see line 30 for additional details
        }

        private void lbxProducts_Click(object sender, EventArgs e)
        {
            foreach(DataRow row in dtProduct.Rows)      //lines 68 - 82, checks details of list item next to row in product table and sets radiobutton to status, then shows the interest rate in textbox
            {
                if (lbxProducts.SelectedItem.ToString() == row["prodid"].ToString() + ": " + row["isaname"].ToString())
                {
                    if(row["status"].ToString() == "closed")
                    {
                        rbtnClosed.Checked = true;
                    }
                    else
                    {
                        rbtnOpen.Checked = true;
                    }
                    txtInterestRate.Text = row["intrate"].ToString();
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtInterestRate.Text) == true)     //validates that txtInterestRate contains data
            {
                MessageBox.Show("Please enter an interest rate value");
                return;
            }
            if(double.TryParse(txtInterestRate.Text, out double result) == false)       //validates the string input for the interest rate is a double before continuing
            {
                MessageBox.Show("Please only use numbers in the interest rate");
                return;
            }
            foreach (DataRow row in dtProduct.Rows)     //iterates through each row of product table
            {
                if (lbxProducts.SelectedItem.ToString() == row["prodid"].ToString() + ": " + row["isaname"].ToString())     //checks that table prodid and isaname concatenated equals the listbox item
                {
                    if (row["status"].ToString() == "closed")       
                    {
                        if (rbtnOpen.Checked == true)       //if statement above is true, checks if rbtnOpen is checked
                        {
                            using (SQLiteCommand cmd = conn.CreateCommand())    //if above statement is true, runs update function to change status to checked rbtn value
                            {
                                cmd.CommandText = @"UPDATE product Set status = @status Where prodid = @prodid";
                                cmd.Parameters.AddWithValue("status", "open");
                                cmd.Parameters.AddWithValue("prodid", row["prodid"].ToString());

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    else if (row["status"].ToString() == "open")     //if line 101 is not true, checks this statement
                    {
                        if (rbtnClosed.Checked == true)     //if statement above is true, checks if rbtnClosed is checked
                        {
                            using (SQLiteCommand cmd = conn.CreateCommand())    //if above statement is true, runs update function to change status to checked rbtn value
                            {
                                cmd.CommandText = @"UPDATE product Set status = @status Where prodid = @prodid";
                                cmd.Parameters.AddWithValue("status", "closed");
                                cmd.Parameters.AddWithValue("prodid", row["prodid"].ToString());

                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                        }
                    }
                    using (SQLiteCommand cmd = conn.CreateCommand())        //runs update function to update intrate if this is changed
                    {
                        cmd.CommandText = @"UPDATE product Set intrate = @intrate Where prodid = @prodid";
                        cmd.Parameters.AddWithValue("intrate", txtInterestRate.Text);
                        cmd.Parameters.AddWithValue("prodid", row["prodid"].ToString());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    this.Dispose();     //disposes this form
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();     //disposes this form with no changes
        }
    }
}
