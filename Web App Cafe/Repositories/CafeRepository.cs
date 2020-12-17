using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebApp.Repositories
{
    public class CafeRepository
    {
        string connStr = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
        DataSet callDbWithValue(string cmdText) {
            SqlConnection conn = new SqlConnection(connStr);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(ds);
            return ds;
        }
        void callDb(string cmdText) {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }
        public DataSet getCafeList()
        {
            string cmdText = "SELECT * FROM [Cafe]";
            return callDbWithValue(cmdText);
        }

        public void insertMenu(MenuModel data)
        {
            string cmdTextRaw = "INSERT INTO [Cafe] VALUES ('{0}','{1}',{2})";
            string cmdText = string.Format(cmdTextRaw, data.title, data.size, data.price);
            callDb(cmdText);
        }
        public void deleteMenu(int id) {
            string cmdText = "DELETE From [Cafe] WHERE id = "+id;
            callDb(cmdText);
        }
        public DataSet getMenuById(int id) {
            string cmdText = "SELECT * FROM [Cafe] WHERE id = " + id;
            return callDbWithValue(cmdText);
        }
        public void updateMenu(MenuModel data) {
            string cmdTextRaw = "UPDATE [Cafe] SET " +
                "Menu = '{0}', " +
                "Size = '{1}', " +
                "Price = {2} " +
                "WHERE id = {3}";
            string cmdText = string.Format(cmdTextRaw, data.title, data.size, data.price, data.id);
            callDb(cmdText);
        }

    }
    public class MenuModel {
        public int id { get; set; }
        public string title { get; set; }
        public string size { get; set; }
        public int price { get; set; }

    }
}