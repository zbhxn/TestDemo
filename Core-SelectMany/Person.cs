using System.Collections.Generic;

namespace Core_SelectMany
{
    public class Person
    {
        public string Name { set; get; }
        public int Age { set; get; }
        public string Gender { set; get; }
        public Dog[] Dogs { set; get; }

        public static List<Person> Persons
        {
            get
            {
                return new List<Person>
                {
                    new Person
                    {
                        Name = "P1", Age = 18, Gender = "Male",
                        Dogs = new Dog[]
                        {
                            new Dog { Name = "D1" },
                            new Dog { Name = "D2" }
                        }
                    },
                    new Person
                    {
                        Name = "P2", Age = 19, Gender = "Male",
                        Dogs = new Dog[]
                        {
                            new Dog { Name = "D3" }
                        }
                    },
                    new Person
                    {
                        Name = "P3", Age = 17,Gender = "Female",
                        Dogs = new Dog[]
                        {
                            new Dog { Name = "D4" },
                            new Dog { Name = "D5" },
                            new Dog { Name = "D6" }
                        }
                    }
                };
            }
        }
    }

    public class Dog
    {
        public string Name { set; get; }
    }
}
