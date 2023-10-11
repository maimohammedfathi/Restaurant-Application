using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOfProject.Entity
{
    public class AdminHome
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateS { get; set; }

        public decimal? water_bill  { get; set; }
        public decimal? Electricity_Bill { get; set; }
        public decimal? Gas_Bill { get; set; }
        public decimal? Rent { get; set; }
        public decimal TotalCost { get; set; }
        public decimal CurrentProfite { get; set; }
        public string percentage { get; set; }

        
    }
}
