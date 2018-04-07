using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Person
    {
        private string _name;
        private int _age;
        private string _sex;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public override string ToString()
        {
            return "Name: " + Name + ", Age: " + Age + ", Sex: " + Sex;
        }
    }
}
