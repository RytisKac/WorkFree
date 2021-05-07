using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WorkFree.Models;

namespace WorkFree.ViewModels
{
    public class CreateListingViewModel
    {
        [Required(ErrorMessage = "Skelbimo pavadinimas privalomas")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Skelbimo aprašymas privalomas")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Skelbimo kaina privaloma")]
        public double Price { get; set; }

        [Required]
        public int PricingType { get; set; }

        [Required]
        public int ListingCategory { get; set; }

        [Required]
        public int City { get; set; }
        public List<PricingType> pricingTypes { get; set; }
        public List<City> cities { get; set; }
        public List<ListingCategory> listingCategories { get; set; }
    }
}
