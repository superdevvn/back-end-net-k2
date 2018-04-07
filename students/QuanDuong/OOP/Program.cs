using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Question2();
            //Student student = new Student();
            //student.FirstName = "Peter";
            //student.LastName = "Dark";

            //Teacher teacher = new Teacher();
            //teacher.FirstName = "Nghia";
            //teacher.LastName = "Tran";

            //Hello(student);
            //Hello(teacher);

            //List<ISalary> salaries = new List<ISalary>();
            //salaries.Add(student);
            //salaries.Add(teacher);
            //foreach(var salary in salaries)
            //{
            //    Console.WriteLine(salary.Calculate());
            //}

            //List<Staff> staffs = new List<Staff>();
            //staffs.Add(new Employee
            //{
            //    FirstName = "Nghia",
            //    LastName = "Tran"
            //});
            //staffs.Add(new Manager
            //{
            //    FirstName = "Nghia",
            //    LastName = "Tran"
            //});
            //foreach(var staff in staffs)
            //{
            //    Console.WriteLine(staff.Calculate());
            //    Console.WriteLine(staff.Hello());
            //    Console.WriteLine("*****************");
            //}

            //int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var b = a.Where(value => value > 5);
            //foreach (var value in b)
            //    Console.Write(value + " ");
            //Console.WriteLine();
            //var c = a.FirstOrDefault(value => value > 7);
            //Console.WriteLine(c);

            //int[] a = { 2, 4, 6, 8, 10, 7 };
            //Console.WriteLine(a.All(value => value % 2 == 0));
            //Console.WriteLine(a.Any(value => value % 2 == 1));

            List<IPerson> persons = new List<IPerson>();
            persons.Add(new Student
            {
                FirstName = "Stark",
                LastName = "Tony"
            });

            persons.Add(new Teacher
            {
                FirstName = "Parker",
                LastName = "Peter"
            });

            persons.Add(new Worker
            {
                FirstName = "Banner",
                LastName = "Bruce"
            });

            persons.Add(new Student
            {
                FirstName = "Lord",
                LastName = "Star"
            });

            var result = persons.Where(e => e.FirstName.Contains("k"));
            foreach (var person in result)
                Console.WriteLine(person.FirstName + " " + person.LastName);
        }
        //list vs array khác nhau ở chỗ list có thể push các phần tử vào, khi nào dùng list, list khi có sự thay đổi về phần tử
        //khi nào dùng array, khi không có sự thay đổi về phần tử
        static void InitData(List<IPerson> persons)
        {
            persons.Add(new Student{
                FirstName = "Quan",
                LastName = "Duong",
                Salary = 200
            });
            persons.Add(new Student
            {
                FirstName = "XYZ",
                LastName = "Yo",
                Salary = 600
            });
            var temp = new List<IPerson>();
            temp.Add(new Student
            {
                FirstName = "Quan",
                LastName = "Duong"
                
            });
        }
        static void Question()
        {
            List<IPerson> persons = new List<IPerson>();
            InitData(persons);
            var student = persons[persons.Count - 1];
            persons.Find(e => e.FirstName == "Quan");
            Console.WriteLine(student.LastName);
        }
        static void Question2()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                InitData(persons);
                var result = persons.OrderBy(e => e.Salary ). ThenBy(e=> e.FirstName) ;
                foreach (var person in result)
                {
                    Console.WriteLine("FirstName: " + person.FirstName);
                    Console.WriteLine("LastName: " + person.LastName);
                    Console.WriteLine("Salary: " + person.Salary);
                    Console.WriteLine("--------------------");
                }
                
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
        static void Question3()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                InitData(persons);
                var result = persons.GroupBy(e => e.Salary).Select(e => new
                {
                    Salary = e.Key,
                    Count = e.Count()
                });

                foreach (var data in result)
                {
                    Console.WriteLine("Salary: " + data.Salary);
                    Console.WriteLine("Count: " + data.Count);

                }
                Console.WriteLine("--------------------");


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
            static void Hello(IPerson person)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName);
        }
    }
}
