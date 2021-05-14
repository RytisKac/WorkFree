using Microsoft.AspNetCore.Authorization;
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

        [HttpGet]
        public IActionResult Conversation(int? id)
        {
            var chat = _context.Chats.Include(m => m.Messages).FirstOrDefault(c => c.Id == id);

            return View(chat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChat(string userId)
        {
            var rootid = User
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var chat = new Chat
            {
                Name = "new chat"
            };

            chat.Users.Add(new ChatUser
            {
                UserId = rootid
            });

            chat.Users.Add(new ChatUser
            {
                UserId = userId
            });

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int chatId, string content)
        {
            User user = await _userManager.GetUserAsync(User);
            var message = new Message
            {
                SenderName = user.UserName,
                Content = content,
                TimeSent = DateTime.Now,
                ChatId = chatId
            };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            return RedirectToAction("Conversation", new { id = chatId});
        }
    }
}
