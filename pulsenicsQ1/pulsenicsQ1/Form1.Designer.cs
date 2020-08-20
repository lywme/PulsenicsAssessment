namespace pulsenicsQ1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.aLabel = new System.Windows.Forms.Label();
            this.fileListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.userlistBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loadFileTimer = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.addUpdateBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // aLabel
            // 
            this.aLabel.AutoSize = true;
            this.aLabel.Location = new System.Drawing.Point(24, 30);
            this.aLabel.Name = "aLabel";
            this.aLabel.Size = new System.Drawing.Size(239, 12);
            this.aLabel.TabIndex = 0;
            this.aLabel.Text = "A> List all the files inside the folder";
            // 
            // fileListBox
            // 
            this.fileListBox.FormattingEnabled = true;
            this.fileListBox.ItemHeight = 12;
            this.fileListBox.Location = new System.Drawing.Point(26, 59);
            this.fileListBox.Name = "fileListBox";
            this.fileListBox.Size = new System.Drawing.Size(149, 196);
            this.fileListBox.TabIndex = 1;
            this.fileListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.fileListBox_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "C> Search files by filename";
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(26, 302);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(104, 21);
            this.searchTextBox.TabIndex = 3;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(443, 175);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(0, 12);
            this.linkLabel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 5;
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(136, 300);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(60, 23);
            this.searchBtn.TabIndex = 6;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // userlistBox
            // 
            this.userlistBox.FormattingEnabled = true;
            this.userlistBox.ItemHeight = 12;
            this.userlistBox.Location = new System.Drawing.Point(8, 44);
            this.userlistBox.Name = "userlistBox";
            this.userlistBox.Size = new System.Drawing.Size(149, 112);
            this.userlistBox.TabIndex = 8;
            this.userlistBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.userlistBox_MouseDoubleClick);
            this.userlistBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.userlistBox_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Current users:";
            // 
            // loadFileTimer
            // 
            this.loadFileTimer.Enabled = true;
            this.loadFileTimer.Interval = 5000;
            this.loadFileTimer.Tick += new System.EventHandler(this.loadFileTimer_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "User Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(204, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(204, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Phone:";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(251, 41);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(157, 21);
            this.userName.TabIndex = 13;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(251, 68);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(157, 21);
            this.email.TabIndex = 14;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(251, 95);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(157, 21);
            this.phone.TabIndex = 15;
            // 
            // addUpdateBtn
            // 
            this.addUpdateBtn.Location = new System.Drawing.Point(260, 133);
            this.addUpdateBtn.Name = "addUpdateBtn";
            this.addUpdateBtn.Size = new System.Drawing.Size(108, 23);
            this.addUpdateBtn.TabIndex = 16;
            this.addUpdateBtn.Text = "Add/Update User";
            this.addUpdateBtn.UseVisualStyleBackColor = true;
            this.addUpdateBtn.Click += new System.EventHandler(this.addUpdateBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.addUpdateBtn);
            this.groupBox1.Controls.Add(this.phone);
            this.groupBox1.Controls.Add(this.userlistBox);
            this.groupBox1.Controls.Add(this.email);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(18, 366);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 173);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "D> Create and Update Users";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(185, 12);
            this.label3.TabIndex = 18;
            this.label3.Text = "E> Assign each file to a user:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 589);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileListBox);
            this.Controls.Add(this.aLabel);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "PulsenicsQ1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aLabel;
        private System.Windows.Forms.ListBox fileListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ListBox userlistBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer loadFileTimer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Button addUpdateBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
    }
}

