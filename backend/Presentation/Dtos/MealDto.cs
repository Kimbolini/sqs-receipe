using backend.Models;

namespace backend.Presentation.Dtos
{
    public class MealDto
    {
        public MealDto(Meal Meal) 
        {
            this.Id = Meal.MealId;
            this.Name = Meal.MealName;
            this.DrinkAlternative = Meal.DrinkAlternative;
            this.Category = Meal.Category;
            this.Area = Meal.Area;
            this.Instructions = Meal.Instructions;
            this.ThumbnailUrl = Meal.ThumbnailUrl;
            this.Tags = Meal.Tags;
            this.YoutubeUrl = Meal.YoutubeUrl;
            this.Source = Meal.Source;
            this.ImageSource = Meal.ImageSource;
            this.CreateCommonsConfirmed = Meal.CreativeCommonsConfirmend;
            this.Measures = new List<string>();
            this.Ingredients = new List<string>();

            if(Meal.MeasuredIngredients.Count > 0)
            {
                foreach (MeasuredIngredient mi in Meal.MeasuredIngredients)
                {
                    this.Measures.Add(mi.AmountOf);
                    this.Ingredients.Add(mi.Ingredient.Name);
                }
            }

        }

        //for deserialization
        public MealDto() : this(new Meal()) { }

        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string? DrinkAlternative { get; set; }

        public string? Category { get; set; }

        public string? Area { get; set; }
        
        public string Instructions { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string? Tags { get; set; }

        public string? YoutubeUrl { get; set; }

        public string? Source { get; set; }

        public string? ImageSource { get; set; }

        public string? CreateCommonsConfirmed { get; set; }

        public ICollection<string> Ingredients { get; set; }

        public ICollection<string> Measures { get; set; }
        #endregion

    }
}
