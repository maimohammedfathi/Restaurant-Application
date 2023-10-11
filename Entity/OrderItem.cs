using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOfProject.Entity
{
    public class OrderItem
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get; set; }
        [ForeignKey("order")]
        public int OrderId { get; set; }
        public virtual Order order { get; set; }

    }
}
