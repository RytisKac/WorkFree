﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkFree.Areas.Identity.Data;
using WorkFree.Data;
using WorkFree.Models;
using WorkFree.ViewModels;

namespace WorkFree.Controllers
{
    public class ListingsController : Controller
    {
        private readonly WorkFreeContext _context;
        private readonly UserManager<User> _userManager;

        public ListingsController(WorkFreeContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchString, string currentFilter, int? pageNumber)
        {
            if(searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var listings = from l in _context.Listings select l;
            if (!String.IsNullOrEmpty(searchString))
            {
                listings = listings.Where(s => s.Name.Contains(searchString));
            }

            int pageSize = 10;
            return View(await PaginatedList<Listing>.CreateAsync(listings.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [Authorize]
        public IActionResult Create()
        {
            CreateListingViewModel model = new CreateListingViewModel();
            model.listingCategories = _context.ListingCategory.ToList();
            model.cities = _context.Cities.ToList();
            model.pricingTypes = _context.PricingTypes.ToList();


            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateListingViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                var newListing = new Listing
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    PricingTypeId = model.PricingType,
                    ListingCategoryId = model.ListingCategory,
                    CityId = model.City,
                    UserId = userId
                };
                _context.Add(newListing);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            model.listingCategories = _context.ListingCategory.ToList();
            model.cities = _context.Cities.ToList();
            model.pricingTypes = _context.PricingTypes.ToList();
            return View("Create", model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var listing = await _context.Listings.AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if(listing == null)
            {
                return NotFound();
            }

            return View(listing);
        }
    }
}
