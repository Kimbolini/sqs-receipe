using backend.Models;

namespace backend.Presentation.Dtos
{
    public class MeasuredIngredientDto
    {
        #region Constructors

        public MeasuredIngredientDto(MeasuredIngredient mingredient) 
        {
            this.Id = mingredient.Id;
            this.AmountOf = mingredient.AmountOf;
            this.IngredientId = mingredient.IngredientId;
            this.MealId = mingredient.MealId;
        }

        public MeasuredIngredientDto() : this(new MeasuredIngredient()) { }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string AmountOf { get; set; }

        public int IngredientId { get; private set; }

        public int MealId { get; private set; }

        #endregion
    }
}
