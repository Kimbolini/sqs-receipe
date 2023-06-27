using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        private ICollection<MeasuredIngredient> _measuredIngredients; 

        #region Constructors

        public Ingredient(string name, string? description)
        {
            Name = name;
            Description = description ?? "";
            //initialize the meals to be a list as the attribute shouldn't be null
            _measuredIngredients = new List<MeasuredIngredient>();
        }

        public Ingredient() : this("", null) { }

        #endregion

        #region Properties

        // Database-managed Id Attribute
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        #endregion

        public virtual ICollection<MeasuredIngredient> MeasuredIngredients
        {
            get => _measuredIngredients;
            set => _measuredIngredients = value;
        }
    }
}
