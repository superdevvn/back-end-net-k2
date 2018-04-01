using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public interface IDepartment
    {
        string DepartmentCode { get; set; }
        string DepartmentName { get; set; }
    }

    public class Department: IDepartment
    {
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}
