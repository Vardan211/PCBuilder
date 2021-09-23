using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PCBuilder.DataAccess;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public class ChatService : IChatService
    {
        private readonly DataContext _context;
        private readonly IUserService _userService;
        public ChatService(DataContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task SendMessage(string text, string username, int chatId)
        {
            //проверить есть ли пользователь в чате
            //создать сообщение

            if (username == default || chatId == default || string.IsNullOrWhiteSpace(text))
            {
                throw new Exception("Invalid input data");
            }
            var user = await _userService.GetUserByUsername(username);
            var isParticipant = _context.ChatUsers.FirstOrDefault(x => x.ChatId == chatId && x.UserId == user.Id) != null;

            if (isParticipant)
            {
                await _context.Messages.AddAsync(new MessageEntity
                {
                    Text = text,
                    ChatId = chatId,
                    UserId = user.Id
                });
                await _context.SaveChangesAsync();
            }
        }

        public List<MessageEntity> GetMessagesByChat(int chatId)
        {
            var messages = _context.Messages.Where(x => x.Id == chatId).ToList();

            return messages;
        }

        public async Task CreateChat(string name)
        {
            await _context.Chats.AddAsync(new ChatEntity
            {
                Name = name
            });

            await _context.SaveChangesAsync();
        }

        public async Task AddUserToChat(int chatId, string username)
        {
            var user = await _userService.GetUserByUsername(username);
            await _context.ChatUsers.AddAsync(new ChatUserEntity
            {
                ChatId = chatId,
                UserId = user.Id
            });
            
            await _context.SaveChangesAsync();
        }

        public List<ApplicationUser> GetUsersFromChat(int chatId)
        {
            var result = _context.ChatUsers
                .Include(x => x.User)
                .Where(x => x.ChatId == chatId)
                .Select(x => x.User)
                .ToList();
            
            return result;
        }

        public async Task<List<ChatEntity>> GetChatsFromUser(string username)
        {
            var user = await _userService.GetUserByUsername(username);
            var result = _context.ChatUsers
                .Include(x => x.Chat)
                .Where(x => x.UserId == user.Id)
                .Select(x => x.Chat)
                .ToList();
            
            return result;
        }
    }
}