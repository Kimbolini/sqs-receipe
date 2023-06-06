using backend.Models;

namespace backend.Presentation.Dtos
{
    public class IngredientDto
    {
        #region Constructors

        public IngredientDto(Ingredient ingredient)
        {
            this.Id = ingredient.Id;
            this.Name = ingredient.Name;
            this.Description = ingredient.Description;
        }

        //for deserialization
        public IngredientDto() : this(new Ingredient()){ }

        #endregion

        #region Properties

        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        #endregion
    }
}
