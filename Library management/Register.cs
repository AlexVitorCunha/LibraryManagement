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
    public partial class Register : Form
    {
        SqlConnection con = DatabaseConnection.getDatabaseconnection();
        SqlCommand cmd;
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select * from credentials where username='" + txtUsername.Text + "'", con);
            adapt.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                lblError.Text = "Username already taken";
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblError.Text = "Passwords must match";
            }
            else if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                lblError.Text = "All fields must be filled";
            }
            else
            {
                cmd = new SqlCommand("insert into credentials values(@username,@password,@staff)", con);
                cmd.Parameters.AddWithValue("username", txtUsername.Text);
                cmd.Parameters.AddWithValue("password", txtPassword.Text);
                cmd.Parameters.AddWithValue("staff", btnStaff.Checked);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User registered!");
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
            con.Close();
        }

    }
}
