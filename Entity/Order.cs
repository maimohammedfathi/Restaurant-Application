using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOfProject.Entity
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public decimal TotalCost { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
