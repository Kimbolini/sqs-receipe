using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Persistence
{
    [Table("Meals")]
    public class Meal
    {
        private string mealId;
        private string mealName;
        private string? drinkAlternative;
        private string? category;
        private string? area;
        private string instructions;
        private string? thumbnailUrl;
        private string? tags;
        private string? youtubeUrl;
        private ICollection<Ingredient> ingredients;
        private ICollection<Measure> measures;
        private string? source;
        private string? imageSource;
        private string? creativeCommonsConfirmed;

        public Meal(
            string mealId,
            string mealName,
            string instructions,
            ICollection<Ingredient> ingredients,
            ICollection<Measure> measures)
        {
            this.mealId = mealId; 
            this.mealName = mealName;
            this.instructions = instructions;
            this.ingredients  = ingredients;
            this.measures = measures;
        }

    }
}
