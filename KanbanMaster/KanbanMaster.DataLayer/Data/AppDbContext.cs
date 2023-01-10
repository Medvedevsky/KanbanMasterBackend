using KanbanMaster.DataLayer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace KanbanMaster.DataLayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<KanbanUser> KanbanUser { get; set; }
        public DbSet<KanbanBoard> KanbanBoard { get; set; }
        public DbSet<KanbanColumn> KanbanColumn { get; set; }
        public DbSet<KanbanCard> KanbanCard { get; set; }
        public DbSet<CardFile> CardFile { get; set; }
    }
}
