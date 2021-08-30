using System.Collections.Generic;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IChatService
    {
        Task SendMessage(string text, int userId, int chatId);
        List<MessageEntity> GetMessagesByChat(int chatId);
        Task CreateChat(string name);
        Task AddUserToChat(int chatId, int userId);
        List<ApplicationUser> GetUsersFromChat(int chatId);
        List<ChatEntity> GetChatsFromUser(int userId);
    }
}