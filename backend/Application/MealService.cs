using backend.Models;
using backend.Presentation.Interfaces;

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

            //TODO: handle ingredients and measures?

            return meal.MealId;
        }

        public Meal[] GetMeals()
        {
            return _context.Meals.ToArray();
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
