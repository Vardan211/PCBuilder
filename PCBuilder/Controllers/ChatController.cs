using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Domain;

namespace PCBuilder.Controllers
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("send-message")]
        [Authorize(Roles = "user, admin")]
        public async Task<IActionResult> SendMessage(string text, int chatId)
        {
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            await _chatService.SendMessage(text, username, chatId);
            return Ok();
        }

        [HttpGet("{chatId}")]
        [Authorize(Roles = "user, admin")]
        public IActionResult GetMessagesByChat(int chatId)
        {
            var result = _chatService.GetMessagesByChat(chatId);
            return Ok(result);
        }

        [HttpPost("create-chat")]
        [Authorize(Roles = "user, admin")]
        public async Task<IActionResult> CreateChat(string name)
        {
            await _chatService.CreateChat(name);
            return Ok();
        }

        [HttpPost("add-user-to-chat")]
        [Authorize(Roles = "user, admin")]
        public async Task<IActionResult> AddUserToChat(int chatId)
        {
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            await _chatService.AddUserToChat(chatId, username);
        
            return Ok();
        }

        [HttpGet("get-users-from-chat")]
        [Authorize(Roles = "admin")]
        public IActionResult GetUsersFromChat(int chatId)
        {
            var result = _chatService.GetUsersFromChat(chatId);
            return Ok(result);
        }

        [HttpGet("get-chats-by-user")]
        [Authorize(Roles = "admin")]
        public IActionResult GetChatsFromUser()
        {
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var result = _chatService.GetChatsFromUser(username);
        
            return Ok(result);
        }
    }
}
