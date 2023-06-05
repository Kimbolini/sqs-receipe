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
        private string? _source;
        private string? _imageSource;
        private string? _creativeCommonsConfirmed;
        private ICollection<MeasuredIngredient> _measuredIngredients;

        #region Constructors

        public Meal(
            string mealName,
            string drinkAlternative,
            string category,
            string area,
            string instructions,
            string thumbnailUrl,
            string tags,
            string youtubeUrl,
            string source,
            string imageSource,
            string createCommonsConfirmed
            )
        { 
            _mealName = mealName;
            _drinkAlternative = drinkAlternative;
            _category = category;
            _area = area;
            _instructions = instructions;
            _thumbnailUrl = thumbnailUrl;
            _tags = tags;
            _youtubeUrl = youtubeUrl;
            _source = source;
            _imageSource = imageSource;
            _creativeCommonsConfirmed  = createCommonsConfirmed;
            //initialize the ICollection to be a list as the attribute shouldn't be null
            _measuredIngredients = new List<MeasuredIngredient>();
        }

        public Meal(string mealName, string instructions)
        {
            _mealName = mealName;
            _instructions = instructions;
            //initialize the ICollection to be a list as the attribute shouldn't be null
            _measuredIngredients = new List<MeasuredIngredient>();
        }

        public Meal() : this("", "") { }

        #endregion

        #region Properties

        // Database-managed Id Attribute
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int MealId
        {
            get => _mealId;
            set => _mealId = value;
        }

        [Required]
        public string MealName
        {
            get => _mealName;
            set => _mealName = value;
        }

        public string? DrinkAlternative
        {
            get => _drinkAlternative;
            set => _drinkAlternative = value;
        }

        public string? Category
        {
            get => _category;
            set => _category = value;
        }

        public string? Area
        {
            get => _area;
            set => _area = value;
        }

        [Required]
        public string Instructions
        {
            get => _instructions;
            set => _instructions = value;
        }

        public string? ThumbnailUrl
        {
            get => _thumbnailUrl;
            set => _thumbnailUrl = value;
        }

        public string? Tags
        {
            get => _tags;
            set => _tags = value;
        }

        public string? YoutubeUrl
        {
            get => _youtubeUrl;
            set => _youtubeUrl = value;
        }

        public string? Source
        {
            get => _source; 
            set => _source = value;
        }

        public string? ImageSource
        {
            get => _imageSource;
            set => _imageSource = value;
        }

        public string? CreativeCommonsConfirmend
        {
            get => _creativeCommonsConfirmed;
            set => _creativeCommonsConfirmed = value;
        }

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
