using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Data
{
    public class TaskContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
