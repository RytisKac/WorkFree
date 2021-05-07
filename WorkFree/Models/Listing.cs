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

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Score { get; set; }

        [Required]
        [ForeignKey("PricingType")]
        public int PricingTypeId { get; set; }
        public virtual PricingType PricingType { get; set; }

        [Required]
        [ForeignKey("ListingCategory")]
        public int ListingCategoryId { get; set; }
        public virtual ListingCategory ListingCategory { get; set; }

        [Required]
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

        [Required]
        [ForeignKey("aspnetusers")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
