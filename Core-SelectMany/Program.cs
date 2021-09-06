using System;
using System.Collections.Generic;
using System.Linq;

namespace Core_SelectMany
{
    class Program
    {
        static void Main(string[] args)
        {
            //Select和SelectMany区别
            string[] text = { "Today is 2018-06-06", "weather is sunny", "I am happy" };
            var tokens = text.Select(s => s.Split(' '));
            var tokens2 = text.SelectMany(s => s.Split(' '));

            //LINQ之SelectMany用法
            //https://www.cnblogs.com/cncc/p/9840463.html

            //一、第一种用法：
            //public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector);
            var dogs = Person.Persons.SelectMany(p => p.Dogs);
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog.Name);
            }

            dogs = from p in Person.Persons
                   from d in p.Dogs
                   select d;
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog.Name);
            }

            //2、第二种用法：
            //public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector);
            dogs = Person.Persons.SelectMany((p, i) => p.Dogs.Select(d =>
                                             {
                                                 d.Name = $"{i},{d.Name}";
                                                 return d;
                                             }));
            foreach (var dog in dogs)
            {
                Console.WriteLine(dog.Name);
            }

            //三、第三种用法：
            //public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
            var results = Person.Persons.SelectMany(p => p.Dogs, (p, d) => new { PersonName = p.Name, DogName = d.Name });
            foreach (var result in results)
            {
                Console.WriteLine($"{result.PersonName},{result.DogName}");
            }

            results = from p in Person.Persons
                      from d in p.Dogs
                      select new { PersonName = p.Name, DogName = d.Name };
            foreach (var result in results)
            {
                Console.WriteLine($"{result.PersonName},{result.DogName}");
            }

            //四、第四种用法：
            //public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector);
            results = Person.Persons.SelectMany((p, i) =>
            {
                for (int j = 0; j < p.Dogs.Length; j++)
                {
                    p.Dogs[j].Name = $"{i}-{p.Dogs[j].Name}";
                }
                return p.Dogs;
            }, (p, d) => new { PersonName = p.Name, DogName = d.Name });
            foreach (var result in results)
            {
                Console.WriteLine($"{result.PersonName},{result.DogName}");
            }

            Console.ReadKey();
        }
    }
}
