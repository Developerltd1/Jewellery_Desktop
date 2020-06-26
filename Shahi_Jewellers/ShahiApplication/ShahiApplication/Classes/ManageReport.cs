using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShahiApplication.Classes
{
    class ManageReport
    {
        public static DataTable GetSalesReport(DateTime FromDate, DateTime ToDate)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = null;
            SqlCommand cmd = null;
            try
            {
                string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ShahiDB"].ToString();
                conn = new SqlConnection(ConnectionString);
                cmd = new SqlCommand("usp_SalesReport", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@fromdate", FromDate);
                cmd.Parameters.AddWithValue("@toDate", ToDate);

                conn.Open();
                Adapter.Fill(dt);
                conn.Close();
            
                return dt;
            }
            catch (Exception ex)
            {
              
                //Return Value
                return dt;
            }
            finally
            {
                conn.Dispose();
                cmd.Dispose();
            }
        }

    }
}
