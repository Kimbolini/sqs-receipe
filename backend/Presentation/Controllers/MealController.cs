using backend.Models;
using backend.Presentation.Dtos;
using backend.Presentation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using log4net;

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

        //DELETE api/<MealsController>/5
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
