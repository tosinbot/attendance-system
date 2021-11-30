namespace Suprema {
	partial class UserInfoForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxFingerIndex = new System.Windows.Forms.TextBox();
            this.tbxMemo = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbxUserID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "FingerIndex";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Memo";
            // 
            // tbxFingerIndex
            // 
            this.tbxFingerIndex.Location = new System.Drawing.Point(102, 8);
            this.tbxFingerIndex.MaxLength = 1;
            this.tbxFingerIndex.Name = "tbxFingerIndex";
            this.tbxFingerIndex.Size = new System.Drawing.Size(92, 20);
            this.tbxFingerIndex.TabIndex = 4;
            // 
            // tbxMemo
            // 
            this.tbxMemo.Location = new System.Drawing.Point(102, 36);
            this.tbxMemo.MaxLength = 100;
            this.tbxMemo.Multiline = true;
            this.tbxMemo.Name = "tbxMemo";
            this.tbxMemo.Size = new System.Drawing.Size(144, 100);
            this.tbxMemo.TabIndex = 5;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(18, 148);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(108, 20);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(138, 148);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 20);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbxUserID
            // 
            this.tbxUserID.Location = new System.Drawing.Point(12, 174);
            this.tbxUserID.Name = "tbxUserID";
            this.tbxUserID.Size = new System.Drawing.Size(100, 20);
            this.tbxUserID.TabIndex = 8;
            this.tbxUserID.Visible = false;
            // 
            // UserInfoForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(258, 192);
            this.Controls.Add(this.tbxUserID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbxMemo);
            this.Controls.Add(this.tbxFingerIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserInfoForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Info";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbxFingerIndex;
		private System.Windows.Forms.TextBox tbxMemo;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbxUserID;
	}
}