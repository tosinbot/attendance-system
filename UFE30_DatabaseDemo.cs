using System;
using System.Drawing;
using System.Windows.Forms;
using Suprema;
using System.Data.SqlClient;
using UFE30_DatabaseDemoCS;
using System.Data;
using System.IO;
using System.Text;

namespace Suprema {
	public partial class UFE30_DatabaseDemo : Form {
		//=========================================================================//
		UFScannerManager m_ScannerManager;
		UFScanner m_Scanner;
		UFDatabase m_Database;
		UFMatcher m_Matcher;
		string m_strError;
		int m_Serial;
		string m_UserID;
		int m_FingerIndex;
		byte[] m_Template1;
		int m_Template1Size;
		byte[] m_Template2;
		int m_Template2Size;
		string m_Memo;
		//
		const int MAX_USERID_SIZE = 50;
		const int MAX_TEMPLATE_SIZE = 1024;
		const int MAX_MEMO_SIZE = 100;
		//
		const int DATABASE_COL_SERIAL = 0;
		 string DATABASE_COL_USERID = "";
		const int DATABASE_COL_FINGERINDEX = 2;
		const int DATABASE_COL_TEMPLATE1 = 3;
		const int DATABASE_COL_TEMPLATE2 = 4;
		const int DATABASE_COL_MEMO = 5;

		public UFE30_DatabaseDemo(string Index) {
            DATABASE_COL_USERID = Index;
			InitializeComponent();
		}

		private void UFE30_DatabaseDemo_Load(object sender, EventArgs e) {
			
            m_ScannerManager = new UFScannerManager(this);
			m_Scanner = null;
			m_Database = null;
			m_Matcher = null;

			m_Template1 = new byte[MAX_TEMPLATE_SIZE];
			m_Template2 = new byte[MAX_TEMPLATE_SIZE];

            //lvDatabaseList.Columns.Add("Serial",		100, HorizontalAlignment.Left);
            //lvDatabaseList.Columns.Add("UserID",		160, HorizontalAlignment.Left);
            //lvDatabaseList.Columns.Add("FingerIndex",	180, HorizontalAlignment.Left);
            //lvDatabaseList.Columns.Add("Template1",		180, HorizontalAlignment.Left);
            //lvDatabaseList.Columns.Add("Template2",		180, HorizontalAlignment.Left);
            //lvDatabaseList.Columns.Add("Memo",			160, HorizontalAlignment.Left);

            cbScanTemplateType.SelectedIndex = 0;
		}

		private void UFE30_DatabaseDemo_FormClosing(object sender, FormClosingEventArgs e) {
			btnUninit_Click(sender, e);
		}
		//=========================================================================//

