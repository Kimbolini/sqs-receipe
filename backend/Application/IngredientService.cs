using backend.Models;
using backend.Presentation.Interfaces;

namespace backend.Application
{
    public class IngredientService : IIngredientService
    {
        private readonly DatabaseContext _context;

        public IngredientService(DatabaseContext context) 
        {
            _context = context;
        }

        public int CreateIngredient(Ingredient ingredient)
        {
            _context.Ingredients.Add(ingredient);
            var linesInserted = _context.SaveChanges();
            System.Diagnostics.Debug.WriteLine("Inserted lines into ingredients table: " + linesInserted);

            //return Id of created ingredient
            return ingredient.Id;
        }

        public Ingredient GetIngredientById(int id)
        {
            Ingredient? tmp = _context.Ingredients.SingleOrDefault(i => i.Id == id);
            if(tmp == default(Ingredient) || (tmp == null))
            {
                throw new KeyNotFoundException();
            }
            return tmp;
        }

        public Ingredient GetIngredientByName(string name)
        {
            Ingredient? tmp = _context.Ingredients.SingleOrDefault(i => i.Name == name);
            if (tmp == default(Ingredient) || (tmp == null))
            {
                throw new KeyNotFoundException();
            }
            return tmp;
        }
    }
}
