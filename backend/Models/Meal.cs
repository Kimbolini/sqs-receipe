using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace backend.Models
{
    [Table("Meals")]
    public class Meal
    {
        private int _mealId;
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
            string mealName,
            string instructions,
            ICollection<Ingredient> ingredients,
            ICollection<Measure> measures)
        { 
            this._mealName = mealName;
            this._instructions = instructions;
            this._ingredients  = ingredients;
            this._measures = measures;
        }

        public Meal() : this("", "", null, null) { }

        #region Properties

        // Database-managed Id Attribute
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int MealId
        {
            get => this._mealId;
            set => this._mealId = value;
        }

        [Required]
        public string MealName
        {
            get => this._mealName;
            set => this._mealName = value;
        }

        public string? DrinkAlternative
        {
            get => this._drinkAlternative;
            set => this._drinkAlternative = value;
        }

        public string? Category
        {
            get => this._category;
            set => this._category = value;
        }

        public string? Area
        {
            get => this._area;
            set => this._area = value;
        }

        [Required]
        public string Instructions
        {
            get => this._instructions;
            set => this._instructions = value;
        }

        public string? ThumbnailUrl
        {
            get => this._thumbnailUrl;
            set => this._thumbnailUrl = value;
        }

        public string? Tags
        {
            get => this._tags;
            set => this._tags = value;
        }

        public string? YoutubeUrl
        {
            get => this._youtubeUrl;
            set => this._youtubeUrl = value;
        }

        public string? Source
        {
            get => this._source; 
            set => this._source = value;
        }

        public string? ImageSource
        {
            get => this._imageSource;
            set => this._imageSource = value;
        }

        public string? CreativeCommonsConfirmend
        {
            get => this._creativeCommonsConfirmed;
            set => this._creativeCommonsConfirmed = value;
        }

        #endregion

        #region Navigations for references

        public virtual ICollection<Ingredient> Ingredients
        {
            get => this._ingredients;
            set => this._ingredients = value;
        }

        public virtual ICollection<Measure> Measures
        {
            get => this._measures;
            set => this._measures = value;
        }

        #endregion
    }
}
