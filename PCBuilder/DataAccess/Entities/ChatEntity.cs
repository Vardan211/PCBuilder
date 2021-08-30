using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.DataAccess.Entities
{
    public class ChatEntity
    {
        public int Id { get; set; }
        public List<MessageEntity> Messages { get; set; }
        
    }
}
