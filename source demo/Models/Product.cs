using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product: IDisposable
    {
        public int Id { get; set; }

        [StringLength(15)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public double Price { get; set; }

        public void Dispose()
        {
            Console.WriteLine("Tao đã chết");
        }
    }
}
