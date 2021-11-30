using System; 
using System.Windows.Forms;

namespace KoforiduaPolyBiometric_Attendance
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
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
            Form frm = new Form6();
            frm.Show();
            this.Visible = true;
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //f2

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //f1

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //Calculation of Age 

            int Age = DateTime.Today.Year - dateTimePicker1.Value.Year;

            // CurrentYear - BirthDate

            txtVeriAge.Text = Age.ToString(); 

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form frm = new Main_Form();
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

        private void txtVeriCourse_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbVeriGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbVeriGender.DropDownStyle = ComboBoxStyle.DropDownList;
            /////
        }

        private void cmbVeriLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Disable combobox
            cmbVeriLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            ////

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void txtVeriIndexNumber_TextChanged(object sender, EventArgs e)
        {
            if (this.txtVeriIndexNumber.Text=="")
            {

            }
        }

        private void txtVeriLastName_TextChanged(object sender, EventArgs e)
        {
            if (this.txtVeriLastName.Text == "")
            {
                ToolTip toolTip1 = new ToolTip();
                toolTip1.AutomaticDelay = 5000;
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.txtVeriLastName, "Please Enter Index Number");
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {

        }
    }
}
