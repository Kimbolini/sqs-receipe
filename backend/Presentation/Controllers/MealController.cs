using backend.Models;
using backend.Presentation.Dtos;
using backend.Presentation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using log4net;
using MySqlConnector;

namespace backend.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealService _mealService;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasuredIngredientService _measuredIngredientService;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MealController(IMealService mealService, IIngredientService ingredientService, 
            IMeasuredIngredientService measuredIngredientService) 
        {
            _mealService = mealService;
            _ingredientService = ingredientService;
            _measuredIngredientService = measuredIngredientService;
        }

        //GET: api/<MealsController>
        //Get the list of meals in the database
        [HttpGet]
        public ActionResult<IEnumerable<MealDto>> Get()
        {
            //TODO: get meals vom Mealservice, get (measuredIngredients) + ingredients
            //von deren Service und dann hier zusammenfügen
            List<MealDto> tmplist = new();
            foreach(Meal m in _mealService.GetMeals())
            {
                tmplist.Add(new MealDto(m));
            }
            return Ok(tmplist);
        }

        //TODO : change to PUT?
        //POST: api/<MealsController>
        //Create a new meal in the database
        [HttpPost]
        public ActionResult<MealDto> Post([FromBody]MealDto mealDto)
        {
            //the ingredients and their amount are stored in two separate Datatypes. These must have the same length though.
            if (mealDto.Ingredients.Count != mealDto.Measures.Count)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, "Number of Ingredients and Measures doesn't match.");
            }         

            try
            {
                //Create a new meal
                Meal tmpMeal = new(
                    mealName: mealDto.Name,
                    drinkAlternative: mealDto.DrinkAlternative,
                    category: mealDto.Category,
                    area: mealDto.Area,
                    instructions: mealDto.Instructions,
                    thumbnailUrl: mealDto.ThumbnailUrl,
                    tags: mealDto.Tags,
                    youtubeUrl: mealDto.YoutubeUrl,
                    source: mealDto.Source,
                    imageSource: mealDto.ImageSource,
                    createCommonsConfirmed: mealDto.CreateCommonsConfirmed
                    );

                _mealService.CreateMeal(tmpMeal);
                log.Info("Created new Meal with Id: " + tmpMeal.MealId);

                //Create the Ingredients and the MeasuredIngredients of the meal

                int ctr = 0;
                //The amount of each ingredient are sent as an ICollection of strings
                foreach (string mi in mealDto.Measures)
                {
                    //The ingredients are sent as an ICollection of strings
                    //Check for each ingredient if it already exists in the database
                    int tmpIngrId;
                    string currentIngredientName = mealDto.Ingredients.ElementAt(ctr);
                    try
                    {
                        tmpIngrId = _ingredientService.GetIngredientByName(currentIngredientName).Id;
                    }
                    catch (KeyNotFoundException)
                    {
                        tmpIngrId = _ingredientService.CreateIngredient(new Ingredient(currentIngredientName, ""));
                    }

                    _measuredIngredientService.CreateMeasuredIngredient(new MeasuredIngredient(mi, tmpIngrId, tmpMeal.MealId));
                    ctr++;
                }

                return Ok(new MealDto(tmpMeal));
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException dbException)
            {
                if (dbException.InnerException is MySqlException innerException && (innerException.Number >= 1060 && innerException.Number <= 1062))
                {
                    log.Error("Failed to create project with exception: " + dbException);
                    System.Diagnostics.Debug.WriteLine("Duplicate Key");
                    log.Error("Duplicate Key while trying to post new Project.");
                    return StatusCode(StatusCodes.Status422UnprocessableEntity, "Duplicate Key while trying to post new Project.");
                }
                else
                {
                    return StatusCode(500);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        //DELETE api/<MealsController>/5
        //Delete a certain meal out of the database
        [HttpDelete("{id}")]
        public ActionResult<MealDto> Delete(int id)
        {
            if (id < 0) return BadRequest("Meal Id cannot be negative");
            try
            {
                var result = _mealService.RemoveMealById(id);
                if(result == null)
                {
                    return StatusCode(404, "Could not find the specified meal");
                }
                log.Info("The meal with the id " + id + " was successfully deleted.");
                return Ok(new MealDto(result));
            }
            catch(Exception e)
            {
                log.Error(e.Message);
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
