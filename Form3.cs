using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace KoforiduaPolyBiometric_Attendance
{
    public partial class Form3 : Form
    {

        Bitmap img;
        //SqlConnection cn = new SqlConnection(@"Data Source=localhost;Initial Catalog=Login;Integrated Security=True");
        // SqlCommand cmd = new SqlCommand();
        // SqlDataReader dr;

        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = new Form4();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form frm = new Form5();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //f1
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //f2
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Uploading a picture from a file

            OpenFileDialog open = new OpenFileDialog();

            open.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp) | *.jpg; *.jpeg; *.gif; *.bmp";
            if
                (open.ShowDialog() == DialogResult.OK)
            {
                img = new Bitmap(open.FileName);
                pictureBox2.Image = img;

            }
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {



        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Calculation of Age 

            int age = 0;
            int year = dateTimePicker1.Value.Year;
            int month = dateTimePicker1.Value.Day;
            age = DateTime.Today.Year - year;
            txtAge.Text = age.ToString();



        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutomaticDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.txtLastName, "Please Enter Last Name ");

            Char ch = e.KeyChar;
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;


            }
            if (this.txtLastName.Text == "")
            {
                errorProvider1.SetError(this.txtLastName, "Please fill the required field");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form frm = new Form3();
            frm.Show();
            this.Visible = true;
            this.Hide();

        }


        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtFirstName.Text == "")
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.AutomaticDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.txtFirstName, "Please Enter First Name");


                Char ch = e.KeyChar;
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;
                }
                if (txtFirstName.Text == "")
                {
                    errorProvider1.SetError(txtFirstName, "Please fill the required field");
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.txtIndexNum.Text == "")
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.AutomaticDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.txtIndexNum, "Please Enter Index Number");
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbProgramme.DropDownStyle = ComboBoxStyle.DropDownList;

            //////


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form frm = new Main_Form();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        /////Student Enrollment 
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            try
            {
                GetInit cn = new GetInit();
                MySqlConnection connection = cn.Initialize();
                //SqlConnection connection = new SqlConnection("Data Source=JUSTWILLIAMS/STEV;Initial Catalog=Login;Integrated Security=True")

                MySqlCommand checker = new MySqlCommand("SELECT * FROM enrollment_table WHERE Index_Number=@Index_Number", connection);

                checker.Connection = connection;
                checker.Parameters.AddWithValue("@Index_Number", this.txtIndexNum.Text.Trim());
                connection.Open();
                checker.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(checker);
                 
                if (this.txtIndexNum.Text == "")
                {
                    errorProvider1.SetError(this.txtIndexNum, "Please fill the required field");
                }
                else if (this.txtFirstName.Text == "")
                {
                    errorProvider1.SetError(this.txtFirstName, "Please fill the required field");
                }

                else if (this.txtAge.Text == "")
                {
                    errorProvider1.SetError(this.txtAge, "Please fill the required field");
                }
                else if (this.cmbGender.Text == "")
                {
                    errorProvider1.SetError(this.cmbGender, "Please fill the required field");
                }

                else if (this.cmbProgramme.Text == "")
                {
                    errorProvider1.SetError(this.cmbCourse, "Please fill the required field");
                }
                else if (this.txtLastName.Text == "")
                {
                    errorProvider1.SetError(this.txtLastName, "Please fill the required field");
                }
                else if (this.cmbProgramme.Text == "")
                {
                    errorProvider1.SetError(this.cmbProgramme, "Please fill the required field");
                }
                else if (IsEmpty(img))
                {
                    MessageBox.Show("Profile Passport Photograph Required");
                }
                else
                {
                    da.Fill(dt);

                    var i = dt.Rows.Count;
                    if (i > 0)
                    {
                        MessageBox.Show("Already Registered");
                    }
                    else
                    {

                        //MySqlCommand cmd = new  MySqlCommand();
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO Enrollment_Table (Index_Number, Last_Name, First_Name, Other_Name, Date_of_Birth, Age, Gender, Programme_Offered, Course_Offered, Level, Image) VALUES (@Index_Number, @Last_Name, @First_Name, @Other_Name, @Date_of_Birth, @Age, @Gender, @Programme_Offered, @Course_Offered, @Level, @Image)");
                         cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@Index_Number", txtIndexNum.Text);
                        cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@Other_Name", txtOtherName.Text);
                        cmd.Parameters.AddWithValue("@Date_of_Birth", dateTimePicker1.Value);
                        cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                        cmd.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        cmd.Parameters.AddWithValue("@Programme_Offered", cmbProgramme.Text);
                        cmd.Parameters.AddWithValue("@Course_Offered", cmbCourse.Text);
                        cmd.Parameters.AddWithValue("@Level", cmbLevel.Text);
                        cmd.Parameters.AddWithValue("@Image", img);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Enrolled Successfully");

                        txtAge.Clear();
                        txtFirstName.Clear();
                        txtIndexNum.Clear();
                        txtOtherName.Clear();
                        txtLastName.Clear();
                        cmbLevel.Text = "";
                        cmbProgramme.Text = "";
                        cmbCourse.Text = "";
                    }
                }
                connection.Close();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        bool IsEmpty(Bitmap image)
        {
            return (image == null);
        }

        private void cmbCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////disable combobox 
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            //////
            cmbCourse.Enabled = false;


        }

        private void txtIndexNum_TextChanged(object sender, EventArgs e)
        {
            if (this.txtIndexNum.Text == "")
            {

                ToolTip toolTip1 = new ToolTip();
                toolTip1.AutomaticDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.txtIndexNum, "Please Enter Index Number");
            }

        }

        private void txtOtherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.txtOtherName.Text == "")
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.AutomaticDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.txtOtherName, "Please Enter Other Name");

                Char ch = e.KeyChar;
                if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = true;

                    txtOtherName.Clear();

                }
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cmbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbGender.DropDownStyle = ComboBoxStyle.DropDownList;
            ///////

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Kindly Ensure you have Enrolled Student Before Capturing");

            Suprema.UFE30_DatabaseDemo newfrm = new Suprema.UFE30_DatabaseDemo(txtIndexNum.Text);
            newfrm.Text = txtIndexNum.Text;
            newfrm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
