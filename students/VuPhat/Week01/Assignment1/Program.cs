using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();
            personList.Add(new Person
            {
                Name = "Alan Walker",
                Age = 21,
                Sex = "male",
            });

            personList.Add(new Person
            {
                Name = "TheFatRat",
                Age = 25,
                Sex = "male",
            });

            personList.Add(new Person
            {
                Name = "Charlie Puth",
                Age = 23,
                Sex = "male",
            });

            personList.Add(new Person
            {
                Name = "Taylor Swift",
                Age = 24,
                Sex = "female",
            });

            personList.Add(new Person
            {
                Name = "Justin Bieber",
                Age = 24,
                Sex = "male",
            });

            personList.Add(new Person
            {
                Name = "Taylor Swift",
                Age = 30,
                Sex = "female",
            });

            Console.WriteLine("* The number of singers is on the list: " + personList.Count());

            Console.WriteLine("* The total age of all singers on the list: " + personList.Sum(p => p.Age));

            Console.WriteLine("* Singer has the highest age: " + personList.Max(p => p.Age));

            Console.WriteLine("* Singer has the smallest age: " + personList.Min(p => p.Age));

            Console.WriteLine("* Average age of the singers " + personList.Average(p => p.Age));

            Console.WriteLine("* Singer has age higher 23");

            var collection = personList.Where(p => p.Age > 23);

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            bool all = personList.All(p => p.Sex.Equals("male"));
            Console.WriteLine("* Are all singers male: " + ((all) ? "Yes" : "No"));

            bool any = personList.Any(p => p.Sex.Equals("female"));
            Console.WriteLine("* Are there any female singers: " + ((any) ? "Yes" : "No"));

            var contain = personList.Where(p => p.Name.Contains("Justin Bieber"));
            bool check = contain.Count() == 0 ? false : true;

            Console.WriteLine("* Any who has name is Justin Bieber: " + ((check) ? "Yes" : "No"));


            Console.WriteLine("* Delete duplicate the singer is 22 years old");
            personList.Select(p => p).Distinct().ToList().ForEach(e => Console.WriteLine(e));

            try
            {
                var person = personList.First(p => p.Name.Equals("Taylor Swift"));
                if (person != null)
                {
                    Console.WriteLine("* The singer have name's Taylor first on the list " + person);
                }
            }
            catch (Exception e)
            {
                // throw exception if not found
                Console.WriteLine(e.Message);
            }


            var person_firstordefault = personList.FirstOrDefault(p => p.Name.Equals("Taylor Swift"));
            // return null if not found
            if (person_firstordefault != null)
            {
                Console.WriteLine("* The singer have name's Taylor first on the list " + person_firstordefault);
            }
            else
            {
                Console.WriteLine("Not Found !!!");
            }

            try
            {
                var person_single = personList.Single(p => p.Name.Equals("Taylor Swift"));
                if (person_single != null)
                {
                    Console.WriteLine("* The singer have name's Taylor first on the list " + person_single);
                }
            }
            catch (Exception e)
            {
                // throw exception if not found and more than one element
                Console.WriteLine(e.Message);
            }

            try
            {
                var person_singleordefault = personList.Single(p => p.Name.Equals("Taylor Swift"));
                if (person_singleordefault != null)
                {
                    Console.WriteLine("* The singer have name's Taylor first on the list " + person_singleordefault);
                }
                else
                {
                    Console.WriteLine("Not found !!!");
                }
            }

            catch (Exception e)
            {
                // throw exception more than one element
                Console.WriteLine(e.Message);
            }

            /*
             *  Use single When make sure return only one record
             *  SingleOrDefault: neu co hon hai record se nen ngoai le, return null neu khong tim thay
             *  First: tra ve record dau tien neu nhieu hon 2 record, neu khong tim thay nen ngoai le
             *  FirstOrDefault: tra ve record dau tien neu nhieu hon 2 record, neu khong tim thay return null
            */
        }
    }
}
