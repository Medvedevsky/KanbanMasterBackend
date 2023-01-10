namespace KanbanMaster.DataLayer.Data.Models
{
    public class KanbanCard
    {
        public int KanbanCardId { get; set; }
        public int KanbanColumnId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset DateTime { get; set; }
        public string Path { get; set; } = string.Empty;

        // Relationships
        public ICollection<CardFile> CardFiles { get; set; } = null!;
        public KanbanColumn KanbanColumn { get; set; } = null!;

    }
}
