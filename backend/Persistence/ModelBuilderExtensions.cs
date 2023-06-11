using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Persistence
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Extension to be used by a ModelBuilder by the EF. Can be called e. g. in OnModelCreating to seed
        /// the values of the Enum into a table. 
        /// </summary>
        /// <typeparam name="T">Class implementing enum and table in EF to get seeded</typeparam>
        /// <typeparam name="TEnum">Enum you want to seed</typeparam>
        /// <param name="mb">the ModelBuilder you use this method on</param>
        /// <param name="converter">function that actually seeds the values. Can be something like this: 
        ///         e => e
        /// </param>
        public static void SeedEnumValues<T, TEnum>(this ModelBuilder mb, Func<TEnum, T> converter) where T : class
            => Enum.GetValues(typeof(TEnum))
                           .Cast<object>()
                           .Select(value => converter((TEnum)value))
                           .ToList()
                            .ForEach(instance => mb.Entity<T>().HasData(instance));

        public static void Seed(this ModelBuilder builder)
        {
            
            // pre-fill table Ingredients
            List<string> ingredients = new()
            {
                "Absinthe",
                "Advocaat",
                "Ale",
                "Anis",
                "Chicken"
            };
            int ctr = 0;
            foreach(string i in ingredients)
            {
                builder.Entity<Ingredient>().HasData(new Ingredient { Id = ctr + 1, Name = i });
                ctr++;
            }

            //pre-fill table Meals


            Meal tmp1 = new Meal(
                mealName: "SpaghettiFancy",
                drinkAlternative: "",
                category: "",
                area: "Italian",
                instructions: "First do this, then that",
                thumbnailUrl: "https://sth",
                tags: "pasta",
                youtubeUrl: "",
                source: "",
                imageSource: "",
                createCommonsConfirmed: ""
                );
            Meal tmp2 = new Meal(
                mealName: "SpaghettiItaliaaaa",
                drinkAlternative: "",
                category: "",
                area: "Italian",
                instructions: "First do this, then that",
                thumbnailUrl: "https://sth",
                tags: "pasta",
                youtubeUrl: "",
                source: "",
                imageSource: "",
                createCommonsConfirmed: ""
                );
            tmp1.MealId = 1;
            tmp2.MealId = 2;
            builder.Entity<Meal>().HasData(tmp1);
            builder.Entity<Meal>().HasData(tmp2);
        }
    }
}
