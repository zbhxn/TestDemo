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
        private string connStr =
            "Data Source=waadqpivah.database.chinacloudapi.cn;Initial Catalog=zbhxn_DataBase;Persist Security Info=True;User ID=zbhxn;Password=3edc#EDC";
        // GET: Home
        public ActionResult Index()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn=new SqlConnection(connStr))
            {
                conn.Open();
                string sqlcmd = "SELECT * FROM dbo.userInfo";
                using (SqlCommand cmd = new SqlCommand(sqlcmd,conn))
                {
                    using (SqlDataAdapter adpter=new SqlDataAdapter(cmd))
                    {
                        adpter.Fill(ds);
                    }
                }
            }
            ViewData["DataMsg"] = ds.Tables[0].Rows[0]["UserName"];
            ViewBag.BagMsg = ds.Tables[0].Rows[0]["PassWord"];
            return View();
        }
    }
}