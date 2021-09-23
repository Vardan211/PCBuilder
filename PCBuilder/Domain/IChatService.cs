using System.Collections.Generic;
using System.Threading.Tasks;
using PCBuilder.DataAccess.Entities;

namespace PCBuilder.Domain
{
    public interface IChatService
    {
        Task SendMessage(string text, string username, int chatId);
        List<MessageEntity> GetMessagesByChat(int chatId);
        Task CreateChat(string name);
        Task AddUserToChat(int chatId, string username);
        List<ApplicationUser> GetUsersFromChat(int chatId);
        Task<List<ChatEntity>> GetChatsFromUser(string username);
    }
}
