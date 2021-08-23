using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Library_management
{
    public partial class Login : Form
    {


        SqlConnection con = DatabaseConnection.getDatabaseconnection();
        public Login()
        {
            InitializeComponent();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register register = new Register();
            register.ShowDialog();
        }

        private void btnVisible_CheckedChanged(object sender, EventArgs e)
        {
            if (btnVisible.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text != "" && txtPassword.Text != "")
            {
                con.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter adapt;
                adapt = new SqlDataAdapter("select * from credentials where username='" + txtUsername.Text + "' and password='" + txtPassword.Text + "'", con);
                adapt.Fill(dt);
                
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("Welcome " + (string)dt.Rows[0]["username"]);
                    LoggedUser user = new LoggedUser();
                    user.Staff = Convert.ToBoolean(dt.Rows[0]["staff"]);
                    user.UserID = Convert.ToInt32(dt.Rows[0]["id"]);
                    user.Username = (string)dt.Rows[0]["username"];
                    con.Close();
                    this.Hide();
                    Home home = new Home(user);
                    home.ShowDialog();
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Please fill all the information");
            }
        }
    }
}
