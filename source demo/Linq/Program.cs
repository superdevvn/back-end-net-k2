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
            Question7();
        }

        static void InitData(List<IPerson> persons)
        {
            persons.Add(new Student
            {
                FirstName = "Nghia",
                LastName = "Tran",
                Salary = 5000,
                DepartmentCode = "Admin"
            });

            persons.Add(new Student
            {
                FirstName = "Stark",
                LastName = "Tony",
                Salary = 2000,
                DepartmentCode = "Admin"
            });

            persons.Add(new Student
            {
                FirstName = "Panther",
                LastName = "Black",
                Salary = 3000,
                DepartmentCode = "Admin"
            });

            persons.Add(new Student
            {
                FirstName = "Widow",
                LastName = "Black",
                Salary = 6000,
                DepartmentCode = "Customer"
            });

            persons.Add(new Student
            {
                FirstName = "Parker",
                LastName = "Peter",
                Salary = 500,
                DepartmentCode = "Customer"
            });

            persons.Add(new Student
            {
                FirstName = "Snow",
                LastName = "Jon",
                Salary = 500,
                DepartmentCode = "Customer"
            });

            persons.Add(new Student
            {
                FirstName = "Arya",
                LastName = "Stark",
                Salary = 500,
                DepartmentCode = "Customer"
            });

            var temp = new List<IPerson>();
            temp.Add(new Student
            {
                FirstName = "Logan",
                LastName = "Wolverine",
                Salary = 2300,
                DepartmentCode = "Customer"
            });

            temp.Add(new Student
            {
                FirstName = "Banner",
                LastName = "Bruce",
                Salary = 10000,
                DepartmentCode = "Customer"
            });

            persons.AddRange(temp);
        }

        static void InitDepartment(List<IDepartment> departments)
        {
            departments.Add(new Department
            {
                DepartmentCode = "Admin",
                DepartmentName = "Administrator"
            });

            departments.Add(new Department
            {
                DepartmentCode = "Customer",
                DepartmentName = "Khách hàng"
            });
        }

        static void Question1()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                InitData(persons);
                var student = persons.Find(e => e.FirstName == "Banntetrer");
                Console.WriteLine(student.LastName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Question2()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                InitData(persons);
                //var student = persons.First(e => e.FirstName == "Bantẻtner");
                var student = persons.FirstOrDefault(e => e.FirstName == "Bantẻtner");
                if (student != null) Console.WriteLine(student.LastName);
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
                //var student = persons.Single(e => e.FirstName == "Bantẻtner");
                var student = persons.SingleOrDefault(e => e.FirstName == "Banner");
                if (student != null) Console.WriteLine(student.LastName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Question4()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                InitData(persons);
                var result = persons.OrderBy(e=> e.Salary).ThenBy(e=>e.FirstName);
                foreach (var person in result)
                {
                    Console.WriteLine("FirstName: " + person.FirstName);
                    Console.WriteLine("LastName: " + person.LastName);
                    Console.WriteLine("Salary: " + person.Salary);
                    Console.WriteLine("***************************");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Question5()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                InitData(persons);
                var result = persons.Select(e=>e.FirstName).Aggregate((a, b) => { return a.ToLower() + ", " + b.ToLower(); });
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Question6()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                InitData(persons);
                var result = persons.GroupBy(e => e.Salary).Select(e => new
                {
                    Salary = e.Key,
                    Count = e.Count(),
                    Children = e.ToList()
                });
                foreach (var data in result)
                {
                    Console.WriteLine("Salary: " + data.Salary);
                    Console.WriteLine("Count: " + data.Count);
                    foreach (var child in data.Children)
                    {
                        Console.WriteLine("------------------------------");
                        Console.WriteLine("FirstName: " + child.FirstName);
                        Console.WriteLine("LastName: " + child.LastName);
                    }
                    Console.WriteLine("***************************");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Question7()
        {
            try
            {
                List<IPerson> persons = new List<IPerson>();
                List<IDepartment> departments = new List<IDepartment>();
                InitData(persons);
                InitDepartment(departments);
                //var result = persons.Join(departments,
                //    person => person.DepartmentCode,
                //    department => department.DepartmentCode,
                //    (person, department) => new
                //    {
                //        FirstName = person.FirstName,
                //        LastName = person.LastName,
                //        DepartmentName = department.DepartmentName
                //    });

                //foreach (var data in result)
                //{
                //    Console.WriteLine("FirstName: " + data.FirstName);
                //    Console.WriteLine("LastName: " + data.LastName);
                //    Console.WriteLine("DepartmentName: " + data.DepartmentName);
                //    Console.WriteLine("***************************");
                //}

                var result = persons.Select((value, index) =>
                {
                    Console.WriteLine(index);
                    return value.FirstName;
                });

                foreach(var firstName in result)
                {
                    Console.WriteLine(firstName);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
