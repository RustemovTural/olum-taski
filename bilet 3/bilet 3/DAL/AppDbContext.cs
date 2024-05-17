using bilet_3.Models;
using Microsoft.EntityFrameworkCore;

namespace bilet_3.DAL
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
