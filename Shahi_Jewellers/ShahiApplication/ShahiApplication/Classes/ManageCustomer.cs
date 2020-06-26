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
    class ManageCustomer
    {
        public int CostumerID { get; set; }
        public string CostumerName { get; set; }
        public string MobileNo { get; set; }
        public string CAddress { get; set; }



        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShahiDB"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();

        public int addCostumer()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertCustomer";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@CustomerName", CostumerName);
                cmd.Parameters.AddWithValue("@MobileNo", MobileNo);
                cmd.Parameters.AddWithValue("@CAddress", CAddress);

                SqlParameter oparam = new SqlParameter("@CostumerID", SqlDbType.Int);
                oparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oparam);



                int RowsAffected = (int)cmd.ExecuteNonQuery();

                int retvl = Convert.ToInt32(oparam.Value);

                if (RowsAffected > 0)
                    return retvl;
                else

                    return 0;
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();

            }

        }

  
    }
}
