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
    public partial class Book : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=lpdatabase1.database.windows.net;Initial Catalog=Azurehost;User ID=adminlionel;Password=Lion.game7im3!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        SqlCommand cmd;
        bool staff;
        int user_id;
        int book_id;
        DataGridViewRow row;
        public Book(bool staff, int user_id, DataGridViewRow row = null)
        {
            InitializeComponent();
            this.staff = staff;
            this.user_id = user_id;
            this.row = row; 
            if (!staff)
            {
                txtISBN.ReadOnly = true;
                txtName.ReadOnly = true;
                txtAuthor.ReadOnly = true;
                txtGenre.ReadOnly = true;
                txtYear.ReadOnly = true;
                txtQuantity.ReadOnly = true;
                btnAdd.Hide();
                btnUpdate.Hide();
                btnDelete.Hide();
            }
            else
            {
                btnBorrow.Hide();
                btnReturnBook.Hide();
            }

            if (row != null)
            {
                btnAdd.Hide();
                txtISBN.Text = row.Cells[0].Value.ToString();
                txtName.Text = row.Cells[1].Value.ToString();
                txtAuthor.Text = row.Cells[2].Value.ToString();
                txtGenre.Text = row.Cells[3].Value.ToString();
                txtYear.Text = row.Cells[4].Value.ToString();
                txtQuantity.Text = row.Cells[5].Value.ToString();
                book_id = int.Parse(row.Cells[0].Value.ToString());
            }
            else
            {
                btnUpdate.Hide();
                btnDelete.Hide();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home login = new Home(staff,user_id);
            login.ShowDialog();
        }

        //UPDATE BOOK FROM DATABASE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtISBN.Text != "")
            {
                
                cmd = new SqlCommand("UPDATE books SET isbn=@isbn, book_name=@book_name, " +
                    "author_name=@author_name, genre=@genre, year=@year, quantity=@quantity  where isbn=@Oldisbn", con);
                con.Open();
                cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);
                cmd.Parameters.AddWithValue("@book_name", txtName.Text);
                cmd.Parameters.AddWithValue("@author_name", txtAuthor.Text);
                cmd.Parameters.AddWithValue("@genre", txtGenre.Text);
                cmd.Parameters.AddWithValue("@year", txtYear.Text);
                cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                cmd.Parameters.AddWithValue("@Oldisbn", book_id);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Updated Successfully");
                this.Hide();
                Home home = new Home(staff, user_id);
                home.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please enter mandatory details!");
            }
        }
        //DELETE BOOK FROM DATABASE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "Are you sure you want to delete";
            string title = "Delete Record";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                    cmd = new SqlCommand("delete from books WHERE isbn=@isbn", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@isbn", book_id);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Deleted Successfully");
                    this.Hide();
                    Home home = new Home(staff, user_id);
                    home.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Cannot delete a book that is currently borrowed");
                }
                
            }
        }

        // ADD BOOK TO DATABASE
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("insert into books(isbn, book_name, author_name, genre, year, quantity)" +
                    " values(@isbn, @book_name, @author_name, @genre, @year, @quantity)", con);
            con.Open();
            cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);
            cmd.Parameters.AddWithValue("@book_name", txtName.Text) ;
            cmd.Parameters.AddWithValue("@author_name", txtAuthor.Text);
            cmd.Parameters.AddWithValue("@genre", txtGenre.Text);
            cmd.Parameters.AddWithValue("@year", txtYear.Text);
            cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted Successfully");
            this.Hide();
            Home home = new Home(staff,user_id);
            home.ShowDialog();
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if(int.Parse(txtQuantity.Text) == 0)
            {
                MessageBox.Show("No copies of this book available");
            }
            else
            {
                cmd = new SqlCommand("insert into books_borrowed(return_date, isbn, id)" +
                    " values(@return_date, @isbn, @id)", con);
                con.Open();
                DateTime return_date = DateTime.Today.AddDays(7);
                cmd.Parameters.AddWithValue("@return_date", return_date);
                cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);
                cmd.Parameters.AddWithValue("@id", user_id);
                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("UPDATE books SET quantity=@quantity where isbn=@isbn", con);
                cmd.Parameters.AddWithValue("@quantity", int.Parse(txtQuantity.Text) - 1);
                cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("You show return this book by" + return_date);
                this.Hide();
                Home home = new Home(staff, user_id);
                home.ShowDialog();
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        { 
            con.Open();
            cmd = new SqlCommand("UPDATE books SET quantity=@quantity where isbn=@isbn", con);
            cmd.Parameters.AddWithValue("@quantity", int.Parse(txtQuantity.Text) + 1);
            cmd.Parameters.AddWithValue("@isbn", txtISBN.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Thank you for returning the book.");
            this.Hide();
            Home home = new Home(staff, user_id);
            home.ShowDialog();

        }
    }
}
