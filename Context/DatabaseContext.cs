using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class DatabaseContext : DbContext
    {
        public required DbSet<Cities> Cities { get; set; }
        public required DbSet<Sites> Sites { get; set; }
        public required DbSet<Buildings> Buildings { get; set; }
        public required DbSet<Floors> Floors { get; set; }
        public required DbSet<Rooms> Rooms { get; set; }
        public required DbSet<Facilities> Facilities { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {  }
    }
}
