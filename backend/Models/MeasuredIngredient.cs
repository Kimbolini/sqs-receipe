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
        private Ingredient _ingredient;
        private Meal _meal;

        #region Constructors

        public MeasuredIngredient(string amountOf, Ingredient ingredient, Meal meal)
        {
            _amountOf = amountOf;
            _ingredient = ingredient;
            _meal = meal;
        }

        public MeasuredIngredient() : this("", new Ingredient(), new Meal()) { }

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
        [Column("IngredientId")]
        public virtual Ingredient Ingredient
        {
            get => _ingredient;
            set => _ingredient = value;
        }

        [Required]
        [Column("MealId")]
        public virtual Meal Meal
        {
            get => _meal;
            set => _meal = value;
        }

        #endregion
    }
}
