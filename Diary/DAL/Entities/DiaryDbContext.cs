using System.Data.Entity;

namespace DiaryDAL.Entities
{
    public class DiaryDbContext : DbContext
    {
        public DiaryDbContext(string connection) : base(connection) {}

        public DbSet<Note> Notes { get; set; }
    }
}
