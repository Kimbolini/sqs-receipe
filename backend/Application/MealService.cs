using backend.Models;
using backend.Presentation.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Application
{
    public class MealService : IMealService
    {
        private readonly DatabaseContext _context;

        public MealService(DatabaseContext context)
        {
            _context = context;
        }

        public int CreateMeal(Meal meal)
        {
            //add Meal to database and save
            _context.Meals.Add(meal);
            var linesInserted = _context.SaveChanges();
            System.Diagnostics.Debug.WriteLine("Inserted lines into meals table: " + linesInserted);

            return meal.MealId;
        }

        public Meal GetMealById(int id)
        {
            var entity = _context.Meals
                .Include(m => m.MeasuredIngredients)
                .ThenInclude(mi => mi.Ingredient)
                .Select(meal => new Meal
                {
                    MealId = meal.MealId,
                    MealName = meal.MealName,
                    DrinkAlternative = meal.DrinkAlternative,
                    Category = meal.Category,
                    Area = meal.Area,
                    Instructions = meal.Instructions,
                    ThumbnailUrl = meal.ThumbnailUrl,
                    Tags = meal.Tags,
                    YoutubeUrl = meal.YoutubeUrl,
                    Source = meal.Source,
                    ImageSource = meal.ImageSource,
                    CreativeCommonsConfirmend = meal.CreativeCommonsConfirmend,
                    MeasuredIngredients = meal.MeasuredIngredients
                }).SingleOrDefault(m => m.MealId == id);

            return entity ?? throw new KeyNotFoundException();
        }

        public Meal[] GetMeals()
        {
            //excplicitely include measured ingredients as they don't get automatically loaded in a db set
            return _context.Meals
                .Include(m => m.MeasuredIngredients)
                .ThenInclude(mi => mi.Ingredient)
                .Select(meal => new Meal
                {
                    MealId = meal.MealId,
                    MealName = meal.MealName,
                    DrinkAlternative = meal.DrinkAlternative,
                    Category = meal.Category,
                    Area = meal.Area,
                    Instructions = meal.Instructions,
                    ThumbnailUrl = meal.ThumbnailUrl,
                    Tags = meal.Tags,
                    YoutubeUrl = meal.YoutubeUrl,
                    Source = meal.Source,
                    ImageSource = meal.ImageSource,
                    CreativeCommonsConfirmend = meal.CreativeCommonsConfirmend,
                    MeasuredIngredients = meal.MeasuredIngredients
                })
                .ToArray();        
        }

        public Meal RemoveMealById(int id)
        {
            var tmp = _context.Meals.SingleOrDefault(m => m.MealId == id);
            if(tmp != default(Meal))
            {
                _context.Meals.Remove(tmp);
                _context.SaveChanges();
            }  else
            {
                throw new KeyNotFoundException();
            }
            return tmp;
        }
    }
}
