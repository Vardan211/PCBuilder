using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.DataAccess.Entities
{
    public class ChatUserEntity
    {
        public int Id { get; set; }
        public int? ChatId { get; set; }
        public int? UserId { get; set; }
        public ChatEntity Chat { get; set; }
        public ApplicationUser User { get; set; }
    }
}
