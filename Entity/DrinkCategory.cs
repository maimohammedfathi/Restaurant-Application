﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionOfProject.Entity
{
    public class DrinkCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        //public virtual ICollection<Food> Foods { get; set; }

    }
}
