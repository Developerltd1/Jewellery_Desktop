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
    class ManageOrder
    {
        public int OrderID { get; set; }
        public int ReciptNo { get; set; }
        public DateTime CurrentDate { get; set; }
        public DateTime DueDate { get; set; }
        public int Costumer_ID { get; set; }
        public double TotalBill { get; set; }
        public double Advance { get; set; }
        public double Balance { get; set; }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShahiDB"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();

        public int addOrder()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertOrder";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@ReciptNo", ReciptNo);
                cmd.Parameters.AddWithValue("@CurrentDate", CurrentDate);
                cmd.Parameters.AddWithValue("@DueDate", DueDate);
                cmd.Parameters.AddWithValue("@Costumer_ID", Costumer_ID);
                cmd.Parameters.AddWithValue("@GrandTotal", TotalBill);
                cmd.Parameters.AddWithValue("@Advance", Advance);
                cmd.Parameters.AddWithValue("@Balance", Balance);

                SqlParameter oparam = new SqlParameter("@OrderID", SqlDbType.Int);
                oparam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(oparam);



                int RowsAffected = (int)cmd.ExecuteNonQuery();

                int retvl = Convert.ToInt32(oparam.Value);

                if (RowsAffected > 0)
                    return retvl;
                else

                    return 0;
            }
            catch (SqlException)
            {
                return -1;
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

        public DataTable checkInvoice(int ReciptNo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_checkinvoicetbl";
            cmd.Parameters.AddWithValue("@ReciptNo", ReciptNo);
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();

            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();
            return dt;


        }

        public int checkDuplicateInvoiceNo(int ReciptNo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "uap_checkReceiptNo";
            cmd.Parameters.AddWithValue("@RcptNo", ReciptNo);
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();

            da.SelectCommand = cmd;
            da.Fill(dt);

            int res = dt.Rows.Count > 0 ? 1 : 0;

            con.Close();
            return res;

        }

        public int updateInvoice()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateInvoice";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@ReciptNo", ReciptNo);
                cmd.Parameters.AddWithValue("@TotalBill", TotalBill);
                cmd.Parameters.AddWithValue("@Advance", Advance);
                cmd.Parameters.AddWithValue("@Balance", Balance);
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
            {
                con.Close();

            }
        }

        public int gettOrder_by_RecpitNo()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetOrder_by_RecpitNo";
                cmd.Connection = con;

                DataTable dt = new DataTable();
                da.SelectCommand = cmd;
                da.Fill(dt);
                int res = 0;
                if (dt.Rows.Count >= 1)
                {
                    res = dt.Rows[0][0] == null ? 0 : Convert.ToInt32(dt.Rows[0][0]);
                }
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable checkInvoice_by_ReciptNo(int ReciptNo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_checkInvoice_by_ReciptNo";
            cmd.Parameters.AddWithValue("@ReciptNo", ReciptNo);
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public int updateInvoiceCheckOrder()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateInvoice_CheckOrder";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@ReciptNo", ReciptNo);
                cmd.Parameters.AddWithValue("@GrandTotal", TotalBill);
                cmd.Parameters.AddWithValue("@Advance", Advance);
                cmd.Parameters.AddWithValue("@Balance", Balance);
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
            {
                con.Close();

            }
        }
     
    }
}
