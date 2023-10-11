using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOfProject.VeiwModel
{
    public class FoodVeiwModel
    {
        public int Id { get; set; }       // key identtity 1 ,1
        public string Name { get; set; } // not null , len = 50  
        public int UniteOnStock { get; set; } // not null  range >= uintinstock :    // current ammount 5 4 ==>  3 ==> 7 
        public int TotalAmount { get; set; }   // not null range >= 0 5 ==>4 ==> 9
        public decimal Cost { get; set; }  // not null range > 0 && cost  < price
        public decimal Price { get; set; } // not null price > = cost 
        public int CategoryID { get; set; }
    }
}
