using backend.Models;

namespace backend.Presentation.Interfaces
{
    /// <summary>
    /// This interface defines methods used by the presentation layer for handling meals 
    /// </summary>
    public interface IMealService
    {
        /// <summary>Create a new meal in the database with the given parameters </summary>
        /// <param name="Meal">The Meal to be created</param>
        /// <returns>Id of created Meal</returns>
        int CreateMeal(Meal meal);

        /// <summary>Return all meals</summary>
        /// <returns>Returns an array of all meals in the database</returns>
        Meal[] GetMeals();

        /// <summary>Remove a specific meal</summary>
        /// <param name="id">The Id of the meal</param>
        /// <returns>Returns the removed meal</returns>
        Meal RemoveMealById(int id);
    }
}
