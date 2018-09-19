using System.Data.Entity;

namespace Xm.Trial.Models.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Post> Posts{ get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<PostStatistics> PostsStatistics { get; set; }
    }
}