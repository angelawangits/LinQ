using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var fruitDictionary = new Dictionary<int, String>()
            {
                { 1, "apple" },
                { 2, "banana" },
                { 3, "grape" },
                { 4, "peach" },
                { 5, "mango" }
            };
            var nameList = new List<String>() { "Angela", "Sam", "Opass", "Ryan", "Norman" };
            var numArray = new int[5] { 2, 4, 6, 8, 3 };


            // Query 1 : display all the items in an array:
            var query1 = from num in numArray select num;
            Console.WriteLine("Query1 : ");
            foreach (var i in query1)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();


            //Query 2 : random the number in array
            var query2 = numArray.OrderBy(x => Guid.NewGuid());
            Console.WriteLine("Query2 : ");
            foreach (var i in query2)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();


            //Query 3_1 : use SQL to select with a condition in dictionary
            var query3_1 = from friut in fruitDictionary where friut.Key > 2 select friut;
            Console.WriteLine("Query3_1 : ");
            foreach (var i in query3_1)
            {
                Console.Write(i.Value + " ");
            }

            Console.WriteLine();


            //Query 3_2 : use lambda to select with a condition in dictionary
            var query3_2 = fruitDictionary.Where(fruit => fruit.Key > 2);
            Console.WriteLine("Query3_2 : ");
            foreach (var i in query3_2)
            {
                Console.Write(i.Value + " ");
            }

            Console.WriteLine();


            //Query 4_1 : use SQL to sort in list
            var query4_1 = from name in nameList orderby name select name;
            Console.WriteLine("Query4_1 : ");
            foreach (var i in query4_1)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();


            //Query 4_2 : use lambda to sort in list
            var query4_2 = nameList.OrderBy(name => name);
            Console.WriteLine("Query4_2 : ");
            foreach (var i in query4_2)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();


            var personList = new List<Person>()
            {
                { new Person(){name = "Sam", age = 20}},
                { new Person(){name = "JJyeh", age = 28}},
                { new Person(){name = "Win", age = 48}},
                { new Person(){name = "Neal", age = 14}},
                { new Person(){name = "angela", age = 24}}
            };

            var courseList = new List<Course>()
            {
                { new Course(){personName = "JJyeh", name = "agile", score = 85}},
                { new Course(){personName = "angela", name = "sports", score = 30}},
                { new Course(){personName = "Sam", name = "Sports", score = 90}},
                { new Course(){personName = "JJyeh", name = "sports", score = 50}},
                { new Course(){personName = "Win", name = "math", score = 40}},
            };

            //Query 5 : join two list
            var query5 = personList.Join(courseList, p => p.name, c => c.personName, (p, c) => new { p.name, p.age, CourseName = c.name, c.score })
                .Where(x => x.score >= 60);
            Console.WriteLine("Query 5 : ");
            foreach (var i in query5)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine();

            Console.ReadKey();

        }

    }

    class Person
    {
        public string name;
        public int age;

        public override string ToString()
        {
            return "name : " + name + ", age : " + age;
        }
    }

    class Course
    {
        public string personName;
        public string name;
        public int score;

        public override string ToString()
        {
            return "name : " + name + ", score : " + score + ", person name : " + personName;
        }
    }
}
