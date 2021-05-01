using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WorkFree.Areas.Identity.Data;

namespace WorkFree.Models
{
    public class Listing
    { 
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Score { get; set; }

        [ForeignKey("PricingType")]
        public int PricingTypeId { get; set; }
        public PricingType PricingType { get; set; }

        [ForeignKey("ListingCategory")]
        public int ListingCategoryId { get; set; }
        public ListingCategory ListingCategory { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }
        public City City { get; set; }

        [ForeignKey("aspnetusers")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
