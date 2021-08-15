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
            searchType.SelectedItem = "Book Title";
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
            if (txtSearch.Text == "") {
                MessageBox.Show("Please enter what you like to search.");
            }
            else {
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
                Book book = new Book(staff, user_id, row);
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
            }
            catch (Exception) { MessageBox.Show("Nothing Imported."); }

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
            // save the application  
            workbook.SaveAs("book_details.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void helpBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To access the book files, double click on the database entry on the leftmost column with the arrow.");
        }
    }
}
