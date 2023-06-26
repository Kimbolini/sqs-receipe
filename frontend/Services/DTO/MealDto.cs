using frontend.Data;

namespace frontend.Services.DTO
{
    public class MealDto
    {
        //Database ID
        public int Id { get; set; }
        //API ID
        public string StrId { get; set; }
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
        public bool Selected { get; set; }
        public bool IsFavourite { get; set; }
        public ICollection<string> Ingredients { get; set; }
        public ICollection<string> Measures { get; set; }

        public MealDto(Meal meal)
        {
            this.Id = 0; //doesn't matter, gets a new id in the database anyway
            this.StrId = meal.idMeal;
            this.Name = meal.strMeal;
            this.DrinkAlternative = meal.strDrinkAlternate;
            this.Category = meal.strCategory;
            this.Area = meal.strArea;
            this.Instructions = meal.strInstructions;
            this.ThumbnailUrl = meal.strMealThumb;
            this.Tags = meal.strTags;
            this.YoutubeUrl = meal.strYoutube;
            this.Source = meal.strSource;
            this.ImageSource = meal.strImageSource;
            this.CreateCommonsConfirmed = meal.strCreativeCommonsConfirmed;
            this.Ingredients = new List<string>();
            this.Measures = new List<string>();
            ConvertIngredientsMeasures(meal);
        }

        public MealDto()
        {
            this.StrId = "";
            this.Name = "";
            this.Instructions = "";
            this.Ingredients = new List<string>();
            this.Measures = new List<string>();
        }

        //The ingredients and measures are sent as a maximum of 20 single strings over the API
        //Should be sent over the Db API as an ICollection of strings.
        private void ConvertIngredientsMeasures(Meal meal)
        {
            this.Ingredients.Add(meal.strIngredient1);
            this.Measures.Add(meal.strMeasure1);
            //20 hardcoded since it's the maximum. Ugly but API won't change in the next few weeks.
            //Ingredients and Measures have the same amount.
            if(meal.strIngredient2 != null && meal.strIngredient2 != "")
            {
                this.Ingredients.Add(meal.strIngredient2);
                this.Measures.Add(meal.strMeasure2);
            } else
            {
                return;
            }
            if (meal.strIngredient3 != null && meal.strIngredient3 != "")
            {
                this.Ingredients.Add(meal.strIngredient3);
                this.Measures.Add(meal.strMeasure3);
            } else
            {
                return;
            }
            if (meal.strIngredient4 != null && meal.strIngredient4 != "")
            {
                this.Ingredients.Add(meal.strIngredient4);
                this.Measures.Add(meal.strMeasure4);
            }else
            {
                return;
            }
            if (meal.strIngredient5 != null && meal.strIngredient5 != "")
            {
                this.Ingredients.Add(meal.strIngredient4);
                this.Measures.Add(meal.strMeasure5);
            }
            else
            {
                return;
            }
            if (meal.strIngredient6 != null && meal.strIngredient6 != "")
            {
                this.Ingredients.Add(meal.strIngredient6);
                this.Measures.Add(meal.strMeasure6);
            }
            else
            {
                return;
            }
            if (meal.strIngredient7 != null && meal.strIngredient7 != "")
            {
                this.Ingredients.Add(meal.strIngredient7);
                this.Measures.Add(meal.strMeasure7);
            }
            else
            {
                return;
            }
            if (meal.strIngredient8 != null && meal.strIngredient8 != "")
            {
                this.Ingredients.Add(meal.strIngredient8);
                this.Measures.Add(meal.strMeasure8);
            }
            else
            {
                return;
            }
            if (meal.strIngredient9 != null && meal.strIngredient9 != "")
            {
                this.Ingredients.Add(meal.strIngredient9);
                this.Measures.Add(meal.strMeasure9);
            }
            else
            {
                return;
            }
            if (meal.strIngredient10 != null && meal.strIngredient10 != "")
            {
                this.Ingredients.Add(meal.strIngredient10);
                this.Measures.Add(meal.strMeasure10);
            }
            else
            {
                return;
            }
            if (meal.strIngredient11 != null && meal.strIngredient11 != "")
            {
                this.Ingredients.Add(meal.strIngredient11);
                this.Measures.Add(meal.strMeasure11);
            }
            else
            {
                return;
            }
            if (meal.strIngredient12 != null && meal.strIngredient12 != "")
            {
                this.Ingredients.Add(meal.strIngredient12);
                this.Measures.Add(meal.strMeasure12);
            }
            else
            {
                return;
            }
            if (meal.strIngredient13 != null && meal.strIngredient13 != "")
            {
                this.Ingredients.Add(meal.strIngredient13);
                this.Measures.Add(meal.strMeasure13);
            }
            else
            {
                return;
            }
            if (meal.strIngredient14!= null && meal.strIngredient14 != "")
            {
                this.Ingredients.Add(meal.strIngredient14);
                this.Measures.Add(meal.strMeasure14);
            }
            else
            {
                return;
            }
            if (meal.strIngredient15 != null && meal.strIngredient15 != "")
            {
                this.Ingredients.Add(meal.strIngredient15);
                this.Measures.Add(meal.strMeasure15);
            }
            else
            {
                return;
            }
            if (meal.strIngredient16 != null && meal.strIngredient16 != "")
            {
                this.Ingredients.Add(meal.strIngredient16);
                this.Measures.Add(meal.strMeasure16);
            }
            else
            {
                return;
            }
            if (meal.strIngredient17 != null && meal.strIngredient17 != "")
            {
                this.Ingredients.Add(meal.strIngredient17);
                this.Measures.Add(meal.strMeasure17);
            }
            else
            {
                return;
            }
            if (meal.strIngredient18 != null && meal.strIngredient18 != "")
            {
                this.Ingredients.Add(meal.strIngredient18);
                this.Measures.Add(meal.strMeasure18);
            }
            else
            {
                return;
            }
            if (meal.strIngredient19 != null && meal.strIngredient19 != "")
            {
                this.Ingredients.Add(meal.strIngredient19);
                this.Measures.Add(meal.strMeasure19);
            }
            else
            {
                return;
            }
            if (meal.strIngredient20 != null && meal.strIngredient20 != "")
            {
                this.Ingredients.Add(meal.strIngredient20);
                this.Measures.Add(meal.strMeasure20);
            }
        }
    }
}
