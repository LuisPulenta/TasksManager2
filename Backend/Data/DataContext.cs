using Microsoft.EntityFrameworkCore;
using Shared.Entities;

namespace Backend.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options ):base(options) 
        { 
        }

        public DbSet<MyTask> MyTasks { get; set; }
    }
}
