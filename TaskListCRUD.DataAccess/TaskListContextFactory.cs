using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskListCRUD.DataAccess
{
    public class TaskListContextFactory : IDesignTimeDbContextFactory<TaskListContext>
    {
        public TaskListContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskListContext>();
            optionsBuilder.UseSqlite("Data Source=TaskListData.db");

            return new TaskListContext(optionsBuilder.Options);
        }
    }
}
