using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

    }
}
