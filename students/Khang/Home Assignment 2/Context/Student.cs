using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Assignment_2.Context
{

    public enum Gender{
        Male,Female,Unknown
    }

    class Student
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string FristName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public Gender Gender { get; set; }

        public DateTime Birthday { get; set; }

        public string UserName { get; set; }

        [ForeignKey("UserName")]
        public Account Account { get; set; }
    }
}
