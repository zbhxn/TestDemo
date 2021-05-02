using ASP.NETCoreWebApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreWebApiDemo
{
    public class Data
    {
        public static List<Student> ListStudent { get; set; }

        public static List<Student> GetList()
        {
            ListStudent = new List<Student>();
            for (int i = 0; i < 3; i++)
            {
                Student student = new Student()
                {
                    ID = i,
                    Name = $"测试_{i}",
                    Age = 20,
                    Gender = "男"
                };
                ListStudent.Add(student);
            }

            return ListStudent;
        }
    }
}
