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
    public partial class Management : Form
    {
        public Management()
        {
            InitializeComponent();
        }

        dbConnection dbConnection = new dbConnection();
        MainMenu mainMenu;
        string ex;

        SQLiteConnection conn;
        SQLiteDataAdapter daUsers;
        DataTable dtUsers;

        string loadCommand;

        public string[] userArray = new string[6];

        private void Management_Load(object sender, EventArgs e)
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
            showAllUsers();
        }

        private void showAllUsers()
        {
            try
            {
                conn = new SQLiteConnection(dbConnection.source);
                string sqlCommand = @"SELECT * FROM account";

                daUsers = new SQLiteDataAdapter(sqlCommand, conn);
                dtUsers = new DataTable();
                daUsers.Fill(dtUsers);
                dgvUsers.DataSource = dtUsers;
                dgvUsers.AutoResizeColumns();
                dgvUsers.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            loadCommand = "add";
            Form form = new UserDetailsForm(loadCommand, userArray);
            form.Show();
            this.Dispose();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            loadCommand = "update";
            if (dgvUsers.SelectedRows.Count == 1)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    if (dgvUsers.SelectedCells[0].Value.ToString() == row["custid"].ToString())
                    {
                        for (int i = 0; i < 6; i++)     //isloggedin column of user table is not needed in this function
                        {
                            userArray[i] = dgvUsers.SelectedCells[i].Value.ToString();
                        }
                    }
                }
                Form form = new UserDetailsForm(loadCommand, userArray);
                form.Show();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please select a customer row");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in dtUsers.Rows)
            {
                if (dgvUsers.SelectedCells[0].Value.ToString() == row["custid"].ToString())
                {
                    using (SQLiteCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM user Where userID = @userID";
                        cmd.Parameters.AddWithValue("userID", row["userID"].ToString());
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            this.Refresh();
        }
    }
}
