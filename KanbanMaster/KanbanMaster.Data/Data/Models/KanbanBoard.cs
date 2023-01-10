namespace KanbanMaster.DataLayer.Data.Models
{
    public class KanbanBoard
    {
        public int KanbanBoardId { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<KanbanColumn> KanbanColumns { get; set; } = null!;
    }
}
