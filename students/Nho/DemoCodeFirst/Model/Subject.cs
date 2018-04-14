using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }
        public int Credit { get; set; }
        public float fee { get; set; }
    }
}
