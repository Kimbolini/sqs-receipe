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

        //TODO: change to CreateMeal(Meal meal, ICollection<string> ingredients, ICollection<measures>?
        public int CreateMeal(Meal meal)
        {
            //add Meal to database and save
            _context.Meals.Add(meal);
            var linesInserted = _context.SaveChanges();
            System.Diagnostics.Debug.WriteLine("Inserted lines into meals table: " + linesInserted);

            //TODO: handle ingredients and measures?

            return meal.MealId;
        }

        public Meal[] GetMeals()
        {
            //excplicitely include measured ingredients as they don't get automatically loaded in a db set
            return _context.Meals
                .Include(m => m.MeasuredIngredients)
                .ThenInclude(mi => mi.Ingredient)
                .ToArray();        
        }

        public Meal RemoveMealById(int id)
        {
            Meal tmp = _context.Meals.FirstOrDefault(m => m.MealId == id);
            if(tmp != default(Meal))
            {
                _context.Meals.Remove(tmp);
                _context.SaveChanges();
            }
            return tmp;
        }
    }
}
