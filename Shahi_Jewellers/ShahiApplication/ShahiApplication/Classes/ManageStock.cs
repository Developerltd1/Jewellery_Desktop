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
    class ManageStock
    {
        public int Category_ID { get; set; }
        public int Item_ID { get; set; }
        public int TagNo { get; set; }
        public DateTime EntryDate { get; set; }
        public string Carat { get; set; }
        public int StockQty { get; set; }
        public string StockImage { get; set; }


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShahiDB"].ConnectionString);



        public int insertStock()
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertStock";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                cmd.Parameters.AddWithValue("@Item_ID", Item_ID);
                cmd.Parameters.AddWithValue("@TagNo", TagNo);
                cmd.Parameters.AddWithValue("@EntryDate", EntryDate);
                cmd.Parameters.AddWithValue("@Carat", Carat);
                cmd.Parameters.AddWithValue("@StockQty", StockQty);
                cmd.Parameters.AddWithValue("@StockImage", StockImage);
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
        public DataTable getAllStock()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SelectfrmStock";
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int getTagNoOfItem(int item_ID)
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_GetTagNo";
                cmd.Parameters.AddWithValue("@Item_ID", item_ID);
                cmd.Connection = con;

                DataTable dt = new DataTable();

                da.SelectCommand = cmd;
                da.Fill(dt);


                int res = 0;
                if(dt.Rows.Count >= 1)
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
        public string GetAbvofItem(int id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            DataTable dt = new DataTable();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetAbvofItem";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Item_ID", id);
            con.Open();
 
            da.SelectCommand = cmd;
            da.Fill(dt);
            string res = "0";
            if (dt.Rows.Count >= 1)
            {
                res = dt.Rows[0][0].ToString(); 
            }
            return res;
        }

        //SearchingFromStock 
        public bsStkPos CheckStock_with_Category_AND_Item(int catogeryId, int itemId)
        {
            bsStkPos m_obj = new bsStkPos();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_CHECKAvailableStockQtyofCategory_AND_Item";
            cmd.Parameters.AddWithValue("@Catrgory_ID", catogeryId);
            cmd.Parameters.AddWithValue("@Item_ID", itemId);
            cmd.Connection = con;
            con.Open();
            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);

            m_obj.Category = dt.Rows[0][0].ToString();
            m_obj.Item = dt.Rows[0][1].ToString();
            m_obj.Stock_Qty = dt.Rows[0][2] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0][2]);
            m_obj.Issue_Qty = dt.Rows[0][3] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0][3]);
            m_obj.Available_Qty = dt.Rows[0][4] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0][4]);
            con.Close();
            // return dt;
            return m_obj;
        }
        public List<bsStkPos> CheckItems_fromStock(int catogeryId, int itemId)
        {
            ManageItems mi = new ManageItems(); //Initlize
            DataTable dt_mi = mi.getAllItems(); //Assign to DataTable
            List<bsStkPos> model_List = new List<bsStkPos>(); //Initlize
            bsStkPos model_Obj = new bsStkPos(); //Initlize
            // foreach (DataRow row in dt_mi.Rows) //Assign to DataTable to DataRow
            //{
            model_Obj = CheckStock_with_Category_AND_Item(catogeryId, itemId);
            model_List.Add(model_Obj);
            //}
            return model_List;
        }
        //END

        //AvailableStock 
        public bsStkPos GetStockQtyofItem(int itemid)
        {
            bsStkPos m_obj = new bsStkPos();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetAvailableStockQtyofItem";
            cmd.Parameters.AddWithValue("@Item_ID", itemid);
            cmd.Connection = con;
            con.Open();

            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);

            m_obj.Category = dt.Rows[0][0].ToString();
            m_obj.Item = dt.Rows[0][1].ToString();
            m_obj.Stock_Qty = dt.Rows[0][2] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0][2]);
            m_obj.Issue_Qty = dt.Rows[0][3] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0][3]);
            m_obj.Available_Qty = dt.Rows[0][4] == DBNull.Value ? 0 : Convert.ToInt32(dt.Rows[0][4]);
            con.Close();
            return m_obj;
        }
        public List<bsStkPos> AllItems_StockStatus()
        {
            ManageItems mi = new ManageItems(); //Initlize
            DataTable dt_mi = mi.getAllItems(); //Assign to DataTable
            List<bsStkPos> model_List = new List<bsStkPos>(); //Initlize
            bsStkPos model_Obj = new bsStkPos(); //Initlize
            foreach (DataRow row in dt_mi.Rows) //Assign to DataTable to DataRow
            {
                model_Obj = GetStockQtyofItem(Convert.ToInt32(row[0]));
                model_List.Add(model_Obj);
            }
            return model_List;
        }
        //END
        public DataTable checkStock_with_TagNo(int tagNo)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_checkinvoicetbl";
            cmd.Parameters.AddWithValue("@ReciptNo", tagNo);
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
