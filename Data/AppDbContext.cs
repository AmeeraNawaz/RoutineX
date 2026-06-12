using Microsoft.EntityFrameworkCore;
using samplecrud.Models;

namespace samplecrud.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<RoutineTask> RoutineTasks { get; set; }
    }
}