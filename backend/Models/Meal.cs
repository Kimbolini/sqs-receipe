using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace backend.Models
{
    [Table("Meals")]
    public class Meal
    {
        private ICollection<MeasuredIngredient> _measuredIngredients;

        #region Constructors

        public Meal(
            string mealName,
            string? drinkAlternative,
            string? category,
            string? area,
            string instructions,
            string? thumbnailUrl,
            string? tags,
            string? youtubeUrl,
            string? source,
            string? imageSource,
            string? createCommonsConfirmed
            )
        { 
            MealName = mealName;
            DrinkAlternative = drinkAlternative;
            Category = category;
            Area = area;
            Instructions = instructions;
            ThumbnailUrl = thumbnailUrl;
            Tags = tags;
            YoutubeUrl = youtubeUrl;
            Source = source;
            ImageSource = imageSource;
            CreativeCommonsConfirmend = createCommonsConfirmed;
            //initialize the ICollection to be a list as the attribute shouldn't be null
            _measuredIngredients = new List<MeasuredIngredient>();
        }

        public Meal(string mealName, string instructions)
        {
            MealName = mealName;
            Instructions = instructions;
            //initialize the ICollection to be a list as the attribute shouldn't be null
            _measuredIngredients = new List<MeasuredIngredient>();
        }

        public Meal() : this("", "") { }

        #endregion

        #region Properties

        // Database-managed Id Attribute
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int MealId { get; set; }

        [Required]
        public string MealName { get; set; }

        public string? DrinkAlternative { get; set; }

        public string? Category { get; set; }

        public string? Area { get; set; }

        [Required]
        public string Instructions { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string? Tags { get; set; }

        public string? YoutubeUrl { get; set; }

        public string? Source { get; set; }

        public string? ImageSource { get; set; }

        public string? CreativeCommonsConfirmend { get; set; }

        #endregion

        #region Navigations for references

        public virtual ICollection<MeasuredIngredient> MeasuredIngredients
        {
            get => _measuredIngredients;
            set => _measuredIngredients = value;
        }

        #endregion
    }
}
