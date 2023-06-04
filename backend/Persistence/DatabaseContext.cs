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
       public DbSet<MeasuredIngredient> MeasuredIngredients { get; set; }   

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //one-to-many relationship between Ingredient & Measured Ingredient
            builder.Entity<MeasuredIngredient>()
                .HasOne(e => e.Ingredient)
                .WithMany(e => e.MeasuredIngredients)
                //.HasForeignKey(e => e.IngredientId)
                .IsRequired();

            //one-to-many relationship between Measured Ingredient & Meal
            builder.Entity<MeasuredIngredient>()
                .HasOne(e => e.Meal)
                .WithMany(e => e.MeasuredIngredients)
                //.HasForeignKey(e => e.MealId)
                .IsRequired();

            // ensure that the name of ingredients is unique
            builder.Entity<Ingredient>()
                .HasIndex(i => i.Name)
                .IsUnique();

            base.OnModelCreating(builder);
        }

        //only needed if onbeforesaving is used
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
    }
}
