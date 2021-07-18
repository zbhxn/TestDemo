using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleActiveResultSets
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder
            {
                DataSource = ".",
                InitialCatalog = "Test",
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };

            using (SqlConnection con = new SqlConnection(sb.ConnectionString))
            {
                con.Open();

                string sql = "select count(0) from [user];select * from [user];";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        using (DataSet dataSet = new DataSet())
                        {
                            adapter.Fill(dataSet, "Anonymous");
                        }
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
