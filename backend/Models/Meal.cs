using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Persistence
{
    [Table("Meals")]
    public class Meal
    {
        private string _mealId;
        private string _mealName;
        private string? _drinkAlternative;
        private string? _category;
        private string? _area;
        private string _instructions;
        private string? _thumbnailUrl;
        private string? _tags;
        private string? _youtubeUrl;
        private ICollection<Ingredient> _ingredients;
        private ICollection<Measure> _measures;
        private string? _source;
        private string? _imageSource;
        private string? _creativeCommonsConfirmed;

        public Meal(
            string mealId,
            string mealName,
            string instructions,
            ICollection<Ingredient> ingredients,
            ICollection<Measure> measures)
        {
            this._mealId = mealId; 
            this._mealName = mealName;
            this._instructions = instructions;
            this._ingredients  = ingredients;
            this._measures = measures;
        }

    }
}
