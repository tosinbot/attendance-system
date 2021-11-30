using System; 
using System.Data;
using System.Drawing; 
using System.Windows.Forms; 
using System.Data.OleDb;


namespace KoforiduaPolyBiometric_Attendance
{
    public partial class LOGIN : Form
    {
        Boolean login = false;

        OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=admin.mdb;Persist Security Info=True");
       
        OleDbDataAdapter dap;
        DataTable dt = new DataTable();
        public LOGIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            dap = new OleDbDataAdapter("Select * From admin_account WHERE username='" + txtUserName.Text.Trim() + "' AND password='" + txtPassword.Text.Trim()+"'", connection);
            dap.Fill(dt);
            if (dt.Rows.Count < 1)
            {
                if (panelNotify.Height == 0)
                {
                    msgLabel.Text = "Invalid Email or Password";
                    msgLabel.ForeColor = Color.Red;
                    timer1.Start();

                }
                else if (panelNotify.Height == 40)
                {
                    timer2.Start();
                    msgLabel.Text = "";
                }
            }
            else
            {
                if (panelNotify.Height == 0)
                {
                    msgLabel.Text = "Login Successful";
                    msgLabel.ForeColor = Color.White;
                    timer1.Start();
                    login = true;
                }
                else if (panelNotify.Height == 50)
                {
                    timer2.Start();
                    msgLabel.Text = "";

                }
                dt.Clear();
            }
            connection.Close();
            ///// Login Authentication


            //if (txtUserName.Text.Trim() == "Admin" & txtPassword.Text.Trim() == "1234")
            //{
            //    Main_Form f2 = new Main_Form();
            //    f2.Show();
            //    this.Hide();
            //    txtUserName.Clear();
            //    txtPassword.Clear();
            //    ///////
            //}

            //    else if  (txtUserName.Text == "Admin2" & txtPassword.Text == "System02")
            //    {
            //    Form f6 = new Form6 ();   
            //    f6.Show();
            //    this.Hide();
            //    txtUserName.Clear();
            //    txtPassword.Clear();


            //  //////  
            //}
            //else if (txtUserName.Text != "Admin" & txtPassword.Text != "System01")
            //{
            //    MessageBox.Show("Invalid Username or Password");
            //}
            //else if (txtUserName.Text == "" & txtPassword.Text == "")
            //{
            //    MessageBox.Show("Username and Password required");
            //}
            //else if (txtUserName.Text != "" & txtPassword.Text != "")
            //{
            //    MessageBox.Show("Invalid Username or Password");
            //}
            //else if (txtUserName.Text != "" & txtPassword.Text != "")
            //{
            //    MessageBox.Show("Password required");
            //}


            ///// End of Login Authentication
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Windows.Forms.Application.Exit();
        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'adminDataSet.admin_account' table. You can move, or remove it, as needed.
            this.admin_accountTableAdapter.Fill(this.adminDataSet.admin_account);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (panelNotify.Height != 40)
            {
                panelNotify.Height += 5;
                if (panelNotify.Height == 40)
                {
                    timer1.Stop();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (panelNotify.Height != 0)
            {
                panelNotify.Height -= 5;
                if (panelNotify.Height == 0)
                {
                    timer2.Stop();
                    if (login == true)
                    {
                        // If login is true, show main form
                        Form home = new Main_Form();
                        home.Show();
                        this.Hide();
                        txtUserName.Clear(); // clear all inputs
                        txtPassword.Clear();
                    }
                }
            }
        }

        private void msgBtn_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
    }
}
