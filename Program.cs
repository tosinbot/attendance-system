using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace KoforiduaPolyBiometric_Attendance
{
    static class Program
    {
       
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GetInit init = new GetInit();
            try
            {
                init.Initialize();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting: ", e.Message);
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LOGIN());
        }
     
    }
    class GetInit{
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public MySqlConnection Initialize()
        {

              server = "162.253.155.225";
             database = "330986";
             uid = "330986@localhost";
            password = "jesusmega99360";
           // server = "localhost";
           // database = "cs_noun";
           // uid = "root";
           // password ="";

            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();
            connBuilder.Add("DATABASE",database);
            connBuilder.Add("DATA SOURCE", server);
            connBuilder.Add("USER ID", uid);
            connBuilder.Add("PASSWORD",  password);
            string datasource = "server=162.253.155.225;database=330986;uid=330986;pwd=jesusmega99360;";
            //string connectionString = "server=" + server + ";" + "database=" + database + ";" + "uid=" + uid + ";" + "pwd=" + password + ";";
            return connection = new MySqlConnection(datasource);
            //return  connection = new MySqlConnection(connBuilder.ConnectionString); 
             
            
        }


    }

}
