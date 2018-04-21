using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum TypeGender
    {
        Male,
        Female,
    }

    public class Student
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Grade { get; set; }

        public TypeGender Gender { get; set; }

        public DateTime Birthday { get; set; }

    }
}
