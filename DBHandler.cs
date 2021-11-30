using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace UFE30_DatabaseDemoCS
{
    class DBHandler
    {
        SqlConnection conn = new SqlConnection("Data Source=JUSTWILLIAMS-PC\\STEV;Initial Catalog=Login;User ID=sa;Password=p@$$word");

        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public int AddData(string UserId, int FingerIndex, object Temp1, object temp2)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT into fingerPrints (UserId,fingerIndex,Template1,Template2) VALUES ('" + UserId + "','" + FingerIndex + "','" + Temp1 + "','" + temp2 + "')";
            int i = cmd.ExecuteNonQuery();

            conn.Close();
            cmd.Dispose();

            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getTemp";
            cmd.Parameters.AddWithValue("@Temp1", Temp1);
  
            da.SelectCommand = cmd;

            System.Data.DataSet ds = new DataSet();

            da.Fill(ds);

            i = ds.Tables[0].Rows.Count;

            conn.Close();
            cmd.Dispose();

            return i;
        }

        public DataSet SearchVoter(string VoterID)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SearchVoter";
            cmd.Parameters.AddWithValue("@VoterID", VoterID);

            da.SelectCommand = cmd;

            DataSet ds = new DataSet();

            da.Fill(ds);

            conn.Close();
            cmd.Dispose();
            cmd.Parameters.Clear();

            return ds;
        }

        public int ActivateVoter(string VoterID, string Status)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ActivateVoter";
            cmd.Parameters.AddWithValue("@voterID", VoterID);
            cmd.Parameters.AddWithValue("@Status", Status);

            int i = cmd.ExecuteNonQuery();

            conn.Close();
            cmd.Dispose();
            cmd.Parameters.Clear();

            return i;

        }

        public DataSet getVoterBySerial(int Serial)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getVoterBySerial";
            cmd.Parameters.AddWithValue("@Serial",Serial);

            da.SelectCommand = cmd;

            DataSet ds = new DataSet();

            da.Fill(ds);

            conn.Close();
            cmd.Dispose();
            cmd.Parameters.Clear();

            return ds;
        }
    }
}
