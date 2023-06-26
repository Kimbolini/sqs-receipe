using backend.Application;
using backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    /*
     * This class defines the database scheme.
     * All accesses of data in the database get handled through this class.
     */
    public class DatabaseContext : DbContext
    {
        public DbSet<Meal> Meals => Set<Meal>();
        public DbSet<Ingredient> Ingredients => Set<Ingredient>();
        public DbSet<MeasuredIngredient> MeasuredIngredients => Set<MeasuredIngredient>();   

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-many relationship between Ingredient & Measured Ingredient
            modelBuilder.Entity<MeasuredIngredient>()
                .HasOne(e => e.Ingredient)
                .WithMany(e => e.MeasuredIngredients)
                //.HasForeignKey(e => e.IngredientId)
                .IsRequired();

            //one-to-many relationship between Measured Ingredient & Meal
            modelBuilder.Entity<MeasuredIngredient>()
                .HasOne(e => e.Meal)
                .WithMany(e => e.MeasuredIngredients)
                //.HasForeignKey(e => e.MealId)
                .IsRequired();

            //ensure that the name of ingredients is unique
            modelBuilder.Entity<Ingredient>()
                .HasIndex(i => i.Name)
                .IsUnique();

            //seed tables
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}
