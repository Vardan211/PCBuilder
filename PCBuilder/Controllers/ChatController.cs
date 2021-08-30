using System.Threading.Tasks;
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
        public async Task<IActionResult> SendMessage(string text, int userId, int chatId)
        {
            await _chatService.SendMessage(text, userId, chatId);
            return Ok();
        }

        [HttpGet("{chatId}")]
        public IActionResult GetMessagesByChat(int chatId)
        {
            var result = _chatService.GetMessagesByChat(chatId);
            return Ok(result);
        }

        [HttpPost("create-chat")]
        public async Task<IActionResult> CreateChat(string name)
        {
            await _chatService.CreateChat(name);
            return Ok();
        }

        [HttpPost("add-user-to-chat")]
        public async Task<IActionResult> AddUserToChat(int chatId, int userId)
        {
            await _chatService.AddUserToChat(chatId, userId);
            return Ok();
        }

        [HttpGet("get-users-from-chat")]
        public IActionResult GetUsersFromChat(int chatId)
        {
            var result = _chatService.GetUsersFromChat(chatId);
            return Ok(result);
        }

        [HttpGet("get-chats-by-user")]
        public IActionResult GetChatsFromUser(int userId)
        {
            var result = _chatService.GetChatsFromUser(userId);
            return Ok(result);
        }
    }
}