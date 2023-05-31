using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq.Expressions;

namespace YourNamespace
{
    [TestClass]
    public class InterpreterPatternTests
    {
        [TestMethod]
        public void NumberExpression_Interpret_ReturnsNumber()
        {
            // Arrange
            int number = 5;
            IExpression expression = new NumberExpression(number);

            // Act
            int result = expression.Interpret();

            // Assert
            Assert.AreEqual(number, result);
        }

        [TestMethod]
        public void AddExpression_Interpret_ReturnsSumOfExpressions()
        {
            // Arrange
            IExpression leftExpression = new NumberExpression(5);
            IExpression rightExpression = new NumberExpression(10);
            IExpression expression = new AddExpression(leftExpression, rightExpression);

            // Act
            int result = expression.Interpret();

            // Assert
            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void SubtractExpression_Interpret_ReturnsDifferenceOfExpressions()
        {
            // Arrange
            IExpression leftExpression = new NumberExpression(10);
            IExpression rightExpression = new NumberExpression(5);
            IExpression expression = new SubtractExpression(leftExpression, rightExpression);

            // Act
            int result = expression.Interpret();

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Context_GetVariable_ReturnsVariableExpression()
        {
            // Arrange
            char variableName = 'x';
            IExpression variableExpression = new NumberExpression(7);
            Context context = new Context();
            context.SetVariable(variableName, variableExpression);

            // Act
            IExpression result = context.GetVariable(variableName);

            // Assert
            Assert.AreSame(variableExpression, result);
        }

        [TestMethod]
        public void Context_GetVariable_VariableNotFound_ThrowsException()
        {
            // Arrange
            char variableName = 'x';
            Context context = new Context();

            // Act & Assert
            Assert.ThrowsException<Exception>(() => context.GetVariable(variableName));
        }
    }
}