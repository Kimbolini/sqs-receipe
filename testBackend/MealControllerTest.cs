using backend.Models;
using backend.Presentation.Controllers;
using backend.Presentation.Dtos;
using backend.Presentation.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace testBackend
{
    [TestClass]
    public class MealControllerTest
    {
        protected MealController _mealController;
        protected Mock<IMealService> _mealServiceMock;
        protected Mock<IIngredientService> _ingredientServiceMock;
        protected Mock<IMeasuredIngredientService> _measIngredientServiceMock;

        protected Ingredient[] _testIngredients = new Ingredient[]{
            new Ingredient("Chicken", null) { Id = 1 },
            new Ingredient("Potatoes", null) { Id = 2},
            new Ingredient("Peas", null) { Id = 3 }
        };

        protected Meal[] _testMeals = new Meal[]{
            new Meal("Chicken with Potatoes", "Do things") { MealId = 1 },
            new Meal("Chickpeas", "Do other things") { MealId = 2 }
        };

        protected MeasuredIngredient[] _testMeasIngredients = new MeasuredIngredient[]
        {
            new MeasuredIngredient("500g", 1, 1) { Id = 1 },
            new MeasuredIngredient("350g", 2, 1) { Id = 2 },
            new MeasuredIngredient("4 EL", 3, 1) { Id = 3 }
        };
        

        public MealControllerTest()
        {            
            SetupIngredients();
            SetupMeasuredIngredients();
            SetupMeals();
            _mealController = new MealController(_mealServiceMock.Object, _ingredientServiceMock.Object, _measIngredientServiceMock.Object);
        }

        #region Setup

        private void SetupIngredients()
        {
            _ingredientServiceMock = new Mock<IIngredientService>();

            _ingredientServiceMock.SetupSequence(i => i.GetIngredientById(It.IsInRange(1, 3, Moq.Range.Inclusive)))
                .Returns(_testIngredients[0])
                .Returns(_testIngredients[1])
                .Returns(_testIngredients[2]);
            _ingredientServiceMock.Setup(i => i.GetIngredientById(It.IsNotIn(1, 3)))
                .Throws(new KeyNotFoundException());

            _ingredientServiceMock.Setup(i => i.GetIngredientByName("Chicken"))
                 .Returns(_testIngredients[0]);
            _ingredientServiceMock.Setup(i => i.GetIngredientByName("Potatoes"))
                .Returns(_testIngredients[1]);
            _ingredientServiceMock.Setup(i => i.GetIngredientByName("Peas"))
                .Returns(_testIngredients[2]);
            _ingredientServiceMock.Setup(i => i.GetIngredientByName(It.IsNotIn("Chicken", "Potatoes", "Peas")))
                .Throws(new KeyNotFoundException());
        }

        private void SetupMeasuredIngredients()
        {
            _measIngredientServiceMock = new Mock<IMeasuredIngredientService>();

            _measIngredientServiceMock.Setup(mis => mis.GetMeasuredIngredientById(It.IsInRange(1, 3, Moq.Range.Inclusive)))
                .Returns(_testMeasIngredients[0]);
            _measIngredientServiceMock.Setup(mis => mis.GetMeasuredIngredientById(It.IsInRange(-99999, 0, Moq.Range.Inclusive)))
                .Throws(new KeyNotFoundException());

        }

        private void SetupMeals()
        {
            _mealServiceMock = new Mock<IMealService>();

            _mealServiceMock.Setup(ms => ms.GetMeals())
                .Returns(_testMeals);

            _mealServiceMock.Setup(ms => ms.GetMealById(It.IsInRange(1, 2, Moq.Range.Inclusive)))
                .Returns(_testMeals[0]);
            _mealServiceMock.Setup(ms => ms.GetMealById(It.IsInRange(-99999, 0, Moq.Range.Inclusive)))
                .Throws(new KeyNotFoundException());

            _mealServiceMock.Setup(ms => ms.RemoveMealById(It.IsInRange(1, 2, Moq.Range.Inclusive)))
                .Returns(_testMeals[0]);
        }

        #endregion

        [TestMethod]
        [Fact]
        //Valid Get Meals
        public void GetShouldReturnDtoList()
        {
            var result = _mealController.Get();
            var objResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            var dtoResult = Xunit.Assert.IsAssignableFrom<List<MealDto>>(objResult.Value);
            Xunit.Assert.NotEmpty(dtoResult);
        }


        [TestMethod]
        [Fact]
        //Valid Get Meal By Id
        public void GetByIdShouldReturnDto()
        {
            var result = _mealController.Get(1);
            var objResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            var dtoResult = Xunit.Assert.IsAssignableFrom<MealDto>(objResult.Value);
            Xunit.Assert.NotNull(dtoResult);
        }

        [TestMethod]
        [Fact]
        //Get Meal By Id with negative Id
        public void GetByIdShouldReturnBadRequest_NegativeId()
        {
            _mealController.ModelState.AddModelError("error", "Meal Id negative");
            var result = _mealController.Get(-2);
            var objResult = Xunit.Assert.IsType<BadRequestObjectResult>(result.Result);
            Xunit.Assert.Equal(400, objResult.StatusCode);
        }

        [TestMethod]
        [Fact]
        //Get Meal By Id with invalid Id (Meal with that id doesn´t exist)
        public void GetByIdShouldReturn404_InvalidId()
        {
            _mealController.ModelState.AddModelError("error", "Meal Id not found");
            var result = _mealController.Get(50);
            var objResult = Xunit.Assert.IsType<NotFoundResult>(result.Result);
            Xunit.Assert.Equal(404, objResult.StatusCode);
        }

        [TestMethod]
        [Fact]
        //Valid Post Meal
        public void PostMealShouldReturnDto()
        {
            var testDto = new MealDto()
            {
                Name = "Test Meal",
                Instructions = "Cook water, cook other things",
                Ingredients = new[] { "Chicken", "Water" },
                Measures = new[] { "500g", "1l"}
            };
            var result = _mealController.Post(testDto);
            var objResult = Xunit.Assert.IsType<OkObjectResult>(result.Result);
            var dtoResult = Xunit.Assert.IsAssignableFrom<MealDto>(objResult.Value);
            Xunit.Assert.NotNull(dtoResult);
        }

        [TestMethod]
        [Fact]
        //Invalid Post Meal with 0 Ingredients
        public void PostMealShouldReturn400_InvalidIngredientsLenght()
        {
            var testDto = new MealDto()
            {
                Name = "Test Meal",
                Instructions = "Cook water, cook other things"
            };
            var result = _mealController.Post(testDto);
            var objResult = Xunit.Assert.IsType<BadRequestObjectResult>(result.Result);
            Xunit.Assert.Equal(400, objResult.StatusCode);
        }

        [TestMethod]
        [Fact]
        //Invalid Post Meal with Ingredients and Measured Ingredients Length not matching
        public void PostMealShouldReturn422_UnmatchingIngredientsLenght()
        {
            var testDto = new MealDto()
            {
                Name = "Test Meal",
                Instructions = "Cook water, cook other things",
                Ingredients = new[] { "Chicken", "Water" },
                Measures = new[] { "500g" }
            };
            var result = _mealController.Post(testDto);
            var objResult = Xunit.Assert.IsType<ObjectResult>(result.Result);
            Xunit.Assert.Equal(422, objResult.StatusCode);
        }
    }
}
