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
    class ManageCategory
    {
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ShahiDB"].ConnectionString);
        public int insertCategory()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_Insert_tblCategory";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
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
        public int UpdateCategory()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateCategory";
                cmd.Connection = con;
                con.Open();
                cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public int deleteCategory()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeleteCategory";
                cmd.Connection = con;
                con.Open();

                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
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
        public DataTable getAllCategory()
        {
            SqlDataAdapter da = new SqlDataAdapter();

            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SelectAllfrmCatrgory";
            cmd.Connection = con;

            DataTable dt = new DataTable();

            da.SelectCommand = cmd;
            da.Fill(dt);

            return dt;

        }

  /*   public DataTable getAllCategorywithSeggesion(string catName)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "usp_SelectAllfrmCatrgorywithSugession";
            cmd.Parameters.AddWithValue("@CategoryName", catName);
            cmd.Connection = con;

            DataTable dt = new DataTable();
            da.SelectCommand = cmd;
            da.Fill(dt);
            return dt;
        }*/
    }
}
