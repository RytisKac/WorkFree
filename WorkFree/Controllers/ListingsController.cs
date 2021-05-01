using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFree.Data;
using WorkFree.Models;

namespace WorkFree.Controllers
{
    public class ListingsController : Controller
    {
        private readonly WorkFreeContext _context;

        public ListingsController(WorkFreeContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            Listing model = new Listing();


            return View(model);
        }
    }
}
