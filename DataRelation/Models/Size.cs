﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataRelation.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}