
namespace Library_management
{
    partial class Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Account));
            this.btnReturn = new System.Windows.Forms.Button();
            this.myBooks = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.lblBooks = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.myBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnReturn.Location = new System.Drawing.Point(12, 12);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(116, 44);
            this.btnReturn.TabIndex = 0;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // myBooks
            // 
            this.myBooks.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.myBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.myBooks.Location = new System.Drawing.Point(12, 249);
            this.myBooks.Name = "myBooks";
            this.myBooks.RowHeadersWidth = 62;
            this.myBooks.RowTemplate.Height = 28;
            this.myBooks.Size = new System.Drawing.Size(765, 150);
            this.myBooks.TabIndex = 1;
            this.myBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myBooks_CellContentClick);
            this.myBooks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myBooks_CellContentClick);
            this.myBooks.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.myBooks_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label1.Location = new System.Drawing.Point(181, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Old Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label2.Location = new System.Drawing.Point(171, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "New Password:";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.BackColor = System.Drawing.Color.LightBlue;
            this.txtOldPassword.Location = new System.Drawing.Point(341, 80);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(380, 26);
            this.txtOldPassword.TabIndex = 4;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BackColor = System.Drawing.Color.LightBlue;
            this.txtNewPassword.Location = new System.Drawing.Point(341, 124);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '*';
            this.txtNewPassword.Size = new System.Drawing.Size(380, 26);
            this.txtNewPassword.TabIndex = 5;
            // 
            // btnChange
            // 
            this.btnChange.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnChange.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChange.Location = new System.Drawing.Point(508, 160);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(213, 37);
            this.btnChange.TabIndex = 6;
            this.btnChange.Text = "Change password";
            this.btnChange.UseVisualStyleBackColor = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.Location = new System.Drawing.Point(620, 405);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(157, 41);
            this.btnReturnBook.TabIndex = 7;
            this.btnReturnBook.Text = "Return book";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // lblBooks
            // 
            this.lblBooks.AutoSize = true;
            this.lblBooks.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBooks.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblBooks.Location = new System.Drawing.Point(248, 200);
            this.lblBooks.Name = "lblBooks";
            this.lblBooks.Size = new System.Drawing.Size(311, 46);
            this.lblBooks.TabIndex = 8;
            this.lblBooks.Text = "Borrowed books";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelected.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.lblSelected.Location = new System.Drawing.Point(12, 410);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(156, 26);
            this.lblSelected.TabIndex = 9;
            this.lblSelected.Text = "Selected book:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label3.Location = new System.Drawing.Point(178, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(430, 46);
            this.label3.TabIndex = 10;
            this.label3.Text = "Change your password";
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(800, 458);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.lblBooks);
            this.Controls.Add(this.btnReturnBook);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myBooks);
            this.Controls.Add(this.btnReturn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Account";
            this.Text = "Account";
            this.Load += new System.EventHandler(this.Account_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myBooks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.DataGridView myBooks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnReturnBook;
        private System.Windows.Forms.Label lblBooks;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Label label3;
    }
}