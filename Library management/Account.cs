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
        SqlConnection con = DatabaseConnection.getDatabaseconnection();
        SqlCommand cmd;
        LoggedUser user;
        int return_book;
        int return_user;
        
        public Account(LoggedUser user)
        {
            InitializeComponent();
            this.user = user;

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
            if (user.Staff)
            {
                adapt = new SqlDataAdapter("select * from books_borrowed", con);
                lblBooks.Text = "All current borrowed books";
            }
            else
            {
                adapt = new SqlDataAdapter("select * from books_borrowed where id=" + user.UserID, con);
                lblBooks.Text = "Your current borrowed books";
            }
            
            adapt.Fill(dt);
            myBooks.DataSource = dt;
            con.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home(user);
            home.ShowDialog();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select * from credentials where id=" + user.UserID + " AND password='" + txtOldPassword.Text + "'", con);
            adapt.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                if(txtNewPassword.Text != String.Empty)
                {
                    cmd = new SqlCommand("UPDATE credentials SET password=@newpassword where id=" + user.UserID, con);
                    cmd.Parameters.AddWithValue("@newpassword", txtNewPassword.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your password was updated succefully");
                }
                else
                {
                    MessageBox.Show("New password cannot be blank.");
                }
                
            }
            else
            {
                MessageBox.Show("Old password is incorrect.");
            }
            
            con.Close();
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
        }

        //Gets the selected entry from the table
        private void myBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (myBooks.SelectedRows.Count != 0) // make sure select atleast 1 row 
            {
                DataGridViewRow row = this.myBooks.Rows[e.RowIndex];
                return_book = Convert.ToInt32(row.Cells[2].Value.ToString());
                lblSelected.Text = "Selected book:" + return_book.ToString();
                return_user = Convert.ToInt32(row.Cells[3].Value.ToString());
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("DELETE from books_borrowed WHERE isbn=@isbn AND id=@id", con);
            cmd.Parameters.AddWithValue("@isbn", return_book);
            cmd.Parameters.AddWithValue("@id", return_user);
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("UPDATE books SET quantity=quantity+1 where isbn=@isbn", con);
            cmd.Parameters.AddWithValue("@isbn", return_book);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thank you for returning the selected book.");
            PopulateData();
        }
    }
}
