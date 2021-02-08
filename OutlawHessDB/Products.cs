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

        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;
        SQLiteDataAdapter daProduct;
        DataTable dtProduct;

        private void Products_Load(object sender, EventArgs e)
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

            productDetails();

            foreach(DataRow row in dtProduct.Rows)
            {
                lbxProducts.Items.Add(row["prodid"].ToString() + ": " + row["isaname"].ToString());
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
            }
        }

        private void lbxProducts_Click(object sender, EventArgs e)
        {
            foreach(DataRow row in dtProduct.Rows)
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
            foreach (DataRow row in dtProduct.Rows)
            {
                if (lbxProducts.SelectedItem.ToString() == row["prodid"].ToString() + ": " + row["isaname"].ToString())
                {
                    if (row["status"].ToString() == "closed")
                    {
                        if (rbtnOpen.Checked == true)
                        {
                            using (SQLiteCommand cmd = conn.CreateCommand())
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
                    if (row["status"].ToString() == "open")
                    {
                        if (rbtnClosed.Checked == true)
                        {
                            using (SQLiteCommand cmd = conn.CreateCommand())
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
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE product Set intrate = @intrate Where prodid = @prodid";
                        cmd.Parameters.AddWithValue("intrate", txtInterestRate.Text);
                        cmd.Parameters.AddWithValue("prodid", row["prodid"].ToString());

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    this.Dispose();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
