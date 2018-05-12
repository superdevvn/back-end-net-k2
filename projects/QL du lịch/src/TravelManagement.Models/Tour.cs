using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelManagement.Models
{
    public class Tour
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public decimal AdultPrice { get; set; }

        public decimal ChildPrice { get; set; }

        public string Description { get; set; }

        public string Policy { get; set; }

        public virtual List<TourDetail> TourDetails { get; set; }
    }
}
