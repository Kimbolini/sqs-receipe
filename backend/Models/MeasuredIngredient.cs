using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace backend.Models
{
    //Puts together the amount (e.g. 1 tablespoon) and the Ingredient
    [Table("MeasuredIngredients")]
    public class MeasuredIngredient
    {
        private int _id;
        private string _amountOf;

        #region Constructors

        /*
        public MeasuredIngredient(string amountOf, Ingredient ingredient, Meal meal)
        {
            _amountOf = amountOf;
            Ingredient = ingredient;
            IngredientId = ingredient.Id;
            Meal = meal;
            MealId = meal.MealId;
        }*/

        public MeasuredIngredient(string amountOf, int ingredientId, int mealId)
        {
            _amountOf = amountOf;
            IngredientId = ingredientId;
            MealId = mealId;
        }

        public MeasuredIngredient() : this("", new Ingredient().Id, new Meal().MealId) { }

        #endregion

        #region Properties

        // Database-managed Id Attribute
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        [Required, MaxLength(100)]
        public string AmountOf
        {
            get => _amountOf;
            set => _amountOf = value;
        }

        [Required]
        [ForeignKey("Ingredient")]
        public int IngredientId
        {
            get;
            set;
        }

        public virtual Ingredient? Ingredient
        {
            get;
            set;
        }

        [Required]
        [ForeignKey("Meal")]
        public int MealId
        {
            get;
            set; 
        }

        public virtual Meal? Meal
        {
            get;
            set;
        }

        #endregion
    }
}
