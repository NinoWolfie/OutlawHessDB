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
    public partial class UserDetailsForm : Form
    {
        string loadCommand;
        string[] userArray = new string[6];
        int count = 0;

        dbConnection dbConnection = new dbConnection();
        string ex;
        SQLiteConnection conn;

        public UserDetailsForm(string loadFunction, string[] userArray)
        {
            InitializeComponent();
        }

        private void UserDetailsForm_Load(object sender, EventArgs e)
        {
            if (loadCommand == "add")
            {
                txtUserID.Text = "TBA";
                txtUserFirstName.Text = null;
                txtUserLastName.Text = null;
                txtUserPassword.Text = null;
                txtUserRole.Text = null;
                txtUserDOB.Text = null;
            }
            else if (loadCommand == "update")
            {
                txtUserID.Text = userArray[0];
                txtUserFirstName.Text = userArray[1];
                txtUserLastName.Text = userArray[2];
                txtUserPassword.Text = userArray[3];
                txtUserRole.Text = userArray[4];
                txtUserDOB.Text = userArray[5];
            }

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

            try
            {
                conn = new SQLiteConnection(dbConnection.source);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
