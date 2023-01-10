namespace KanbanMaster.DataLayer.Data.Models
{
    public class CardFile
    {
        public int CardFileId { get; set; }
        public int KanbanCardId { get; set; }
        public string Path { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        // Relationships
        public KanbanCard KanbanCard { get; set; } = null!;
    }
}
