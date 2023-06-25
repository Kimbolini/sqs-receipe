using backend.Models;
using backend.Presentation.Controllers;
using backend.Presentation.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace testBackend
{
    [TestClass]
    public class MealControllerTest
    {
        //The test Meals the test should return
        private static List<Meal> _expectedMeals = new();

        protected Meal[] _testMeals;
        protected Mock<IMealService> _mealServiceMock;
        protected MealController _mealController;

        protected Ingredient[] _testIngredients;
        protected Mock<IIngredientService> _ingredientServiceMock;

        protected MeasuredIngredient[] _testMeasIngredients;
        protected Mock<IMeasuredIngredientService> _measIngredientServiceMock;

        public MealControllerTest(Meal[] meals, Ingredient[] ingredients, MeasuredIngredient[] measuredIngredients)
        {
            _testMeals = meals;
            _testIngredients = ingredients;
            SetupIngredients();
            _testMeasIngredients = measuredIngredients;
            SetupMeasuredIngredients();
            SetupMeals();
        }

        private void SetupIngredients()
        {
            _ingredientServiceMock = new Mock<IIngredientService>();

            _ingredientServiceMock.Setup(i => i.GetIngredientById(It.IsInRange(1, 2, Moq.Range.Inclusive)))
                .Returns(_testIngredients[0]);
            _ingredientServiceMock.Setup(i => i.GetIngredientById(It.IsNotIn(1, 2)))
                .Throws(new KeyNotFoundException());
        }

        private void SetupMeasuredIngredients()
        {
            _measIngredientServiceMock = new Mock<IMeasuredIngredientService>();

            _measIngredientServiceMock.Setup(mis => mis.GetMeasuredIngredientById(It.IsInRange(1, 2, Moq.Range.Inclusive)))
                .Returns(_testMeasIngredients[0]);
            _measIngredientServiceMock.Setup(mis => mis.GetMeasuredIngredientById(It.IsInRange(-99999, 0, Moq.Range.Inclusive)))
                .Throws(new KeyNotFoundException);

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
    }
}
