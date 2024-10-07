using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp
namespace CalculatorApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        // Initialize required variables for testing
        [TestInitialize]
        public void Setup()
        {
            // Set up the context if needed
            // e.g., set the initial expression, reset static fields, etc.
        }

        [TestMethod]
        public void Estimate_ShouldReturnError_WhenCurrencyCheckFails()
        {
            // Arrange
            // Manipulate internal state to ensure CheckCurrency() returns false
            Calculator.SetCurrencyValid(false); // Assuming you can control currency validity

            // Act
            var result = Calculator.Estimate();

            // Assert
            string expectedError = "&" + ErrorsExpression.GetFullStringError(ErrorsExpression.ERROR_01, erposition);
            Assert.AreEqual(expectedError, result);
        }

        [TestMethod]
        public void Estimate_ShouldReturnEmptyString_WhenFormatIsEmpty()
        {
            // Arrange
            Calculator.SetCurrencyValid(true);  // Assuming you can set this value for testing
            Calculator.SetExpression("expression");

            // Act
            var result = Calculator.Estimate();

            // Assert
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void Estimate_ShouldReturnFormattedString_WhenFormatStartsWithAmpersand()
        {
            // Arrange
            Calculator.SetCurrencyValid(true);
            Calculator.SetExpression("expression");

            // ReplaceUnaryPlusMinus() should be called internally, simulate input accordingly
            Calculator.SetFormattedExpression("&formatted_string");

            // Act
            var result = Calculator.Estimate();

            // Assert
            Assert.AreEqual("&formatted_string", result);
        }

        [TestMethod]
        public void Estimate_ShouldRunEstimate_WhenAllConditionsPass()
        {
            // Arrange
            Calculator.SetCurrencyValid(true);
            Calculator.SetExpression("expression");

            // Simulate the format returned by Format()
            Calculator.SetFormattedExpression("valid_format");

            // Simulate the expected result of RunEstimate()
            Calculator.SetEstimateResult("calculation_result");

            // Act
            var result = Calculator.Estimate();

            // Assert
            Assert.AreEqual("calculation_result", result);
        }
    }
}
