namespace KanbanMaster.DataLayer.Data.Models
{
    public class KanbanUser
    {
        public int KanbanUserId { get; set; }
        public string Nickname { get; set; } = string.Empty;

        // Relationships 1:1
        public User User { get; set; } = null!;
    }
}
