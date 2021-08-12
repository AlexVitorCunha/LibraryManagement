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
    public partial class Home : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=lpdatabase1.database.windows.net;Initial Catalog=Azurehost;User ID=adminlionel;Password=Lion.game7im3!;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        bool staff;
        int user_id;
        public Home(bool staff, int user_id)
        {
            InitializeComponent();
            this.staff = staff;
            this.user_id = user_id;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (!staff)
            {
                btnAddBook.Hide();
            }
            PopulateData();
        }

        //FILL DATA TO DATA GRID CONTROL
        private void PopulateData()
        {
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            adapt = new SqlDataAdapter("select * from books", con);
            adapt.Fill(dt);
            bookList.DataSource = dt;
            con.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            this.Hide();
            Book book = new Book(staff,user_id);
            book.ShowDialog();
        }

        //Search in the database
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = (string)searchType.SelectedItem;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            switch (keyword)
            {
                case "ISBN":
                    adapt = new SqlDataAdapter($"select * from books where isbn=" + txtSearch.Text, con);
                    break;
                case "Book Title":
                    adapt = new SqlDataAdapter($"select * from books where book_name like '%" + txtSearch.Text + "%'", con);
                    break;
                case "Author":
                    adapt = new SqlDataAdapter($"select * from books where author_name like '%" + txtSearch.Text + "%'", con);
                    break;
                case "Genre":
                    adapt = new SqlDataAdapter($"select * from books where genre like '%" + txtSearch.Text + "%'", con);
                    break;
                default:
                    adapt = new SqlDataAdapter($"select * from books where year=" + txtSearch.Text, con);
                    break;
            }
            adapt.Fill(dt);
            bookList.DataSource = dt;
            con.Close();

        }

        private void bookList_CellContenDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bookList.SelectedRows.Count != 0) // make sure select atleast 1 row 
            {
                DataGridViewRow row = this.bookList.Rows[e.RowIndex];
                this.Hide();
                Book book = new Book(staff, user_id, row);
                book.ShowDialog();
            }
        }
    }
}
