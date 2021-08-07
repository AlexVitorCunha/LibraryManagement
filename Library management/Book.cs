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
        bool staff;
        public Book(bool staff)
        {
            InitializeComponent();
            this.staff = staff;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home login = new Home(staff);
            login.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
