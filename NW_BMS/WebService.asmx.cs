using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using MySql.Data.MySqlClient;
namespace NW_BMS
{
    /// <summary>
    /// WebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int test_Add(int a,int b)
        {

            return a+b;
        }
        [WebMethod]
        public string testSqlServer()
        {
            string connetStr = "server=127.0.0.1;user=sa;password=root; database=Northwind;";
            SqlConnection conn = new SqlConnection(connetStr);
            try
            {
                conn.Open();

                string Sql = "select *from Categories";

                SqlCommand cmd = new SqlCommand(Sql, conn);

                SqlDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    return result.GetInt32(0).ToString() + " " + result.GetString(1) + " " + result.GetString(2);

                }

                return "没有结果";
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

        }




        [WebMethod]
        public string testSqlServer_1()
        {
            string connString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();

                string Sql = "select *from Categories";

                SqlCommand cmd = new SqlCommand(Sql, conn);

                SqlDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    return result.GetInt32(0).ToString() + " "+result.GetString(1) + " "+result.GetString(2);

                }

                return "没有结果";
            }
            catch (SqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

        }

        [WebMethod]
        public string testMySql()
        {
            //string connetStr = "server=127.0.0.1;port=3306;user=root;password=root; database=employees;";
            string connString = ConfigurationManager.ConnectionStrings["connStringMySQL"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connString);
            try
            {
                conn.Open();

                string Sql = "select *from usertb";

                MySqlCommand cmd = new MySqlCommand(Sql, conn);

                MySqlDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    return result.GetInt32(0).ToString() + " " + result.GetString(1) + " " + result.GetString(2);
                }

                return "没有结果";
            }
            catch (MySqlException ex)
            {
                return ex.Message.ToString();
            }
            finally
            {
                conn.Close();
            }

        }



        }
}
