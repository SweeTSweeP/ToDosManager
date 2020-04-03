using Microsoft.EntityFrameworkCore;
using ToDosManagerBackSide.Domain.Entities;

namespace ToDosManagerBackSide.Data
{
    public class ToDosManagerDbContext : DbContext
    {
        public DbSet<Day> Days { get; set; }
        public DbSet<Record> Tasks { get; set; }

        public ToDosManagerDbContext(DbContextOptions<ToDosManagerDbContext> options) : base(options)
        {
        }
    }
}