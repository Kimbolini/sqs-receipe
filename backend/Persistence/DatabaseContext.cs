using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    /*
     * This class defines the database scheme.
     * All accesses of data in the database get handled through this class.
     */
    public class DatabaseContext : DbContext
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Measure> Measures { get; set; }   

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //only needed if onbeforesaving is used
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
