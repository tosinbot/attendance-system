using System;
using System.Windows.Forms;

namespace Suprema {
	public partial class UserInfoForm : Form {
		public string UserID
		{
			get {
				return tbxUserID.Text;
			}
			set {
				tbxUserID.Text = value;
			}
		}
		public int FingerIndex
		{
			get {
				return Convert.ToInt32(tbxFingerIndex.Text);
			}
			set {
				tbxFingerIndex.Text = Convert.ToString(value);
			}
		}
		public string Memo
		{
			get {
				return tbxMemo.Text;
			}
			set {
				tbxMemo.Text = Convert.ToString(value);
			}
		}

		public UserInfoForm(bool Update) {
			InitializeComponent();

			tbxUserID.Text = "UserID";
			tbxFingerIndex.Text = "0";
			tbxMemo.Text = "Memo";

			if (Update) {
				tbxUserID.ReadOnly = true;
				tbxFingerIndex.ReadOnly = true;
			}
		}

        private void btnOK_Click(object sender, EventArgs e)
        {

        }

        //private void btnOK_Click(object sender, EventArgs e)
        //{

        //}
	}
}