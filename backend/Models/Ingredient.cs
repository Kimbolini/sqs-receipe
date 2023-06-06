using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    [Table("Ingredients")]
    public class Ingredient
    {
        private int _id;
        private string _name;
        private string? _description;
        private ICollection<MeasuredIngredient> _measuredIngredients; //Needed?

        #region Constructors

        public Ingredient(string name, string? description)
        {
            _name = name;
            _description = description ?? "";
            //initialize the meals to be a list as the attribute shouldn't be null
            _measuredIngredients = new List<MeasuredIngredient>();
        }

        /*
        public Ingredient(string name, string description, ICollection<MeasuredIngredient> measuredIngredients)
        {
            _name = name;
            _description = description;
            _measuredIngredients = measuredIngredients;
        }*/

        public Ingredient() : this("", null) { }

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
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string? Description
        {
            get => _description;
            set => _description = value;
        }

        #endregion

        public virtual ICollection<MeasuredIngredient> MeasuredIngredients
        {
            get => _measuredIngredients;
            set => _measuredIngredients = value;
        }
    }
}
