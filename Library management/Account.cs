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
    public partial class Account : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=lpdatabase1.database.windows.net;Initial Catalog=Azurehost;User ID=adminlionel;Password=Lion.game7im3!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        bool staff;
        int user_id;
        public Account(bool staff, int user_id)
        {
            InitializeComponent();
            this.staff = staff;
            this.user_id = user_id;
        }

        private void Account_Load(object sender, EventArgs e)
        {
            PopulateData();
        }

        private void PopulateData()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            if (staff)
            {
                adapt = new SqlDataAdapter("select * from books_borrowed", con);
            }
            else
            {
                adapt = new SqlDataAdapter("select * from books_borrowed where id=" + user_id, con);
            }
            
            adapt.Fill(dt);
            myBooks.DataSource = dt;
            con.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(staff, user_id);
            home.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select * from credentials where id=" + user_id + " AND password='" + txtOldPassword.Text + "'", con);
            adapt.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                cmd = new SqlCommand("UPDATE credentials SET password=@newpassword where id=" + user_id, con);
                cmd.Parameters.AddWithValue("@newpassword", txtNewPassword.Text);
                cmd.ExecuteNonQuery();
            }
            else
            {
                MessageBox.Show("Old password is wrong");
            }
            
            con.Close();
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            MessageBox.Show("Your password was updated succefully");
        }
    }
}
