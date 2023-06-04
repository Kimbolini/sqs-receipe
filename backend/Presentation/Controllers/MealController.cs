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
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public MealController(IMealService mealService) 
        {
            _mealService = mealService;
        }

        //GET: api/<MealsController>
        //Get the list of meals in the database
        [HttpGet]
        public ActionResult<IEnumerable<MealDto>> Get()
        {
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
            try
            {
                Meal tmp = new Meal();

                return Ok(new MealDto(tmp));
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
