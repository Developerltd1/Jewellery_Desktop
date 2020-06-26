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
    class ManageItems
    {
         public string ItemName { get; set; }
        public int ItemID { get; set; }
        public int Category_ID { get; set; }
        public string Abrivation { get; set; }


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShahiDB"].ConnectionString);



        public int insertItem()
        {

            try
            {
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Insert_tblItems";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                cmd.Parameters.AddWithValue("@Abrivation", Abrivation);

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



        public int UpdateItem()
        {


            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateItems";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@ItemName", ItemName);
                cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                cmd.Parameters.AddWithValue("@Abrivation", Abrivation);
                cmd.Parameters.AddWithValue("@ItemID", ItemID);


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


        public int deleteItem()
        {


            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeleteItem";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@ItemID", ItemID);
              


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


        public DataTable getItemOfCategory(int categoryID)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_GetItemOfCategory";
            cmd.Parameters.AddWithValue("@CategoryID" , categoryID);
            cmd.Connection = con;

            DataTable dt = new DataTable();

            da.SelectCommand = cmd;
            da.Fill(dt);

            con.Close();
            return dt;

            
        }


        public DataTable getAllItems()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SelectFromItem";
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

