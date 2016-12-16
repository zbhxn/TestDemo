using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestDemo.Controllers
{
    public class HomeController : Controller
    {
        public static int times = 0;
        private string connStr = "Data Source=waadqpivah.database.chinacloudapi.cn;Initial Catalog=zbhxn_DataBase;Persist Security Info=True;User ID=zbhxn;Password=3edc#EDC";
        // GET: Home
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM dbo.userInfo";
                using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                {
                    using (SqlDataAdapter adpter = new SqlDataAdapter(cmd))
                    {
                        adpter.Fill(ds);
                    }
                }
            }

            ViewData["dt"] = ds.Tables[0];

            ViewData["DataMsg"] = ds.Tables[0].Rows[0]["UserName"];
            ViewBag.BagMsg = ds.Tables[0].Rows[0]["PassWord"];

            ViewData["times"] = times += 1;
            return View();
        }
        public ContentResult InsertData()
        {
            string result = "no|添加失败";
            try
            {
                string name = Request["name"];
                string password = Request["password"];
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    //string sqlcmd = string.Format("insert into zbhxn_DataBase.dbo.userInfo (UserName,PassWord) values (N'{0}',N'{1}')", name, password);
                    //string sqlcmd = "insert into zbhxn_DataBase.dbo.userInfo (UserName,PassWord) values ('test','1111')";
                    string sqlcmd = "insert into zbhxn_DataBase.dbo.userInfo (UserName,PassWord) values (@name,@password)";
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@name", name));
                        cmd.Parameters.Add(new SqlParameter("@password", password));
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            result = "ok|添加成功";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("no|" + ex.Message);
            }
            return Content(result);
        }
    }
}