﻿
namespace Library_management
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.btnLogout = new System.Windows.Forms.Button();
            this.bookList = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.searchType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.helpBtn = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bookList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogout.Location = new System.Drawing.Point(1068, 14);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 38);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // bookList
            // 
            this.bookList.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.bookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookList.Location = new System.Drawing.Point(34, 272);
            this.bookList.Name = "bookList";
            this.bookList.RowHeadersWidth = 62;
            this.bookList.RowTemplate.Height = 28;
            this.bookList.Size = new System.Drawing.Size(1134, 345);
            this.bookList.TabIndex = 1;
            this.bookList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookList_CellContenDoubleClick);
            this.bookList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookList_CellContenDoubleClick);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.SkyBlue;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Location = new System.Drawing.Point(123, 229);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(342, 26);
            this.txtSearch.TabIndex = 2;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblSearch.Location = new System.Drawing.Point(34, 229);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(89, 29);
            this.lblSearch.TabIndex = 3;
            this.lblSearch.Text = "Search";
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.Location = new System.Drawing.Point(1042, 222);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(124, 42);
            this.btnAddBook.TabIndex = 5;
            this.btnAddBook.Text = "Add book";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(726, 222);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 42);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // searchType
            // 
            this.searchType.BackColor = System.Drawing.Color.SkyBlue;
            this.searchType.IntegralHeight = false;
            this.searchType.Items.AddRange(new object[] {
            "ISBN",
            "Book Title",
            "Author",
            "Genre",
            "Year"});
            this.searchType.Location = new System.Drawing.Point(534, 228);
            this.searchType.Name = "searchType";
            this.searchType.Size = new System.Drawing.Size(172, 28);
            this.searchType.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label1.Location = new System.Drawing.Point(22, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(416, 78);
            this.label1.TabIndex = 8;
            this.label1.Text = "Library Dashboard";
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.SlateGray;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnImport.Location = new System.Drawing.Point(34, 628);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(316, 35);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import Data";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DarkGreen;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnExport.Location = new System.Drawing.Point(948, 625);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(219, 35);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label2.Location = new System.Drawing.Point(486, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 29);
            this.label2.TabIndex = 11;
            this.label2.Text = "By";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblWelcome.Location = new System.Drawing.Point(32, 92);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(244, 37);
            this.lblWelcome.TabIndex = 12;
            this.lblWelcome.Text = "Welcome, User!";
            // 
            // txtImport
            // 
            this.txtImport.BackColor = System.Drawing.Color.SkyBlue;
            this.txtImport.Location = new System.Drawing.Point(366, 634);
            this.txtImport.Margin = new System.Windows.Forms.Padding(2);
            this.txtImport.Name = "txtImport";
            this.txtImport.Size = new System.Drawing.Size(522, 26);
            this.txtImport.TabIndex = 13;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.PaleTurquoise;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Location = new System.Drawing.Point(878, 222);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 42);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // helpBtn
            // 
            this.helpBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.helpBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.helpBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.helpBtn.Location = new System.Drawing.Point(976, 14);
            this.helpBtn.Name = "helpBtn";
            this.helpBtn.Size = new System.Drawing.Size(68, 38);
            this.helpBtn.TabIndex = 15;
            this.helpBtn.Text = "Help";
            this.helpBtn.UseVisualStyleBackColor = false;
            this.helpBtn.Click += new System.EventHandler(this.helpBtn_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Location = new System.Drawing.Point(39, 132);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(237, 33);
            this.btnAccount.TabIndex = 16;
            this.btnAccount.Text = "My Account";
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1185, 682);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.helpBtn);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtImport);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnAddBook);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.bookList);
            this.Controls.Add(this.btnLogout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bookList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.DataGridView bookList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox searchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button helpBtn;
        private System.Windows.Forms.Button btnAccount;
    }
}