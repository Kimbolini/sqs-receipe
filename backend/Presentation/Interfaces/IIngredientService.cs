using backend.Models;

namespace backend.Presentation.Interfaces
{
    ///<summary>This interface defines methods to handle ingredients.</summary>
    public interface IIngredientService
    {
        /// <summary>Create a new ingredient in the database with the given parameters </summary>
        /// <param name="ingredient">The ingredient to be created</param>
        /// <returns>Id of created ingredient</returns>
        int CreateIngredient(Ingredient ingredient);

        /// <summary>Returns a specific ingredient by id</summary>
        /// <param name="id">The id of the ingredient</param>
        /// <returns>Ingredient of the id</returns>
        Ingredient GetIngredientById(int id);

        /// <summary>Returns a specific ingredient by name</summary>
        /// <param name="name">The name of the ingredient</param>
        /// <returns>Ingredient of the name</returns>
        Ingredient GetIngredientByName(string name);

        //Get Ingredients by measuredIngredientId?
    }
}
