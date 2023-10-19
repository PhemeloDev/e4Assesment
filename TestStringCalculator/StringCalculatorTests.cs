
namespace TestStringCalculator
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {            
            StringCalculator calculator = new StringCalculator();
                        
            int result = calculator.Add("");
                        
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("5");

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_TwoNumbersWithCommaDelimiter_ReturnsSum()
        {
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("5,7");

            Assert.AreEqual(12, result);
        }

        [TestMethod]
        public void Add_NewLineDelimiter_ReturnsSum()
        {
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("1\n2,3");

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("//;\n1;2");

            Assert.AreEqual(3, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Add_NegativeNumber_ThrowsException()
        {
            StringCalculator calculator = new StringCalculator();

            calculator.Add("1,-2,3");
        }

        [TestMethod]
        public void Add_NumbersGreaterThan1000_AreIgnored()
        {
            StringCalculator calculator = new StringCalculator();

            int result = calculator.Add("2,1001,6");

            Assert.AreEqual(8, result);
        }
    }
}