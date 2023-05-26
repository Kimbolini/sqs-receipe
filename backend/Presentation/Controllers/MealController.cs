using backend.Presentation.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace backend.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        public MealController() { }

        [HttpGet]
        public ActionResult<MealDto> Get()
        {
            return Ok();
        }
    }
}
