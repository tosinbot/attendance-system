using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KoforiduaPolyBiometric_Attendance
{
    public partial class Main_Form : Form
    {
        public Main_Form()
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
            Form frm = new Form4();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //f1
        }

        private void button4_Click(object sender, EventArgs e)
        {
           //f2
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form frm = new LOGIN ();
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

        private void Main_Form_Load(object sender, EventArgs e)
        {

        }

        private void newAttendBtn_Click(object sender, EventArgs e)
        {
            Form frm = new Form6();
            frm.Show();
            this.Visible = true;
            this.Hide();
        }
    }
}
