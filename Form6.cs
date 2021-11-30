using System;
using System.Collections.Generic;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace KoforiduaPolyBiometric_Attendance
{
    public partial class Form6 : Form
    {
        GetInit cn = new GetInit(); 
            //SqlConnection connection = new SqlConnection("Data Source=JUSTWILLIAMS/STEV;Initial Catalog=Login;Integrated Security=True")


            //MySqlCommand cmd = new  MySqlCommand();
        public Form6()
        {
           
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAttenVerify_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = cn.Initialize();
             
            try {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM enrollment_table WHERE Index_Number=@Index_Number",connection);
            
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@Index_Number", txtAttenIndexNumber.Text.Trim());
                connection.Open();
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
                var i = dt.Rows.Count;
                if (i > 0)
                {
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    dataReader.Read();
                    //Read the data and store them in the list

                    txtAttenLastName.Text = dataReader["Last_Name"]+"";
                    txtAttenFirstName.Text = dataReader["First_Name"] + "";
                    txtAttenOtherName.Text = dataReader["Other_Name"] + "";
                    txtAttenDOB.Text = dataReader["Date_Of_Birth"] + "";
                    txtAttenAge.Text = dataReader["Age"] + "";
                    txtAttenGender.Text = dataReader["Gender"] + "";
                    txtAttenProgramme.Text = dataReader["Programme_Offered"] + "";
                    txtAttenCourse.Text = dataReader["Course_Offered"] + "";
                    txtAttenLevel.Text = dataReader["Level"] + "";
                   // txtAttenDate.Text = dataReader["Date_Of_Registration"] + "";
                
                   Bitmap pix  = new Bitmap(dataReader["Image"]+"");
                    if (pix.Height>3) {
                        AttenPix.Image = pix;
                            }
     
                }
                else
                {
                    MessageBox.Show("Invalid Matric Number");
                }

            }
            catch(Exception ext)
            {
                string err = "Error: "+ext.ToString();
                MessageBox.Show(err);
            }
        }
    }
}
