using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahiApplication.Classes
{
    class ManageWorker
    {
        public int WorkerID { get; set; }
        public string WorkerName { get; set; }
        public string WContactNo { get; set; }
        public string WAddress { get; set; }
        public string WGoldGiven { get; set; }
        public string WGoldRecieved { get; set; }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShahiDB"].ConnectionString);
        public int insertWorker()
        {try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Insert_tblWorker";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@Name", WorkerName);
                cmd.Parameters.AddWithValue("@Contact", WContactNo);
                cmd.Parameters.AddWithValue("@Address", WAddress);
                cmd.Parameters.AddWithValue("@GoldGiven", WGoldGiven);
                cmd.Parameters.AddWithValue("@GoldRecived", WGoldRecieved);

                int RowsAffected = (int)cmd.ExecuteNonQuery();
                if (RowsAffected > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
            finally
            {con.Close();}
        }
        public DataTable getAllWorker()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SelectAllfrmWorker";
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
