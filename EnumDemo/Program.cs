using System;

namespace EnumDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //若key=1，则str="Renewal";
            string str = Enum.GetName(typeof(ProjectType), 1);
            Console.WriteLine($"获取枚举名称：1={str}");

            //取string值：
            string str1 = ProjectType.Renewal.ToString();
            Console.WriteLine($"获取枚举值：Renewal={str1}");

            //获取枚举key值：
            int key = (int)ProjectType.Implementation;
            Console.WriteLine($"获取枚举值：Implementation={key}");

            //判断key值是否存在于枚举中：
            bool b = Enum.IsDefined(typeof(ProjectType), 0);
            Console.WriteLine($"判断0值是否存在于枚举中：{b}");
            //判断key值是否存在于枚举中：
            bool b1 = Enum.IsDefined(typeof(ProjectType), 1);
            Console.WriteLine($"判断1值是否存在于枚举中：{b1}");

            Console.ReadKey();
        }
    }
}
