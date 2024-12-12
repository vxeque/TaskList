using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TaskListCRUD.DataAccess
{
    public class TaskListContext : DbContext
    {

        //private readonly IConfiguration _configuration;

        public TaskListContext(DbContextOptions<TaskListContext> options) : base(options)
        {

        }
        public DbSet<TaskListData> TaskListData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskListData>(entity =>
            {
                entity.HasKey(e => e.id);
                entity.ToTable("TaskListData");
            });
        }

    }
}
