using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Staff
    {
        public string FirstName;
        public string LastName;
        public abstract decimal Calculate();
        public virtual string Hello()
        {
            return FirstName + " " + LastName;
        }
    }

    public class Employee: Staff
    {
        public override decimal Calculate()
        {
            return 10;
        }
    }

    public class Manager : Staff
    {
        public override decimal Calculate()
        {
            return 5;
        }

        public override string Hello()
        {
            return "Hello Manager: " + FirstName + " " + LastName;
        }
    }
}
