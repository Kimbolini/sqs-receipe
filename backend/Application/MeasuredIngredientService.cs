using backend.Models;
using backend.Presentation.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Application
{
    public class MeasuredIngredientService : IMeasuredIngredientService
    {
        private readonly DatabaseContext _context;

        public MeasuredIngredientService(DatabaseContext context)
        {
            _context = context;
        }

        public int CreateMeasuredIngredient(MeasuredIngredient mIngredient)
        {
            _context.MeasuredIngredients.Add(mIngredient);
            var linesInserted = _context.SaveChanges();
            System.Diagnostics.Debug.WriteLine("Inserted lines into ingredients table: " + linesInserted);

            //return Id of created ingredient
            return mIngredient.Id;
        }

        public MeasuredIngredient GetMeasuredIngredientById(int id)
        {
            MeasuredIngredient? tmp = _context.MeasuredIngredients.SingleOrDefault(mi => mi.Id == id);
            if (tmp == default(MeasuredIngredient) || (tmp == null))
            {
                throw new KeyNotFoundException();
            }
            return tmp;
        }

        public ICollection<MeasuredIngredient> GetMeasuredIngredientByMealId(int mealId)
        {
            var result = new List<MeasuredIngredient>();
            foreach (
                MeasuredIngredient mi in 
                _context.Meals.Include(m => m.MeasuredIngredients)
                .Single(m => m.MealId == mealId)
                .MeasuredIngredients) 
            {
                result.Add(mi);
            }

            return result;
        }
    }
}
