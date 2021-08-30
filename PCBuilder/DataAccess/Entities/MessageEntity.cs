using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.DataAccess.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? ChatId { get; set; }
    }
}
