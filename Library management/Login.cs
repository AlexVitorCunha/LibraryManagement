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
        SqlConnection con = new SqlConnection(@"Data Source=lpdatabase1.database.windows.net;Initial Catalog=Azurehost;User ID=adminlionel;Password=Lion.game7im3!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
                    con.Close();
                    this.Hide();
                    Home home = new Home(Convert.ToBoolean(dt.Rows[0]["staff"]),Convert.ToInt32(dt.Rows[0]["id"]), (string)dt.Rows[0]["username"]);
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
