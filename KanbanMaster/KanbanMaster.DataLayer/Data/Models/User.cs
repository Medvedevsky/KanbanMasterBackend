namespace KanbanMaster.DataLayer.Data.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTimeOffset DateTime { get; set; }

        // Relationships
        public Role Role { get; set; } = null!;
        public KanbanUser KanbanUser { get; set; } = null!;
    }
}
