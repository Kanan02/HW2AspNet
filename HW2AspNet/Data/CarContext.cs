using HW2AspNet.Models;
using Microsoft.EntityFrameworkCore;

namespace HW2AspNet.Data
{
    public class CarContext:DbContext
    {
        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

            Database.EnsureCreated();

        }
        public DbSet<Car> Cars { get; set; }
    }
}
