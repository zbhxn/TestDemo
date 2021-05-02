using System;
using System.Globalization;
using System.Threading;

namespace StringComparisonDemo
{
    class Program
    {
        /**
         * https://docs.microsoft.com/zh-CN/dotnet/api/system.stringcomparison?view=net-5.0
            CurrentCulture	            0	使用区分区域性的排序规则和当前区域性比较字符串。
            CurrentCultureIgnoreCase	1	通过使用区分区域性的排序规则、当前区域性，并忽略所比较的字符串的大小写，来比较字符串。
            InvariantCulture	        2	使用区分区域性的排序规则和固定区域性比较字符串。
            InvariantCultureIgnoreCase	3	通过使用区分区域性的排序规则、固定区域性，并忽略所比较的字符串的大小写，来比较字符串。
            Ordinal	                    4	使用序号（二进制）排序规则比较字符串。
            OrdinalIgnoreCase	        5	通过使用序号（二进制）区分区域性的排序规则并忽略所比较的字符串的大小写，来比较字符串。
         */
        static void Main(string[] args)
        {
            string[] cultureNames = { "en-US", "se-SE" };
            string[] strings1 = { "case", "encyclopædia", "encyclopædia", "Archæology" };
            string[] strings2 = { "Case", "encyclopaedia", "encyclopedia", "ARCHÆOLOGY" };
            StringComparison[] comparisons = (StringComparison[])Enum.GetValues(typeof(StringComparison));
            //不要运行，字符不对，运行结果不准确，查看文档
            foreach (var cultureName in cultureNames)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
                Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);

                for (int ctr = 0; ctr <= strings1.GetUpperBound(0); ctr++)
                {
                    foreach (var comparison in comparisons)
                        Console.WriteLine("   {0} = {1} ({2}): {3}", strings1[ctr], strings2[ctr], comparison, string.Equals(strings1[ctr], strings2[ctr], comparison));
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
