using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SoTinChi { get; set; }

        public double HocPhi { get; set; }

        public string Code { get; set; }
    }
}
