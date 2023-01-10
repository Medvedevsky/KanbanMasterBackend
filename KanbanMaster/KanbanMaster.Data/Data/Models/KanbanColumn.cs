namespace KanbanMaster.DataLayer.Data.Models
{
    public class KanbanColumn
    {
        public int KanbanColumnId { get; set; }
        public int KanbanBoardId { get; set; }
        public string Name { get; set; } = string.Empty;

        // Relationships
        public KanbanBoard KanbanBoard { get; set; } = null!;
        public ICollection<KanbanCard> KanbanCards { get; set; } = null!;
    }
}
