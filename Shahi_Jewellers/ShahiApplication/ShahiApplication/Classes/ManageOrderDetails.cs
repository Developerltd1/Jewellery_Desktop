using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShahiApplication.Classes
{
    class ManageOrderDetails
    {

        public int OrderDetailID { get; set; }
        public string TagNo { get; set; }
        public int Category_ID { get; set; }
        public int Item_ID { get; set; }
        public double Polish { get; set; }
        public double Kaat { get; set; }
        public double Grams { get; set; }
        public double Tola { get; set; }
        public double Masha { get; set; }
        public double Ratti { get; set; }
        public double GoldRate { get; set; }
        public double SubTotal { get; set; }
        public double Labour { get; set; }
        public double TotalPrice { get; set; }
        public int Order_ID { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string ItemImage { get; set; }
        public int Issue_Qty { get; set; }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShahiDB"].ConnectionString);
        SqlDataAdapter da = new SqlDataAdapter();
       
        public int addOrderDetails()
        {

            try
            {

                SqlCommand cmd = new SqlCommand();


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertOrderDetails";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@TagNo", TagNo);
                cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
                cmd.Parameters.AddWithValue("@Polish", Polish);
                cmd.Parameters.AddWithValue("@Kaat", Kaat);
                cmd.Parameters.AddWithValue("@Grams", Grams);
                cmd.Parameters.AddWithValue("@Tola", Tola);
                cmd.Parameters.AddWithValue("@Masha", Masha);
                cmd.Parameters.AddWithValue("@Ratti", Ratti);
                cmd.Parameters.AddWithValue("@GoldRate", GoldRate);
                cmd.Parameters.AddWithValue("@SubTotal", SubTotal);
                cmd.Parameters.AddWithValue("@Labour", Labour);
                cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
                cmd.Parameters.AddWithValue("@Order_ID", Order_ID);
                cmd.Parameters.AddWithValue("@ItemImage", ItemImage);
                cmd.Parameters.AddWithValue("@IssueQty", Issue_Qty);
                
                


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

        public DataTable getAllOrderDetails()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetAllOrderDetails";
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();

            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();
            return dt;


        }
        public int SearchItemIDThroughAbv(string Abv)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SearchItemIDThroughAbv";
            cmd.Parameters.AddWithValue("@Abrivation", Abv);
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();

            return Convert.ToInt32(dt.Rows[0][0]);


        }
        public DataTable GetStockbyItemIDandTagNo(int id, int tagNo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetStockbyItemIDandTagNo";
            cmd.Parameters.AddWithValue("@Item_ID", id);
            cmd.Parameters.AddWithValue("@TagNo", tagNo);

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
