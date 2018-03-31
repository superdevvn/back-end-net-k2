using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public interface IPerson
    {
        string FirstName {get;set;}
        string LastName { get; set; }
    }

    public interface ISalary
    {
        float Calculate();
    }

    public class Teacher: IPerson, ISalary
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public float Calculate()
        {
            return 10;
        }
    }

    public class Student : IPerson, ISalary
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public float Calculate()
        {
            return 5;
        }
    }

    public class Worker : IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
