﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkFree.Models
{
    public class ListingCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}
