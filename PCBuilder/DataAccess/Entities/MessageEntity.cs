using System;

namespace PCBuilder.DataAccess.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public int? ChatId { get; set; }
    }
}
