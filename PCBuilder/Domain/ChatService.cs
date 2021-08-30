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

        public ChatService(DataContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string text, int userId, int chatId)
        {
            //проверить есть ли пользователь в чате
            //создать сообщение

            if (userId == default || chatId == default || string.IsNullOrWhiteSpace(text))
            {
                throw new Exception("Invalid input data");
            }
            
            var isParticipant = _context.ChatUsers.FirstOrDefault(x => x.ChatId == chatId && x.UserId == userId) != null;

            if (isParticipant)
            {
                await _context.Messages.AddAsync(new MessageEntity
                {
                    Text = text,
                    ChatId = chatId,
                    UserId = userId
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

        public async Task AddUserToChat(int chatId, int userId)
        {
            await _context.ChatUsers.AddAsync(new ChatUserEntity
            {
                ChatId = chatId,
                UserId = userId
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

        public List<ChatEntity> GetChatsFromUser(int userId)
        {
            var result = _context.ChatUsers
                .Include(x => x.Chat)
                .Where(x => x.UserId == userId)
                .Select(x => x.Chat)
                .ToList();
            
            return result;
        }
    }
}