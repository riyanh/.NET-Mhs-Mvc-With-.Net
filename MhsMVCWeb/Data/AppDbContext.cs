using MhsMVCWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace MhsMVCWeb.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }
    }
}
