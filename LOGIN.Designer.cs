namespace KoforiduaPolyBiometric_Attendance
{
    partial class LOGIN
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LOGIN));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.admin_accountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adminDataSet = new UFE30_DatabaseDemoCS.adminDataSet();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExist = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.admin_accountTableAdapter = new UFE30_DatabaseDemoCS.adminDataSetTableAdapters.admin_accountTableAdapter();
            this.tableAdapterManager = new UFE30_DatabaseDemoCS.adminDataSetTableAdapters.TableAdapterManager();
            this.panelNotify = new System.Windows.Forms.Panel();
            this.msgBtn = new System.Windows.Forms.Button();
            this.msgLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.admin_accountBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(151, 167);
            this.txtUserName.Multiline = true;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(198, 26);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // admin_accountBindingSource
            // 
            this.admin_accountBindingSource.DataMember = "admin_account";
            this.admin_accountBindingSource.DataSource = this.adminDataSet;
            // 
            // adminDataSet
            // 
            this.adminDataSet.DataSetName = "adminDataSet";
            this.adminDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txtPassword.Location = new System.Drawing.Point(151, 217);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ShortcutsEnabled = false;
            this.txtPassword.Size = new System.Drawing.Size(198, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(56, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "User Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(69, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Monotype Corsiva", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(185, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 150);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   LOGIN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnExist
            // 
            this.btnExist.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExist.Location = new System.Drawing.Point(151, 262);
            this.btnExist.Name = "btnExist";
            this.btnExist.Size = new System.Drawing.Size(75, 33);
            this.btnExist.TabIndex = 4;
            this.btnExist.Text = "EXIT";
            this.btnExist.UseVisualStyleBackColor = true;
            this.btnExist.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(274, 262);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 33);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.button2_Click);
            // 
            // admin_accountTableAdapter
            // 
            this.admin_accountTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.admin_accountTableAdapter = this.admin_accountTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = UFE30_DatabaseDemoCS.adminDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // panelNotify
            // 
            this.panelNotify.Controls.Add(this.msgBtn);
            this.panelNotify.Controls.Add(this.msgLabel);
            this.panelNotify.Location = new System.Drawing.Point(0, 301);
            this.panelNotify.Name = "panelNotify";
            this.panelNotify.Size = new System.Drawing.Size(471, 0);
            this.panelNotify.TabIndex = 5;
            // 
            // msgBtn
            // 
            this.msgBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.msgBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.msgBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.msgBtn.FlatAppearance.BorderSize = 2;
            this.msgBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msgBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.msgBtn.Location = new System.Drawing.Point(403, 3);
            this.msgBtn.Name = "msgBtn";
            this.msgBtn.Padding = new System.Windows.Forms.Padding(1);
            this.msgBtn.Size = new System.Drawing.Size(56, 26);
            this.msgBtn.TabIndex = 1;
            this.msgBtn.Text = "Ok";
            this.msgBtn.UseVisualStyleBackColor = false;
            this.msgBtn.Click += new System.EventHandler(this.msgBtn_Click);
            // 
            // msgLabel
            // 
            this.msgLabel.AutoSize = true;
            this.msgLabel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msgLabel.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.msgLabel.Location = new System.Drawing.Point(3, 2);
            this.msgLabel.Name = "msgLabel";
            this.msgLabel.Size = new System.Drawing.Size(16, 23);
            this.msgLabel.TabIndex = 0;
            this.msgLabel.Text = "-";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // LOGIN
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(471, 340);
            this.Controls.Add(this.panelNotify);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExist);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "LOGIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN WINDOW";
            this.Load += new System.EventHandler(this.LOGIN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.admin_accountBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelNotify.ResumeLayout(false);
            this.panelNotify.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExist;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private UFE30_DatabaseDemoCS.adminDataSet adminDataSet;
        private System.Windows.Forms.BindingSource admin_accountBindingSource;
        private UFE30_DatabaseDemoCS.adminDataSetTableAdapters.admin_accountTableAdapter admin_accountTableAdapter;
        private UFE30_DatabaseDemoCS.adminDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Panel panelNotify;
        private System.Windows.Forms.Button msgBtn;
        private System.Windows.Forms.Label msgLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}