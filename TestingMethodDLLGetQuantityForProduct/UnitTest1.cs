using dll;
using System.Diagnostics;
namespace TestingMethodDLLGetQuantityForProduct
{
    [TestClass]
    public class UnitTestSimple
    {
        [TestMethod]
        public void TestMethod_GetQuantityForProduct_IsTrue()
        {
            int result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_IsFalse()
        {
            int result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.IsFalse(result < 0);
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_IsInstanceOfType()
        {
            int result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.IsInstanceOfType(result, typeof(int));
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_IsNotInstanceOfType()
        {
            int result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.IsNotInstanceOfType(result, typeof(double));
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_IsNull()
        {
            int? result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.IsNull(null);
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_IsNotNull()
        {
            int result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_AreEqual()
        {
            int expected = (int)Math.Ceiling((2.0f * 3.0f) * 10 * 1.1 + ((2.0f * 3.0f) * 10 * 1.1 * (0.3 / 100)));
            int result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_AreNotEqual()
        {
            int incorrect = 100; // явно неправильное значение
            int result = Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 3.0f);
            Assert.AreNotEqual(incorrect, result);
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_Minimum_Correct_Value()
        {
            int expected = (int)Math.Ceiling((1.0f * 1.0f) * 1 * 1.1 + ((1.0f * 1.0f) * 1 * 1.1 * (0.3 / 100)));
            int result = Calculation.GetQuantityForProduct(1, 1, 1, 1.0f, 1.0f);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMethod_GetQuantityForProduct_Return_Different_Values_For_Different_ProductTypes()
        {
            int result1 = Calculation.GetQuantityForProduct(1, 1, 5, 2.0f, 2.0f);
            int result2 = Calculation.GetQuantityForProduct(2, 1, 5, 2.0f, 2.0f);

            Assert.AreNotEqual(result1, result2);
        }
    }

    [TestClass]
    public class UnitTestHard
    {
        [TestMethod]
        public void GetQuantityForProduct_Throw_Exception_When_ProductType_Is_Invalid()
        {
            Assert.ThrowsException<InvalidInputException>(() => Calculation.GetQuantityForProduct(0, 1, 10, 2.0f, 3.0f));
        }

        [TestMethod]
        public void GetQuantityForProduct_Throw_Exception_When_ProductType_Too_High()
        {
            Assert.ThrowsException<InvalidInputException>(() => Calculation.GetQuantityForProduct(4, 1, 10, 2.0f, 3.0f));
        }

        [TestMethod]
        public void GetQuantityForProduct_Throw_Exception_When_MaterialType_Is_Invalid()
        {
            Assert.ThrowsException<InvalidInputException>(() => Calculation.GetQuantityForProduct(1, 0, 10, 2.0f, 3.0f));
        }

        [TestMethod]
        public void GetQuantityForProduct_Throw_Exception_When_MaterialType_Too_High()
        {
            Assert.ThrowsException<InvalidInputException>(() => Calculation.GetQuantityForProduct(1, 3, 10, 2.0f, 3.0f));
        }

        [TestMethod]
        public void GetQuantityForProduct_Throw_Exception_When_Count_Is_NonPositive()
        {
            Assert.ThrowsException<InvalidInputException>(() => Calculation.GetQuantityForProduct(1, 1, 0, 2.0f, 3.0f));
        }

        [TestMethod]
        public void GetQuantityForProduct_Throw_Exception_When_Width_Is_NonPositive()
        {
            Assert.ThrowsException<InvalidInputException>(() => Calculation.GetQuantityForProduct(1, 1, 10, 0f, 3.0f));
        }

        [TestMethod]
        public void GetQuantityForProduct_Throw_Exception_When_Length_Is_NonPositive()
        {
            Assert.ThrowsException<InvalidInputException>(() => Calculation.GetQuantityForProduct(1, 1, 10, 2.0f, 0f));
        }
    }
}