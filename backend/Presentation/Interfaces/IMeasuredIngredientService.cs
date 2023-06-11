using backend.Models;

namespace backend.Presentation.Interfaces
{
    ///<summary>This interface defines methods to handle measured ingredients.</summary>
    public interface IMeasuredIngredientService
    {
        /// <summary>Create a new measuredIngredient in the database with the given parameters </summary>
        /// <param name="mIngredient">The measuredIngredient to be created</param>
        /// <returns>Id of created measuredIngredient</returns>
        int CreateMeasuredIngredient (MeasuredIngredient mIngredient);

        /// <summary>Returns a specific measuredIngredient by id</summary>
        /// <param name="id">The id of the measuredIngredient</param>
        /// <returns>MeasuredIngredient of the id</returns>
        MeasuredIngredient GetMeasuredIngredientById(int id);

        /// <summary>Returns all measuredIngredients of a certain meal</summary>
        /// <param name="mealId">The id of the meal</param>
        /// <returns>MeasuredIngredients of the specified meal</returns>
        ICollection<MeasuredIngredient> GetMeasuredIngredientByMealId(int mealId);
    }
}
