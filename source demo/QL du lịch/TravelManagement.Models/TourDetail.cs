using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TravelManagement.Models
{
    public class TourDetail
    {
        public Guid Id { get; set; }

        public Guid TourId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }
    }
}