		//=========================================================================//
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string Index) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UFE30_DatabaseDemo(Index));
		}
		//=========================================================================//

		//=========================================================================//
		private void btnClear_Click(object sender, EventArgs e) {
			tbxMessage.Clear();
            //fnametxt.Text = "";
            //srchtxt.Text = "";
            //Mnametxt.Text = "";
            //lnametxt.Text = "";
            pbImageFrame.Image = null;
            //imgPBx.Image = null;
            //voterIdtxt.Text = "";
		}

		private void AddRow(int Serial, string UserID, int FingerIndex, bool bTemplate1, bool bTemplate2, string Memo)
		{
            //ListViewItem listItem = lvDatabaseList.Items.Add(Convert.ToString(Serial));
            //listItem.SubItems.Add(UserID);
            //listItem.SubItems.Add(Convert.ToString(FingerIndex));
            //listItem.SubItems.Add((bTemplate1) ? "O" : "X");
            //listItem.SubItems.Add((bTemplate2) ? "O" : "X");
            //listItem.SubItems.Add(Memo);
		}

		private void UpdateDatabaseList()
		{
			if (m_Database == null) {
				return;
			}

			UFD_STATUS ufd_res;
			int DataNumber;
			int i;

			ufd_res = m_Database.GetDataNumber(out DataNumber); 
			if (ufd_res == UFD_STATUS.OK) {
				tbxMessage.AppendText("DB GetDataNumber: " + DataNumber + "\r\n");
			} else {
				UFDatabase.GetErrorString(ufd_res, out m_strError);
				tbxMessage.AppendText("DB GetDataNumber: " + m_strError + "\r\n");
				return;
			}

            //lvDatabaseList.Items.Clear();

			for (i = 0; i < DataNumber; i++) {
				ufd_res = m_Database.GetDataByIndex(i,
					out m_Serial, out m_UserID, out m_FingerIndex, m_Template1, out m_Template1Size, m_Template2, out m_Template2Size, out m_Memo);
				if (ufd_res != UFD_STATUS.OK) {
					UFDatabase.GetErrorString(ufd_res, out m_strError);
					tbxMessage.AppendText("DB GetDataByIndex: " + m_strError + "\r\n");
					return;
				}

				AddRow(m_Serial, m_UserID, m_FingerIndex, (m_Template1Size != 0), (m_Template2Size != 0), m_Memo);
			}
		}

        private void DrawCapturedImage(UFScanner Scanner)
        {
            Graphics g = pbImageFrame.CreateGraphics();
            Rectangle rect = new Rectangle(0, 0, pbImageFrame.Width, pbImageFrame.Height);
            try
            {
                //
                //Scanner.DrawCaptureImageBuffer(g, rect, cbDetectCore.Checked);
                //
                Bitmap bitmap;
                int Resolution;
                Scanner.GetCaptureImageBuffer(out bitmap, out Resolution);
                pbImageFrame.Image = bitmap;
            }
            finally
            {
                g.Dispose();
            }
        }

		//=========================================================================//

		//=========================================================================//
		private void btnInit_Click(object sender, EventArgs e) {
			//=========================================================================//
			// Initilize scanners
			//=========================================================================//
			UFS_STATUS ufs_res;
			int nScannerNumber;

			Cursor.Current = Cursors.WaitCursor;
			ufs_res = m_ScannerManager.Init();
			Cursor.Current = this.Cursor;
			if (ufs_res == UFS_STATUS.OK) {
				tbxMessage.AppendText("UFScanner Init: OK\r\n");
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner Init: " + m_strError + "\r\n");
				return;
			}

			nScannerNumber = m_ScannerManager.Scanners.Count;
			tbxMessage.AppendText("UFScanner GetScannerNumber: " + nScannerNumber + "\r\n");

			if (nScannerNumber == 0) {
				tbxMessage.AppendText("There's no available scanner\r\n");
				return;
			} else {
				tbxMessage.AppendText("First scanner will be used\r\n");
                //srchtxt.ReadOnly = false;
			}

			m_Scanner = m_ScannerManager.Scanners[0];
			//=========================================================================//

			//=========================================================================//
			// Open database
			//=========================================================================//
            UFD_STATUS ufd_res;

            m_Database = new UFDatabase();
			
            //// Generate connection string

            ////string szDataSource;

            string szConnection;
            ///*
            //szDataSource = "UFDatabase.mdb";
            ///*/

            ////tbxMessage.AppendText("Select a database file\r\n");
            ////OpenFileDialog dlg = new OpenFileDialog();
            ////dlg.FileName = "UFDatabase.mdb";
            ////dlg.Filter = "Database Files (*.mdb)|*.mdb";
            ////dlg.DefaultExt = "mdb";
            ////DialogResult res = dlg.ShowDialog();
            ////if (res != DialogResult.OK) {
            ////    return;
            ////}
            ////szDataSource = dlg.FileName;
            ////*/


            szConnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=UFDatabase.mdb";

            //szConnection = "Data Source=(local);Initial Catalog=Login;Integrated Security=True";

            ufd_res = m_Database.Open(szConnection, null, null);

            if (ufd_res == UFD_STATUS.OK)
            {
                tbxMessage.AppendText("DB Open: OK\r\n");
            }
            else
            {
                UFDatabase.GetErrorString(ufd_res, out m_strError);
                tbxMessage.AppendText("DB Open: " + m_strError + "\r\n");
                return;
            }

            UpdateDatabaseList();
            ////=========================================================================//

            ////=========================================================================//
             //Create matcher
            ////=========================================================================//
            //m_Matcher = new UFMatcher();
			//=========================================================================//
		}

		private void btnUninit_Click(object sender, EventArgs e) {
			//=========================================================================//
			// Uninit scanner module
			//=========================================================================//
			UFS_STATUS ufs_res;
			
			Cursor.Current = Cursors.WaitCursor;
			ufs_res = m_ScannerManager.Uninit();
			Cursor.Current = this.Cursor;
			if (ufs_res == UFS_STATUS.OK) {
				tbxMessage.AppendText("UFScanner Uninit: OK\r\n");
                //srchtxt.ReadOnly = true;
                btnClear_Click(sender, e);
                
			} else {
				UFScanner.GetErrorString(ufs_res, out m_strError);
				tbxMessage.AppendText("UFScanner Uninit: " + m_strError + "\r\n");
			}
			//=========================================================================//

			//=========================================================================//
			// Close database
			//=========================================================================//
			UFD_STATUS ufd_res;

			if (m_Database != null) {
				ufd_res = m_Database.Close();
				if (ufd_res == UFD_STATUS.OK) {
					tbxMessage.AppendText("DB Close: OK\r\n");
				} else {
					UFDatabase.GetErrorString(ufd_res, out m_strError);
					tbxMessage.AppendText("DB Close: " + m_strError + "\r\n");
				}
			}

            //lvDatabaseList.Items.Clear();
			//=========================================================================//
		}
       
		private bool ExtractTemplate(byte[] Template, out int TemplateSize)
		{
			UFS_STATUS ufs_res;
			int EnrollQuality;

			m_Scanner.ClearCaptureImageBuffer();

			tbxMessage.AppendText("Place Finger\r\n");

			TemplateSize = 0;
			while (true) {
				ufs_res = m_Scanner.CaptureSingleImage();
				if (ufs_res != UFS_STATUS.OK) {
					UFScanner.GetErrorString(ufs_res, out m_strError);
					tbxMessage.AppendText("UFScanner CaptureSingleImage: " + m_strError + "\r\n");
					return false;
				}

				ufs_res = m_Scanner.Extract(Template, out TemplateSize, out EnrollQuality);
				if (ufs_res == UFS_STATUS.OK) {
					tbxMessage.AppendText("UFScanner Extract: OK\r\n");
					break;
				} else {
					UFScanner.GetErrorString(ufs_res, out m_strError);
					tbxMessage.AppendText("UFScanner Extract: " + m_strError + "\r\n");
				}

			}

			return true;
		}

		private void btnEnroll_Click(object sender, EventArgs e) {


            UFD_STATUS ufd_res;
            UFM_STATUS ufm_res;
            // Input finger data
            byte[] Template = new byte[MAX_TEMPLATE_SIZE];
            int TemplateSize;
            // DB data
            byte[][] DBTemplate = null;
            int[] DBTemplateSize = null;
            int[] DBSerial = null;
            int DBTemplateNum=0;
            //
            int MatchIndex;
            try
            {
                ufd_res = m_Database.GetTemplateListWithSerial(out DBTemplate, out DBTemplateSize, out DBTemplateNum, out DBSerial);

            if (ufd_res != UFD_STATUS.OK)
            {

                UFDatabase.GetErrorString(ufd_res, out m_strError);
                tbxMessage.AppendText("UFD_GetTemplateListWithSerial: " + m_strError + "\r\n");
                return;
            }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
           

            if (!ExtractTemplate(Template, out TemplateSize))
            {
                return;
            }

            DrawCapturedImage(m_Scanner);

            Cursor.Current = Cursors.WaitCursor;
            m_Matcher = new UFMatcher();
            ufm_res = m_Matcher.Identify(Template, TemplateSize, DBTemplate, DBTemplateSize, DBTemplateNum, 5000, out MatchIndex);
            Cursor.Current = this.Cursor;
            if (ufm_res != UFM_STATUS.OK)
            {
                UFMatcher.GetErrorString(ufm_res, out m_strError);
                tbxMessage.AppendText("UFMatcher Identify: " + m_strError + "\r\n");
                return;
            }

            //if (MatchIndex != -1)
            //{

            //    tbxMessage.AppendText("This finger print already exist (Serial = " + DBSerial[MatchIndex] + ")\r\n");

            //    DBHandler srchVoter = new DBHandler();

            //    DataSet ds = new DataSet();

            //    ds = srchVoter.getVoterBySerial(DBSerial[MatchIndex]);

            //    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["VoterID"].ToString()))
            //    {
            //        voterIdtxt.Text = ds.Tables[0].Rows[0]["VoterID"].ToString();
            //        fnametxt.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
            //        lnametxt.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
            //        Mnametxt.Text = ds.Tables[0].Rows[0]["Middlename"].ToString();
            //        byte[] imgbyte = (byte[])ds.Tables[0].Rows[0]["img"];
            //        imgPBx.Image = byteArrayToImage(imgbyte);
            //    }

            //}
            //else
            //{

                //start enrollment of voter

                if (!ExtractTemplate(m_Template1, out m_Template1Size))
                {
                    return;
                }

                DrawCapturedImage(m_Scanner);

                UserInfoForm dlg = new UserInfoForm(false);
                // UFD_STATUS ufd_res;

                tbxMessage.AppendText("Input user data\r\n");

                if (dlg.ShowDialog(this) != DialogResult.OK)
                {

                    tbxMessage.AppendText("User data input is cancelled by user\r\n");
                    pbImageFrame.Image = null;
                    return;
                }

                ufd_res = m_Database.AddData(this.Text, dlg.FingerIndex, m_Template1, m_Template1Size, null, 0, dlg.Memo);

                //UFE30_DatabaseDemoCS.DBHandler newdata = new UFE30_DatabaseDemoCS.DBHandler();

                //int i = newdata.AddData(dlg.UserID, dlg.FingerIndex, m_Template1, m_Template1Size);

                //tbxMessage.AppendText (i.ToString());

                if (ufd_res != UFD_STATUS.OK)
                {
                    UFDatabase.GetErrorString(ufd_res, out m_strError);
                    tbxMessage.AppendText("Db AddData: " + m_strError + "\r\n");
                    pbImageFrame.Image = null;
                }
                else
                {
                    cbScanTemplateType.Enabled = false;
                    pbImageFrame.Image = null;
                }

                //if (i < 0)
                //{
                //    tbxMessage.AppendText("good job");
                //}

                UpdateDatabaseList();
            //}
		}

		private void btnIdentify_Click(object sender, EventArgs e) {

            try
            {
                UFD_STATUS ufd_res;
                UFM_STATUS ufm_res;
                // Input finger data
                byte[] Template = new byte[MAX_TEMPLATE_SIZE];
                int TemplateSize;
                // DB data
                byte[][] DBTemplate = null;
                int[] DBTemplateSize = null;
                int[] DBSerial = null;
                int DBTemplateNum;
                //
                int MatchIndex;

                ufd_res = m_Database.GetTemplateListWithSerial(out DBTemplate, out DBTemplateSize, out DBTemplateNum, out DBSerial);

                if (ufd_res != UFD_STATUS.OK)
                {

                    UFDatabase.GetErrorString(ufd_res, out m_strError);
                    tbxMessage.AppendText("DB: " + m_strError + "\r\n");
                    return;
                }

                if (!ExtractTemplate(Template, out TemplateSize))
                {
                    return;
                }

                DrawCapturedImage(m_Scanner);

                Cursor.Current = Cursors.WaitCursor;
                m_Matcher = new UFMatcher();
                ufm_res = m_Matcher.Identify(Template, TemplateSize, DBTemplate, DBTemplateSize, DBTemplateNum, 5000, out MatchIndex);
                Cursor.Current = this.Cursor;
                if (ufm_res != UFM_STATUS.OK)
                {
                    UFMatcher.GetErrorString(ufm_res, out m_strError);
                    tbxMessage.AppendText("UFMatcher Identify: " + m_strError + "\r\n");
                    return;
                }

                if (MatchIndex != -1)
                {

                    tbxMessage.AppendText("Identification succeed (Serial = " + DBSerial[MatchIndex] + ")\r\n");

                    DBHandler srchVoter = new DBHandler();

                    DataSet ds = new DataSet();

                    ds = srchVoter.getVoterBySerial(DBSerial[MatchIndex]);

                    StringBuilder str = new StringBuilder();
                    str.Append("INDEX NUMBER : " + ds.Tables[0].Rows[0]["UserID"].ToString());
                    str.AppendLine();
                    str.Append("FIRSTNAME : " + ds.Tables[0].Rows[0]["First_Name"].ToString());
                    str.AppendLine();
                    str.Append("MIDDLENAME : " + ds.Tables[0].Rows[0]["Other_Name"].ToString());
                    str.AppendLine();
                    str.Append("LASTNAME : " + ds.Tables[0].Rows[0]["Last_Name"].ToString());
                    str.AppendLine();
                    str.Append("PROGRAMME : " + ds.Tables[0].Rows[0]["Programme_Offered"].ToString());
                    str.AppendLine();
                    str.Append("COURSE : " + ds.Tables[0].Rows[0]["Course_Offered"].ToString());

                    MessageBox.Show(str.ToString());


                    //if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["UserID"].ToString()))
                    //{
                    //    //voterIdtxt.Text = ds.Tables[0].Rows[0]["VoterID"].ToString();
                    //    //fnametxt.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
                    //    //lnametxt.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
                    //    //Mnametxt.Text = ds.Tables[0].Rows[0]["Middlename"].ToString();
                    //    byte[] imgbyte = (byte[])ds.Tables[0].Rows[0]["img"];
                    //    //imgPBx.Image = byteArrayToImage(imgbyte);
                    //}

                    //DialogResult sms = MessageBox.Show("Do you want to Activate this voter Number", "Account Activation", MessageBoxButtons.YesNo);

                    //if (sms == DialogResult.Yes)
                    //{

                    //    DBHandler voterAct = new DBHandler();

                    //    int i = voterAct.ActivateVoter("", "Active");

                    //    if (i < 0)
                    //    {
                    //        //imgPBx.Image = null;
                    //        //voterIdtxt.Text = "";
                    //        //fnametxt.Text = "";
                    //        //Mnametxt.Text = "";
                    //        //lnametxt.Text = "";
                    //        pbImageFrame.Image = null;
                    //        //srchtxt.Text = "";

                    //        tbxMessage.AppendText("Voter Activation : Successfull");
                    //    }

                    //}
                    //else
                    //{

                    //}

                }
                else
                {
                    tbxMessage.AppendText("Identification failed\r\n");
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
		}

		private void btnDeleteAll_Click(object sender, EventArgs e) {
			UFD_STATUS ufd_res;

			ufd_res = m_Database.RemoveAllData();
			if (ufd_res == UFD_STATUS.OK) {
				tbxMessage.AppendText("DB RemoveAllData: OK\r\n");
				UpdateDatabaseList();
			} else {
				UFDatabase.GetErrorString(ufd_res, out m_strError);
				tbxMessage.AppendText("DB RemoveAllData: " + m_strError + "\r\n"); 
			}
		}

        //private void btnSelectionDelete_Click(object sender, EventArgs e) {
        //    UFD_STATUS ufd_res;
        //    int Serial;

        //    if (lvDatabaseList.SelectedIndices.Count == 0) {
        //        tbxMessage.AppendText("Select data\r\n");
        //        return;
        //    } else {
        //        Serial = Convert.ToInt32(lvDatabaseList.SelectedItems[0].SubItems[DATABASE_COL_SERIAL].Text);
        //    }

        //    ufd_res = m_Database.RemoveDataBySerial(Serial);
        //    if (ufd_res == UFD_STATUS.OK) {
        //        tbxMessage.AppendText("DB RemoveDataBySerial: OK\r\n");
        //        UpdateDatabaseList();
        //    } else {
        //        UFDatabase.GetErrorString(ufd_res, out m_strError);
        //        tbxMessage.AppendText("DB RemoveDataBySerial: " + m_strError + "\r\n"); 
        //    }
        //}

        //private void btnSelectionUpdateUserInfo_Click(object sender, EventArgs e) {
        //    UserInfoForm dlg = new UserInfoForm(true);
        //    UFD_STATUS ufd_res;
        //    int Serial;

        //    if (lvDatabaseList.SelectedIndices.Count == 0) {
        //        tbxMessage.AppendText("Select data\r\n");
        //        return;
        //    } else {
        //        Serial = Convert.ToInt32(lvDatabaseList.SelectedItems[0].SubItems[DATABASE_COL_SERIAL].Text);
        //        dlg.UserID = lvDatabaseList.SelectedItems[0].SubItems[DATABASE_COL_USERID].Text;
        //        dlg.FingerIndex = Convert.ToInt32(lvDatabaseList.SelectedItems[0].SubItems[DATABASE_COL_FINGERINDEX].Text);
        //        dlg.Memo = lvDatabaseList.SelectedItems[0].SubItems[DATABASE_COL_MEMO].Text;
        //    }

        //    tbxMessage.AppendText("Update user data\r\n");
        //    tbxMessage.AppendText("UserID and FingerIndex will not be updated\r\n");
        //    if (dlg.ShowDialog(this) != DialogResult.OK) {
        //        tbxMessage.AppendText("User data input is cancelled by user\r\n");
        //        return;
        //    }

        //    ufd_res = m_Database.UpdateDataBySerial(Serial, null, 0, null, 0, dlg.Memo);
        //    if (ufd_res == UFD_STATUS.OK) {
        //        tbxMessage.AppendText("UFD_UpdateDataBySerial: OK\r\n");
        //        UpdateDatabaseList();
        //    } else {
        //        UFDatabase.GetErrorString(ufd_res, out m_strError);
        //        tbxMessage.AppendText("DB UpdateDataBySerial: " + m_strError + "\r\n");
        //    }
        //}

        //private void btnSelectionUpdateTemplate_Click(object sender, EventArgs e) {
        //    UFD_STATUS ufd_res;
        //    int Serial;

        //    if (lvDatabaseList.SelectedIndices.Count == 0) {
        //        tbxMessage.AppendText("Select data\r\n");
        //        return;
        //    } else {
        //        Serial = Convert.ToInt32(lvDatabaseList.SelectedItems[0].SubItems[DATABASE_COL_SERIAL].Text);
        //    }

        //    if (!ExtractTemplate(m_Template1, out m_Template1Size)) {
        //        return;
        //    }

        //    DrawCapturedImage(m_Scanner);

        //    ufd_res = m_Database.UpdateDataBySerial(Serial, m_Template1, m_Template1Size, null, 0, null);
        //    if (ufd_res == UFD_STATUS.OK) {
        //        tbxMessage.AppendText("UFD_UpdateDataBySerial: OK\r\n");
        //        UpdateDatabaseList();
        //    } else {
        //        UFDatabase.GetErrorString(ufd_res, out m_strError);
        //        tbxMessage.AppendText("DB UpdateDataBySerial: " + m_strError + "\r\n");
        //    }
        //}

        //private void btnSelectionVerify_Click(object sender, EventArgs e) {
        //    UFD_STATUS ufd_res;
        //    UFM_STATUS ufm_res;
        //    int Serial;
        //    // Input finger data
        //    byte[] Template = new byte[MAX_TEMPLATE_SIZE];
        //    int TemplateSize;
        //    //
        //    bool VerifySucceed;

        //    if (lvDatabaseList.SelectedIndices.Count == 0) {
        //        tbxMessage.AppendText("Select data\r\n");
        //        return;
        //    } else {
        //        Serial = Convert.ToInt32(lvDatabaseList.SelectedItems[0].SubItems[DATABASE_COL_SERIAL].Text);
        //    }

        //    ufd_res = m_Database.GetDataBySerial(Serial, 
        //        out m_UserID, out m_FingerIndex, m_Template1, out m_Template1Size, m_Template2, out m_Template2Size, out m_Memo);
        //    if (ufd_res != UFD_STATUS.OK) {
        //        UFDatabase.GetErrorString(ufd_res, out m_strError);
        //        tbxMessage.AppendText("DB UpdateDataBySerial: " + m_strError + "\r\n");
        //        return;
        //    }

        //    if (!ExtractTemplate(Template, out TemplateSize)) {
        //        return;
        //    }

        //    DrawCapturedImage(m_Scanner);

        //    m_Matcher = new UFMatcher();

        //    ufm_res = m_Matcher.Verify(Template, TemplateSize, m_Template1, m_Template1Size, out VerifySucceed);
        //    if (ufm_res != UFM_STATUS.OK) {
        //        UFMatcher.GetErrorString(ufm_res, out m_strError);
        //        tbxMessage.AppendText("UFMatcher Verify: " + m_strError + "\r\n");
        //        return;
        //    }

        //    if (VerifySucceed) {
        //        tbxMessage.AppendText("Verification succeed (Serial = " + Serial + ")\r\n");
        //    } else {
        //        tbxMessage.AppendText("Verification failed\r\n");
        //    }
        //}

        private void bScanTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_Scanner == null)
            {
                tbxMessage.AppendText("No Scanner Instance\r\n");
                return;
            }
          
            switch (this.cbScanTemplateType.SelectedIndex)
            {
                case 0:
                    m_Scanner.nTemplateType = 2001;
                    break;
                case 1:
                    m_Scanner.nTemplateType = 2002;
                    break;
                case 2:
                    m_Scanner.nTemplateType = 2003;
                    break;
            }

        }

        //private void srchtxt_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DBHandler srchVoter = new DBHandler();

        //        DataSet ds = new DataSet();

        //        ds = srchVoter.SearchVoter(srchtxt.Text);

        //        if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["VoterID"].ToString()))
        //        {
        //            voterIdtxt.Text = ds.Tables[0].Rows[0]["VoterID"].ToString();
        //            fnametxt.Text = ds.Tables[0].Rows[0]["firstname"].ToString();
        //            lnametxt.Text = ds.Tables[0].Rows[0]["lastname"].ToString();
        //            Mnametxt.Text = ds.Tables[0].Rows[0]["Middlename"].ToString();
        //            byte[] imgbyte = (byte[]) ds.Tables[0].Rows[0]["img"];
        //            imgPBx.Image = byteArrayToImage(imgbyte);
        //        }
        //    }
        //    catch(System.Exception ex)
        //    {
        //      // MessageBox.Show(ex.Message.ToString());

        //        voterIdtxt.Text = "";
        //        fnametxt.Text = "";
        //        lnametxt.Text = "";
        //        Mnametxt.Text = "";
        //        imgPBx.Image = null;
        //    }

        //}

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }


        public void OpenVoterPage()
        {

            string url = "http://localhost/voter";

            System.Diagnostics.Process proc = new System.Diagnostics.Process();

            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(url);

            proc.StartInfo = startInfo;

            proc.Start();
        }

        private void srchtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char CheckChar = e.KeyChar;

            if(Char.IsNumber(CheckChar) || char.IsControl(CheckChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void  IndentifyandRegister()
        {
  
           
        }
	}
}