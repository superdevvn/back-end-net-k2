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

        static void Hello(IPerson person)
        {
            Console.WriteLine(person.FirstName + " " + person.LastName);
        }
    }
}
