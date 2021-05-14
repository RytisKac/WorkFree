using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkFree.Areas.Identity.Data;
using WorkFree.Data;
using WorkFree.Models;

namespace WorkFree.Controllers
{
    public class ChatController : Controller
    {
        private readonly WorkFreeContext _context;
        private readonly UserManager<User> _userManager;
        public ChatController(WorkFreeContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var chats = _context.Chats
                .Where(u => u.Users.Any(c => c.UserId == userId))
                .ToList();
            return View(chats);
        }


    }
}
