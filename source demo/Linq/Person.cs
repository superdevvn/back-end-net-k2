namespace OOP
{
    public interface IPerson
    {
        string FirstName {get;set;}
        string LastName { get; set; }
        string DepartmentCode { get; set; }

        decimal Salary { get; set; }
    }

    public class Teacher: IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DepartmentCode { get; set; }

        public decimal Salary { get; set; }
    }

    public class Student : IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DepartmentCode { get; set; }

        public decimal Salary { get; set; }
    }

    public class Worker : IPerson
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DepartmentCode { get; set; }

        public decimal Salary { get; set; }
    }
}
