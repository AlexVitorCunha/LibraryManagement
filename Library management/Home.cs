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
        SqlConnection con = DatabaseConnection.getDatabaseconnection();
        SqlCommand cmd;
        LoggedUser user;
        public Home(LoggedUser user)
        {
            InitializeComponent();
            this.user = user;
            searchType.SelectedItem = "Book Title";
            lblWelcome.Text = "Welcome, " + user.Username + "!";
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (!user.Staff)
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

        //to add imported data into the database
        private void addData(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                try
                {
                    cmd = new SqlCommand("insert into books(isbn, book_name, author_name, genre, year, quantity, book_cover)" +
                        " values(@isbn, @book_name, @author_name, @genre, @year, @quantity, @book_cover)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@isbn", row["isbn"].ToString());
                    cmd.Parameters.AddWithValue("@book_name", row["book_name"].ToString());
                    cmd.Parameters.AddWithValue("@author_name", row["author_name"].ToString());
                    cmd.Parameters.AddWithValue("@genre", row["genre"].ToString());
                    cmd.Parameters.AddWithValue("@year", int.Parse(row["year"].ToString()));
                    cmd.Parameters.AddWithValue("@quantity", int.Parse(row["quantity"].ToString()));
                    cmd.Parameters.AddWithValue("@book_cover", row["book_cover"].ToString());
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Book '" + row["book_name"].ToString() + "' is already on the database");
                }
                
            }
            PopulateData();

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
            Book book = new Book(user);
            book.ShowDialog();
        }

        //Search in the database
        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = (string)searchType.SelectedItem;
            con.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapt;
            if (txtSearch.Text == "") {
                MessageBox.Show("Please enter what you would like to search.");
                con.Close();
                PopulateData();
            }
            else 
            {
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
                    case "Year":
                        adapt = new SqlDataAdapter($"select * from books where year =" + txtSearch.Text, con);
                        break;
                    default:
                        adapt = new SqlDataAdapter($"select * from books where book_name like '%" + txtSearch.Text + "%'", con);
                        break;
                }
                try
                {
                    adapt.Fill(dt);
                    bookList.DataSource = dt;
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Search");
                    con.Close();
                    PopulateData();
                }
            }
        }

        private void Clear()
        {
            txtSearch.Text = "";
        }

        private void bookList_CellContenDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bookList.SelectedRows.Count != 0) // make sure select atleast 1 row 
            {
                DataGridViewRow row = this.bookList.Rows[e.RowIndex];
                this.Hide();
                Book book = new Book(user, row);
                book.ShowDialog();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {  
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            try
            {
                txtImport.Text = openFileDialog1.FileName;
                string filePath = txtImport.Text;
                DataTable dt = new DataTable();
                string[] lines = System.IO.File.ReadAllLines(filePath);
            
                if (lines.Length > 0)
                {
                    //first line to create header
                    string firstLine = lines[0];
                    string[] headerLabels = firstLine.Split(',');
                    foreach (string headerWord in headerLabels)
                    {
                        dt.Columns.Add(new DataColumn(headerWord));
                    }
                    //For Data
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] dataWords = lines[i].Split(',');
                        DataRow dr = dt.NewRow();
                        int columnIndex = 0;
                        foreach (string headerWord in headerLabels)
                        {
                            dr[headerWord] = dataWords[columnIndex++];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    bookList.DataSource = dt;
                }

                //ask if they want to import the data?
               var selectedOption = MessageBox.Show("Would you like to import this data into the database?", "Please Select a button", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
 
               if (selectedOption == DialogResult.Yes)
 
                {
                        addData(dt);
 
                }
 
               else if (selectedOption == DialogResult.No)
 
               {
 
                   MessageBox.Show("Data is not imported.");
 
               }
            }
            catch (Exception) { MessageBox.Show("Nothing Imported."); }
            txtImport.Text = "";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.Sheets["Sheet1"];
            worksheet = (Microsoft.Office.Interop.Excel._Worksheet)workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported from gridview";
            // storing header part in Excel  
            for (int i = 1; i < bookList.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = bookList.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < bookList.Rows.Count - 1; i++)
            {
                for (int j = 0; j < bookList.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = bookList.Rows[i].Cells[j].Value.ToString();
                }
            }
            try
            {// save the application  
                workbook.SaveAs("book_details.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch(Exception)
            {
                MessageBox.Show("Process canceled");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            if (!user.Staff)
            {
                MessageBox.Show("To access the book information to borrow, double click on the database entry, on the leftmost column with the arrow.");
            }
            else {
            MessageBox.Show("To access the book information to edit and delete, double click on the database entry, on the leftmost column with the arrow.");
            }
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Account account = new Account(user);
            account.ShowDialog();
        }
        
    }
}
