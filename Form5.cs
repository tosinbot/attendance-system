using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KoforiduaPolyBiometric_Attendance
{
    public partial class Form5 : Form
    {
        GetInit cn = new GetInit();
        //SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=Login;Integrated Security=True");
        MySqlConnection connection;
        MySqlCommand mcd;
        MySqlDataReader mdr; 
        String s;

        public Form5()
        {
         connection = cn.Initialize();
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            ////////////////
            ////    connection.Open();

            /////   mcd = new SqlCommand("SELECT index_number as [INDEX NUMBER], LSAT_NAME AS [LAST NAME], FIRST_NAME AS [FIRST NAME], OTHER_NAME AS [OTHER NAME], DATE_OF_BIRTH AS [DATE OF BIRTH], AGE AS [AGE], GENDER AS [GENDER], PROGAMME_OFFERED AS [PROGRAMME OFFERING], COURSE_OFFERED AS [COURSE OFFERING], LEVEL AS [LEVEL], IMAGE AS [PICTURE] FROM enrollment_tablee ORDER BY FIRST_NAME WHERE like '" & textBox6.Text & "%' ");

            ////    mdr  = New SqlDataAdapter(mcd);
            ///   myDataSet  = New DataSet();
            ///   mdr.Fill(myDataSet, "enrollment_tablee");
            ////  DataGridView1.DataSource = myDataSet.Tables("enrollment_tablee").DefaultView;
            ////   connection.Close();

            ////////////////////////////  
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //f1
        }

        private void ProInfo_Click(object sender, EventArgs e)
        {
            //f2
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form frm = new Main_Form();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////Search
            try
            {
                connection.Open();
                s = "select * from Enrollment_Table where Index_Number=" + int.Parse(txtUpdateIndexNumber.Text);
                mcd = new MySqlCommand(s, connection);
                mdr = mcd.ExecuteReader();
                if (mdr.Read())
                {
                    txtUpdateLastName.Text = mdr.GetString(1);
                    txtUpdateFirstName.Text = mdr.GetString(2);
                    txtUpdateOtherName.Text = mdr.GetString(3);
                    UpdateDOB.Text = mdr.GetString(4);
                    txtUpdeateAge.Text = mdr.GetString(5);
                    cmbUpdateGender.Text = mdr.GetString(6);
                    cmbUpdateProgramme.Text = mdr.GetString(7);
                    cmbUpdateCourse.Text = mdr.GetString(8);
                    cmbUpdateLevel.Text = mdr.GetString(9);

                }
                else
                {
                    MessageBox.Show("No DATA");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                connection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        { 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            // Uploading a picture from a file

            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp) | *.jpg; *.jpeg; *.gif; *.bmp";
            if
                (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = new Bitmap(open.FileName);

                ///// end 

            }
        }

        private void cmbUpdateGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbUpdateGender.DropDownStyle = ComboBoxStyle.DropDownList;
            /////

        }

        private void cmbUpdateProgramme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbUpdateProgramme.DropDownStyle = ComboBoxStyle.DropDownList;
            ////

        }

        private void cmbUpdateCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbUpdateCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            ///////

        }

        private void cmbUpdateLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbUpdateLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            ////

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtUpdateLastName.Text = "";
            txtUpdateFirstName.Text = "";
            txtUpdateOtherName.Text = "";
            dateTimePicker1.Text = "";
            txtUpdeateAge.Text = "";
            cmbUpdateGender.Text = "";
            txtUpdateIndexNumber.Text = "";
            cmbUpdateProgramme.Text = "";
            cmbUpdateCourse.Text = "";
            cmbUpdateLevel.Text = "";
            pictureBox2.ResetText();
        }
    }
}
